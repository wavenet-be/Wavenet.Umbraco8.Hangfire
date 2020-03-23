// <copyright file="BaseHangfireRecurringJobRegistrationComposer.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace Wavenet.Umbraco8.Hangfire.Composing
{
    using global::Hangfire;

    using Umbraco.Core.Composing;

    /// <summary>
    /// Base class for <see cref="RecurringJob"/> registration.
    /// </summary>
    /// <seealso cref="IUserComposer" />
    [ComposeAfter(typeof(HangfireComposer))]
    public abstract class BaseHangfireRecurringJobRegistrationComposer : IUserComposer
    {
        /// <summary>
        /// Composes the specified composition.
        /// </summary>
        /// <param name="composition">The composition.</param>
        public void Compose(Composition composition)
            => this.RegisterJobs();

        /// <summary>
        /// Registers the jobs.
        /// </summary>
        public abstract void RegisterJobs();
    }
}