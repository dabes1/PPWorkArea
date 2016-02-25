using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Added using
using PayPal;
using PayPal.Api;
using PayPalCommonObject;
using System.IO;

namespace PayPalUtilityObject
{

    public enum RequestFlowItemMessageType
    {
        General,
        Success,
        Error
    }

    public class RequestFlowItemMessage
    {
        /// <summary>
        /// Gets or sets the message to accompany a flow item.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets what type of message this object contains.
        /// </summary>
        public RequestFlowItemMessageType Type { get; set; }
    }

    public class RequestFlowItem
    {
        /// <summary>
        /// Gets or sets the title of this portion of the flow.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets text describing this portion of the flow.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the list of messages to accompany this flow item.
        /// </summary>
        public List<RequestFlowItemMessage> Messages { get; set; }

        /// <summary>
        /// Gets or sets the request body.
        /// </summary>
        public string Request { get; set; }

        /// <summary>
        /// Gets or sets the response body.
        /// </summary>
        public string Response { get; set; }

        /// <summary>
        /// Gets or sets whether or not the response was an error response.
        /// </summary>
        public bool IsErrorResponse { get; set; }

        /// <summary>
        /// Gets or sets a redirect URL that should accompany this flow item.
        /// </summary>
        public string RedirectUrl { get; set; }

        /// <summary>
        /// Gets or sets the text for the redirect URL.
        /// </summary>
        public string RedirectUrlText { get; set; }

        /// <summary>
        /// Gets or sets whether the redirect URL has been approved.
        /// </summary>
        public bool IsRedirectApproved { get; set; }

        /// <summary>
        /// Gets or sets an image associated with this flow item.
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RequestFlowItem()
        {
            this.Messages = new List<RequestFlowItemMessage>();
        }

        /// <summary>
        /// Records an exception encountered during this portion of the flow.
        /// </summary>
        /// <param name="ex">The exception to be recorded.</param>
        public void RecordException(Exception ex)
        {
            this.IsErrorResponse = true;

            if (ex is ConnectionException)
            {
                this.Response = Common.FormatJsonString(((ConnectionException)ex).Response);
                if (string.IsNullOrEmpty(ex.Message))
                {
                    this.RecordError(string.Format("Error thrown from SDK as type {0}.", ex.GetType().ToString()));
                }
                else
                {
                    this.RecordError(ex.Message);
                }
            }
            else if (ex is PayPalException && ex.InnerException != null)
            {
                this.RecordError(ex.InnerException.Message);
            }
            else
            {
                this.RecordError(ex.Message);
            }
        }

        /// <summary>
        /// Records a message that will be displayed as an error.
        /// </summary>
        /// <param name="message">The error message</param>
        public void RecordError(string message)
        {
            this.RecordMessage(message, RequestFlowItemMessageType.Error);
        }

        /// <summary>
        /// Records a message that will be displayed as a success message.
        /// </summary>
        /// <param name="message">The success message</param>
        public void RecordSuccess(string message)
        {
            this.RecordMessage(message, RequestFlowItemMessageType.Success);
        }

        /// <summary>
        /// Records a message that will be displayed with this flow item.
        /// </summary>
        /// <param name="message">The message to be displayed</param>
        /// <param name="type">The message type</param>
        public void RecordMessage(string message, RequestFlowItemMessageType type = RequestFlowItemMessageType.General)
        {
            this.Messages.Add(new RequestFlowItemMessage() { Message = message, Type = type });
        }
    }


    public class Utilities
    {
    }

    public class RequestFlow
    {
        /// <summary>
        /// Gets the list of RequestFlowItems for this flow.
        /// </summary>
        public List<RequestFlowItem> Items { get; private set; }

        /// <summary>
        /// Gets or sets a general description of the flow.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Default construct that initializes the Items list.
        /// </summary>
        public RequestFlow()
        {
            this.Items = new List<RequestFlowItem>();
        }

        /// <summary>
        /// Adds a new RequestFlowItem to the list of Items.
        /// </summary>
        /// <param name="title">Title of this flow item.</param>
        /// <param name="requestObject">(Optional) The object used for the request.</param>
        /// <param name="description">(Optional) The description of the request.</param>
        public void AddNewRequest(string title, IPayPalSerializableObject requestObject = null, string description = "")
        {
            this.Items.Add(new RequestFlowItem()
            {
                Request = requestObject == null ? string.Empty : Common.FormatJsonString(requestObject.ConvertToJson()),
                Title = title,
                Description = description
            });
        }

        /// <summary>
        /// Records a response in the last RequestFlowItem stored in the Items list.
        /// </summary>
        /// <param name="responseObject"></param>
        public void RecordResponse(IPayPalSerializableObject responseObject)
        {
            if (responseObject != null && this.Items.Any())
            {
                this.Items.Last().Response = Common.FormatJsonString(responseObject.ConvertToJson());
            }
        }

        /// <summary>
        /// Records a success message that indicates the last request was successful.
        /// </summary>
        /// <param name="message"></param>
        public void RecordActionSuccess(string message)
        {
            if (this.Items.Any())
            {
                this.Items.Last().RecordSuccess(message);
            }
        }

        /// <summary>
        /// Records an image that was returned from a call (e.g. Invoice.QrCode)
        /// </summary>
        /// <param name="image"></param>
        public void RecordImage(Image image)
        {
            if (this.Items.Any())
            {
                var filename = "Images/sample.png";
                var serverRoot = HttpContext.Current.Server.MapPath(null);
                image.Save(Path.Combine(serverRoot, filename));
                this.Items.Last().ImagePath = filename;
            }
        }

        /// <summary>
        /// Records an exception that was encountered and ties it to the last RequestResponse object in the flow.
        /// </summary>
        /// <param name="ex"></param>
        public void RecordException(Exception ex)
        {
            if (ex != null)
            {
                if (!this.Items.Any())
                {
                    this.Items.Add(new RequestFlowItem());
                }
                this.Items.Last().RecordException(ex);
            }
        }

        /// <summary>
        /// Records a redirect URL that should be displayed with a flow item.
        /// </summary>
        /// <param name="text">The display text</param>
        /// <param name="redirectUrl">The URL for the redirect</param>
        public void RecordRedirectUrl(string text, string redirectUrl)
        {
            if (this.Items.Any())
            {
                this.Items.Last().RedirectUrlText = text;
                this.Items.Last().RedirectUrl = redirectUrl;
            }
        }

        /// <summary>
        /// Records that a resource has been approved for payment.
        /// </summary>
        /// <param name="message"></param>
        public void RecordApproval(string message)
        {
            if (this.Items.Any())
            {
                this.Items.Last().Title += " (Approved!)";
                this.Items.Last().RedirectUrlText = message;
                this.Items.Last().IsRedirectApproved = true;
            }
        }
    }
}