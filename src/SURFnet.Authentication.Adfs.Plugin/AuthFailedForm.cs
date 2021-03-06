﻿namespace SURFnet.Authentication.Adfs.Plugin
{
    using Microsoft.IdentityServer.Web.Authentication.External;

    using Properties;

    /// <summary>
    /// The presentation form for the adapter.
    /// </summary>
    /// <seealso cref="Microsoft.IdentityServer.Web.Authentication.External.IAdapterPresentationForm" />
    public class AuthFailedForm : IAdapterPresentationForm
    {
        /// <summary>
        /// The status message.
        /// </summary>
        private string statusMessage;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthFailedForm"/> class.
        /// </summary>
        public AuthFailedForm()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthFailedForm"/> class.
        /// </summary>
        /// <param name="statusMessage">The status message.</param>
        public AuthFailedForm(string statusMessage)
        {
            this.statusMessage = statusMessage;
        }

        /// <summary>
        /// Gets the form HTML.
        /// </summary>
        /// <param name="lcid">The LCID.</param>
        /// <returns>The form HTML.</returns>
        public string GetFormHtml(int lcid)
        {
            var message = "Er is een onherstelbare fout opgetreden. Probeer het opnieuw.";
            if (!string.IsNullOrWhiteSpace(this.statusMessage))
            {
                message = $"De verificatie is mislukt vanwege de volgende reden:\n{this.statusMessage}";
            }

            var form = Resources.AuthFailedForm;
            form = form.Replace("{message}", message);
            return form;
        }

        /// <summary>
        /// Gets the form pre render HTML.
        /// </summary>
        /// <param name="lcid">The LCID.</param>
        /// <returns>The pre render HTML.</returns>
        public string GetFormPreRenderHtml(int lcid)
        {
            return null;
        }

        /// <summary>
        /// Gets the page title.
        /// </summary>
        /// <param name="lcid">The LCID.</param>
        /// <returns>The page title.</returns>
        public string GetPageTitle(int lcid)
        {
            return "Authentication failed";
        }
    }
}
