
namespace Zim.Tech.TravelConnect.Travelport.uAPI.Connection
{
    using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// Implements <see cref="IUniversalApiConnection"/> to communicate with Travelport Universal API.
    /// </summary>
    public class UniversalApiConnection : IUniversalApiConnection
    {
        /// <summary>
        /// Gets or sets the last error received from the HttpWebRequest call.
        /// </summary>
        public string LastError { get; set; }

        /// <summary>
        /// Gets or sets the password used for credentials.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the end point for the Travelport Universal API web service.
        /// </summary>
        public Uri Uri { get; set; }

        /// <summary>
        /// Gets or sets the user name used for credentials.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Send a request to the Travelport Universal API web service.
        /// </summary>
        /// <param name="request">XML request to be sent</param>
        /// <returns>An <see cref="XmlDocument"/> with the response.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "All exceptions are turned into strings for this sample")]
        public XmlDocument SendRequest(XmlDocument request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            HttpWebRequest serverRequest = this.CreateRequestObject();

            byte[] requestBytes = GetSoapEnvelope(request);

            // Send request to the server
            Stream stream = serverRequest.GetRequestStream();
            stream.Write(requestBytes, 0, requestBytes.Length);
            stream.Close();

            // Receive response
            Stream receiveStream = null;
            HttpWebResponse webResponse;

            try
            {
                webResponse = (HttpWebResponse)serverRequest.GetResponse();
                receiveStream = webResponse.GetResponseStream();
            }
            catch (WebException exception)
            {
                this.SetErrorMessage(exception);

                if (exception.Response != null)
                {
                    // Although the request failed, we can still get a response that might
                    // contain a better error message.
                    receiveStream = exception.Response.GetResponseStream();
                }
                else
                {
                    return null;
                }
            }

            // Read output stream
            StreamReader streamReader = new StreamReader(receiveStream, Encoding.UTF8);
            string result = streamReader.ReadToEnd();

            // Remove SOAP elements
            XmlDocument filteredDocument = this.GetResponseDocument(result);

            return filteredDocument;
        }

        /// <summary>
        /// Creates the SOAP Envelope to wrap the request in.
        /// </summary>
        /// <param name="request">XML Request to be embedded as the SOAP payload.</param>
        /// <returns>Byte stream containing the SOAP message.</returns>
        private static byte[] GetSoapEnvelope(XmlDocument request)
        {
            // Build SOAP envelope
            StringBuilder builder = new StringBuilder();
            builder.Append("<SOAP-ENV:Envelope xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\">");
            builder.Append("<SOAP-ENV:Body>");
            builder.Append(request.DocumentElement.OuterXml);
            builder.Append("</SOAP-ENV:Body>");
            builder.Append("</SOAP-ENV:Envelope>");

            // Convert the SOAP envelope into a byte array
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] requestBytes = encoding.GetBytes(builder.ToString());

            return requestBytes;
        }

        /// <summary>
        /// Sets an error message depending on the <see cref="WebException"/>.
        /// </summary>
        /// <param name="exception">The exception received.</param>
        private void SetErrorMessage(WebException exception)
        {
            if (exception.Response != null && ((HttpWebResponse)exception.Response).StatusCode == HttpStatusCode.Unauthorized)
            {
                this.LastError = "The server returned Unauthorized. Please ensure that you are using the correct user name and password.";
            }
            else if (exception.Response != null && ((HttpWebResponse)exception.Response).StatusCode == HttpStatusCode.NotFound)
            {
                this.LastError = "The service could not be found on the server. Please check that you are using the correct URL.";
                this.LastError += Environment.NewLine + Environment.NewLine;
                this.LastError += "The URL will vary depending on the service you want to access.";
            }
            else
            {
                this.LastError = exception.Message;
            }
        }

        /// <summary>
        /// Extracts the xml response from the response.
        /// </summary>
        /// <param name="result">The response received.</param>
        /// <returns>An <see cref="XmlDocument"/> containing the response.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "All exceptions are converted to strings for the purpose of this demo.")]
        private XmlDocument GetResponseDocument(string result)
        {
            XmlDocument responseXmlDocument = new XmlDocument();
            XmlDocument filteredDocument = null;

            try
            {
                responseXmlDocument.LoadXml(result);

                XmlNode filteredResponse = responseXmlDocument.SelectSingleNode("//*[local-name()='Body']/*");

                filteredDocument = new XmlDocument();
                filteredDocument.LoadXml(filteredResponse.OuterXml);
            }
            catch (Exception ex)
            {
                if (string.IsNullOrEmpty(this.LastError))
                {
                    if (ex.Message.StartsWith("'xsd' is an undeclared prefix", StringComparison.OrdinalIgnoreCase))
                    {
                        this.LastError = "The server could not find a valid schema document for the schema referenced in your request. Please check the version number of each schema referenced.";
                    }
                    else
                    {
                        this.LastError = ex.Message;
                    }
                }
            }

            return filteredDocument;
        }

        /// <summary>
        /// Creates the request object.
        /// </summary>
        /// <returns>An initialized <see cref="HttpWebRequest"/> object.</returns>
        private HttpWebRequest CreateRequestObject()
        {
            HttpWebRequest serverRequest = (HttpWebRequest)WebRequest.Create(this.Uri);

            // We are posting a XML request
            serverRequest.Method = "POST";
            serverRequest.ContentType = "text/xml";

            // Set up the connection to optimize for web services and receive compressed responses.
            ServicePointManager.UseNagleAlgorithm = false;
            ServicePointManager.Expect100Continue = false;
            serverRequest.AutomaticDecompression = DecompressionMethods.GZip;

            // Always add authentication to the header - avoids issue with internal URL's that doesn't require
            // authentication.
            byte[] authBytes = Encoding.UTF8.GetBytes((this.UserName + ":" + this.Password).ToCharArray());
            serverRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(authBytes);

            return serverRequest;
        }
    }
}