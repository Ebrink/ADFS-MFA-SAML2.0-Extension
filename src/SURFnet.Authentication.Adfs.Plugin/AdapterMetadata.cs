﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdapterMetadata.cs" company="Winvision bv">
//   Copyright (c) Winvision bv.  All rights reserved.
// </copyright>
// <summary>
//   Defines the AdapterMetadata type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SURFnet.Authentication.Adfs.Plugin
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    using Microsoft.IdentityServer.Web.Authentication.External;

    /// <summary>
    /// The adapter metadata.
    /// </summary>
    /// <seealso cref="Microsoft.IdentityServer.Web.Authentication.External.IAuthenticationAdapterMetadata" />
    public class AdapterMetadata : IAuthenticationAdapterMetadata
    {
        /// <summary>
        /// Returns an array of strings containing URIs indicating the set of authentication methods implemented by the adapter
        /// AD FS requires that, if authentication is successful, the method actually employed will be returned by the
        /// final call to TryEndAuthentication(). If no authentication method is returned, or the method returned is not
        /// one of the methods listed in this property, the authentication attempt will fail.
        /// </summary>
        /// <value>The authentication methods.</value>
        public string[] AuthenticationMethods => new[]
                                                     {
                                                         "http://schemas.microsoft.com/ws/2012/12/authmethod/otp"
                                                     };

        /// <summary>
        /// Returns an array indicating the type of claim that that the adapter uses to identify the user being authenticated.
        /// Note that although the property is an array, only the first element is currently used.
        /// MUST BE ONE OF THE FOLLOWING
        /// "http://schemas.microsoft.com/ws/2008/06/identity/claims/windowsaccountname"
        /// "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn"
        /// "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"
        /// "http://schemas.microsoft.com/ws/2008/06/identity/claims/primarysid"
        /// </summary>
        /// <value>The identity claims.</value>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1629:DocumentationTextMustEndWithAPeriod", Justification = "Reviewed. Suppression is OK here.")]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        public string[] IdentityClaims => new[]
                                              {
                                                  "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/upn"
                                              };

        /// <summary>
        /// Returns the name of the provider that will be shown in the AD FS management UI (not visible to end users).
        /// </summary>
        /// <value>The name of the admin.</value>
        public string AdminName => "ADFS.SCSA";

        /// <summary>
        /// Gets an array indicating which languages are supported by the provider. AD FS uses this information
        /// to determine the best language\locale to display to the user.
        /// </summary>
        /// <value>The available LCIDS.</value>
        public int[] AvailableLcids => new[]
                                           {
                                               new CultureInfo("en-us").LCID
                                           };

        /// <summary>
        /// Gets a Dictionary containing the set of localized descriptions (hover over help) of the provider, indexed by LCID. 
        /// These descriptions are displayed in the "choice page" offered to the user when there is more than one 
        /// secondary authentication provider available.
        /// </summary>
        public Dictionary<int, string> Descriptions
        {
            get
            {
                var descriptions = new Dictionary<int, string>
                                       {
                                               {
                                                   new CultureInfo("en-us").LCID, "SURFNet Second Factor Authentication."
                                               }
                                       };
                return descriptions;
            }
        }

        /// <summary>
        /// Gets a Dictionary containing the set of localized friendly names of the provider, indexed by LCID. 
        /// These Friendly Names are displayed in the "choice page" offered to the user when there is more than 
        /// one secondary authentication provider available.
        /// </summary>
        public Dictionary<int, string> FriendlyNames
        {
            get
            {
                var friendlyNames = new Dictionary<int, string>
                                        {
                                                {
                                                    new CultureInfo("en-us").LCID, "SURFNet Second Factor Authentication."
                                                }
                                        };
                return friendlyNames;
            }
        }

        /// <summary>
        /// Gets an indication whether or not the Authentication Adapter requires an Identity Claim or not.
        /// If you require an Identity Claim, the claim type must be presented through the IdentityClaims property.
        /// All external providers must return a value of "true" for this property.
        /// </summary>
        /// <value><c>true</c> if [requires identity]; otherwise, <c>false</c>.</value>
        public bool RequiresIdentity => true;
    }
}