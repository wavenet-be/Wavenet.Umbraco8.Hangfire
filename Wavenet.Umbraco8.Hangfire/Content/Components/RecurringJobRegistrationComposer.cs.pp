// <copyright file="RecurringJobRegistrationComposer.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace $rootnamespace$.Components
{
    using Hangfire;

    using Wavenet.Umbraco8.Hangfire.Composing;

    /// <summary>
    /// Register jobs in Hangfire.
    /// </summary>
    /// <seealso cref="BaseHangfireRecurringJobRegistrationComposer" />
    public class RecurringJobRegistrationComposer : BaseHangfireRecurringJobRegistrationComposer
    {
        /// <inheritdoc />
        public override void RegisterJobs()
        {
            /*
             * Adds your recurring job in Hangfire:
             * RecurringJob.AddOrUpdate(() => new Job().Execute, Cron.Hourly());
             */
        }
    }
}