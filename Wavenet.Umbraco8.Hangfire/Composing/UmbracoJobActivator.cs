// <copyright file="UmbracoJobActivator.cs" company="Wavenet">
// Copyright (c) Wavenet. All rights reserved.
// </copyright>

namespace Wavenet.Umbraco8.Hangfire.Composing
{
    using System;
    using System.IO;
    using System.Web;
    using System.Web.Hosting;

    using global::Hangfire;
    using global::Hangfire.Server;

    using Umbraco.Core.Composing;
    using Umbraco.Web;

    /// <summary>
    /// <see cref="UmbracoJobActivator"/>.
    /// </summary>
    /// <seealso cref="JobActivator" />
    public class UmbracoJobActivator : JobActivator
    {
        /// <summary>
        /// The factory.
        /// </summary>
        private readonly IFactory factory;

        /// <summary>
        /// The umbraco context factory.
        /// </summary>
        private readonly IUmbracoContextFactory umbracoContextFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="UmbracoJobActivator" /> class.
        /// </summary>
        /// <param name="factory">The factory.</param>
        /// <param name="umbracoContextFactory">The umbraco context factory.</param>
        public UmbracoJobActivator(IFactory factory, IUmbracoContextFactory umbracoContextFactory)
        {
            this.factory = factory;
            this.umbracoContextFactory = umbracoContextFactory;
        }

        /// <inheritdoc />
        public override object ActivateJob(Type jobType)
            => this.factory.GetInstance(jobType);

        /// <inheritdoc />
        public override JobActivatorScope BeginScope(PerformContext context)
            => new UmbracoJobActivatorScope(this);

        /// <summary>
        /// <see cref="UmbracoJobActivatorScope"/>.
        /// </summary>
        /// <seealso cref="JobActivatorScope" />
        private class UmbracoJobActivatorScope : JobActivatorScope
        {
            /// <summary>
            /// The umbraco job activator.
            /// </summary>
            private readonly UmbracoJobActivator umbracoJobActivator;

            /// <summary>
            /// The umraco context reference.
            /// </summary>
            private readonly UmbracoContextReference umracoContextReference;

            /// <summary>
            /// Initializes a new instance of the <see cref="UmbracoJobActivatorScope"/> class.
            /// </summary>
            /// <param name="umbracoJobActivator">The umbraco job activator.</param>
            public UmbracoJobActivatorScope(UmbracoJobActivator umbracoJobActivator)
            {
                this.umbracoJobActivator = umbracoJobActivator;
                HttpContext.Current = new HttpContext(new SimpleWorkerRequest("/null.aspx", string.Empty, new StringWriter()));
                this.umracoContextReference = umbracoJobActivator.umbracoContextFactory.EnsureUmbracoContext(new HttpContextWrapper(HttpContext.Current));
            }

            /// <inheritdoc />
            public override void DisposeScope()
            {
                this.umracoContextReference.Dispose();
                if (HttpContext.Current.Items["LightInject.Scope"] is LightInject.Scope scope)
                {
                    scope.Dispose();
                }

                HttpContext.Current = null;
            }

            /// <inheritdoc />
            public override object Resolve(Type type)
                => this.umbracoJobActivator.factory.GetInstance(type);
        }
    }
}