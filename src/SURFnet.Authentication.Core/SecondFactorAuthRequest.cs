﻿namespace SURFnet.Authentication.Core
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// Contains the data to do a second factor authentication request.
    /// </summary>
    public class SecondFactorAuthRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecondFactorAuthRequest"/> class.
        /// </summary>
        public SecondFactorAuthRequest()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SecondFactorAuthRequest" /> class.
        /// </summary>
        /// <param name="uri"> The ADFS request URL including the SAML request and signing.</param>
        public SecondFactorAuthRequest(Uri uri)
        {
            this.OriginalRequest = uri.OriginalString;
        }

        /// <summary>
        /// Gets or sets the ADFS request URL including the SAML request and signing. We need this, because we have to a post back with
        /// exact the same query string parameters to end up in the TryEndAuthentication of the plugin.
        /// </summary>
        /// <value>The original SALM request and signature.</value>
        public string OriginalRequest
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the encoded encrypted context generated by ADFS.
        /// </summary>
        /// <value>The ADFS context.</value>
        public string AdfsContext
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the decoded encrypted context generated by ADFS.
        /// </summary>
        /// <value>The ADFS context.</value>
        public string DecodedAdfsContext => 
            !string.IsNullOrWhiteSpace(this.AdfsContext) ? 
                Uri.UnescapeDataString(this.AdfsContext) : 
                null;

        /// <summary>
        /// Gets or sets the authentication method used by ADFS.
        /// </summary>
        /// <value>The authentication method.</value>
        public string AuthMethod
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the second factor endpoint.
        /// </summary>
        /// <value>The second factor endpoint.</value>
        public Uri SecondFactorEndpoint
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the created SAML request for the second factor request.
        /// </summary>
        /// <value>The SAMl request.</value>
        public string SamlRequest
        {
            get;
            set;
        }
        
        /// <summary>
        /// Gets or sets the SAML request identifier.
        /// </summary>
        /// <value>The SAML request identifier.</value>
        public string SamlRequestId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the signing algorithm for the SAML request.
        /// </summary>=
        /// <value>The signing algorithm.</value>
        public string SigAlg => "http://www.w3.org/2001/04/xmldsig-more#rsa-sha256";

        /// <summary>
        /// Gets or sets the signature of the SAML request.
        /// </summary>
        /// <value>The signature.</value>
        public string SamlSignature
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the authentication request signature.
        /// </summary>
        /// <value>The authentication request signature.</value>
        public string AuthRequestSignature
        {
            get;
            set;
        }
        
        /// <summary>
        /// Deserializes the <see cref="SecondFactorAuthRequest"/> data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>A Second Factor Authentication Request.</returns>
        public static SecondFactorAuthRequest Deserialize(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return null;
            }

            data = Uri.UnescapeDataString(data);
            var result = JsonConvert.DeserializeObject<SecondFactorAuthRequest>(data);
            return result;
        }

        /// <summary>
        /// Serializes this instance.
        /// </summary>
        /// <returns>The JSON.</returns>
        public string Serialize()
        {
            var json = JsonConvert.SerializeObject(this);
            var escapedString = Uri.EscapeDataString(json);
            return escapedString;
        }

        /// <summary>
        /// Creates the url for the HTTP Redirect to the Second factor endpoint.
        /// </summary>
        /// <returns>A Url.</returns>
        public string CreateSfoRequestUrl()
        {
            var url = $"{this.SecondFactorEndpoint}?SAMLRequest={Uri.EscapeDataString(this.SamlRequest)}&SigAlg={Uri.EscapeDataString(this.SigAlg)}&Signature={Uri.EscapeDataString(this.SamlSignature)}";
            return url;
        }
    }
}
