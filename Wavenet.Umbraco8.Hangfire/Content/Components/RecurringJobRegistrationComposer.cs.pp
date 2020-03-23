// <copyright file="RecurringJobRegistrationComposer.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace $rootnamespace$.Components
{
    using Hangfire;

    using Umbraco.Core.Composing;

    using Wavenet.Umbraco8.Hangfire.Composing;

    /// <summary>
    /// Register jobs in Hangfire.
    /// </summary>
    [ComposeAfter(typeof(HangfireComposer))]
    public class RecurringJobRegistrationComposer : IUserComposer
    {
        /// <inheritdoc />
        public void Compose(Composition composition)
        {
            /*
             * Adds your recurring job in Hangfire:
             * RecurringJob.AddOrUpdate(() => new Job().Execute, Cron.Hourly());
             */
        }
    }
}