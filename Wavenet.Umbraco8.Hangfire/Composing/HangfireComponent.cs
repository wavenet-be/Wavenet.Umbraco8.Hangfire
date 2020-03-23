// <copyright file="HangfireComponent.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace Wavenet.Umbraco8.Hangfire.Composing
{
    using global::Hangfire;

    using Umbraco.Core.Composing;
    using Umbraco.Web;

    using Wavenet.Umbraco8.Hangfire.Security;

    /// <summary>
    /// <see cref="HangfireComponent"/>.
    /// </summary>
    /// <seealso cref="IComponent" />
    public class HangfireComponent : IComponent
    {
        /// <summary>
        /// The umbraco job activator.
        /// </summary>
        private readonly UmbracoJobActivator umbracoJobActivator;

        /// <summary>
        /// Initializes a new instance of the <see cref="HangfireComponent" /> class.
        /// </summary>
        /// <param name="umbracoJobActivator">The umbraco job activator.</param>
        public HangfireComponent(UmbracoJobActivator umbracoJobActivator)
        {
            this.umbracoJobActivator = umbracoJobActivator;
        }

        /// <inheritdoc />
        public void Initialize()
        {
            UmbracoDefaultOwinStartup.MiddlewareConfigured += this.SetupOwinMiddleware;
        }

        /// <inheritdoc />
        public void Terminate()
        {
            UmbracoDefaultOwinStartup.MiddlewareConfigured -= this.SetupOwinMiddleware;
        }

        /// <summary>
        /// Setups the owin middleware.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="OwinMiddlewareConfiguredEventArgs"/> instance containing the event data.</param>
        private void SetupOwinMiddleware(object sender, OwinMiddlewareConfiguredEventArgs e)
        {
            GlobalConfiguration.Configuration.UseActivator(this.umbracoJobActivator);
            e.AppBuilder.UseHangfireDashboard("/hangfire", new DashboardOptions
            {
                Authorization = new[] { new UmbracoAuthorizationFilter() },
            });
            e.AppBuilder.UseHangfireServer();
        }
    }
}