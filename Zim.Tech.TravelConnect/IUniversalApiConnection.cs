
namespace Zim.Tech.TravelConnect.Travelport.uAPI.Connection
{
    using System;

    /// <summary>
    /// Defines an interface for communicating with Travelport Universal API.
    /// </summary>
    public interface IUniversalApiConnection
    {
        /// <summary>
        /// Gets or sets the last error received from the HttpWebRequest call.
        /// </summary>
        string LastError { get; set; }

        /// <summary>
        /// Gets or sets the password used for credentials.
        /// </summary>
        string Password { get; set; }

        /// <summary>
        /// Gets or sets the end point for the Travelport Universal API web service.
        /// </summary>
        Uri Uri { get; set; }

        /// <summary>
        /// Gets or sets the user name used for credentials.
        /// </summary>
        string UserName { get; set; }

        /// <summary>
        /// Send a request to the Travelport Universal API web service.
        /// </summary>
        /// <param name="request">XML request to be sent</param>
        /// <returns>An <see cref="XmlDocument"/> with the response.</returns>
        System.Xml.XmlDocument SendRequest(System.Xml.XmlDocument request);
    }
}