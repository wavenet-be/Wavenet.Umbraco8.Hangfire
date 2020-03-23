// <copyright file="HangfireComposer.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace Wavenet.Umbraco8.Hangfire.Composing
{
    using global::Hangfire;

    using Umbraco.Core;
    using Umbraco.Core.Composing;

    /// <summary>
    /// <see cref="HangfireComposer"/>.
    /// </summary>
    /// <seealso cref="IUserComposer" />
    public class HangfireComposer : IUserComposer
    {
        /// <inheritdoc />
        public void Compose(Composition composition)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage(Constants.System.UmbracoConnectionName);
            composition.Register(typeof(UmbracoJobActivator));
            composition.Components().Append<HangfireComponent>();
        }
    }
}