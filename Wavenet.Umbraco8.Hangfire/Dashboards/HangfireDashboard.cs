// <copyright file="HangfireDashboard.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace Wavenet.Umbraco8.Hangfire.Dashboards
{
    using Umbraco.Core.Composing;
    using Umbraco.Core.Dashboards;

    /// <summary>
    /// <see cref="HangfireDashboard"/>.
    /// </summary>
    /// <seealso cref="IDashboard" />
    [Weight(100)]
    public class HangfireDashboard : IDashboard
    {
        /// <inheritdoc />
        public IAccessRule[] AccessRules => new[]
        {
            new AccessRule { Type = AccessRuleType.Grant, Value = Umbraco.Core.Constants.Security.AdminGroupAlias },
        };

        /// <inheritdoc />
        public string Alias => "wavenet.Hangfire";

        /// <inheritdoc />
        public string[] Sections => new[] { Umbraco.Core.Constants.Applications.Settings };

        /// <inheritdoc />
        public string View => "/App_Plugins/Wavenet.Hangfire/dashboard.html";
    }
}