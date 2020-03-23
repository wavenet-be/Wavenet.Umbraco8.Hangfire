// <copyright file="UmbracoAuthorizationFilter.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace Wavenet.Umbraco8.Hangfire.Security
{
    using System.Linq;
    using System.Web;

    using global::Hangfire.Dashboard;

    using Umbraco.Web.Composing;
    using Umbraco.Web.Security;

    /// <summary>
    /// <see cref="UmbracoAuthorizationFilter"/>.
    /// </summary>
    /// <seealso cref="IDashboardAuthorizationFilter" />
    public class UmbracoAuthorizationFilter : IDashboardAuthorizationFilter
    {
        /// <inheritdoc />
        public bool Authorize(DashboardContext context)
        {
            var httpContext = new HttpContextWrapper(HttpContext.Current);
            var ticket = httpContext.GetUmbracoAuthTicket();
            httpContext.AuthenticateCurrentRequest(ticket, true);
            var user = Current.UmbracoContext.Security.CurrentUser;
            return user != null && user.Groups.Any(g => g.Alias == Umbraco.Core.Constants.Security.AdminGroupAlias);
        }
    }
}