// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Extensions methods for configuring Razor Pages via an <see cref="IMvcBuilder"/>.
    /// </summary>
    public static class MvcRazorPagesMvcBuilderExtensions
    {
        /// <summary>
        /// Configures a set of <see cref="RazorViewEngineOptions"/> for the application.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcBuilder"/>.</param>
        /// <param name="setupAction">An action to configure the <see cref="RazorViewEngineOptions"/>.</param>
        /// <returns>The <see cref="IMvcBuilder"/>.</returns>
        public static IMvcBuilder AddRazorPagesOptions(
            this IMvcBuilder builder,
            Action<RazorPagesOptions> setupAction)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            builder.Services.Configure(setupAction);
            return builder;
        }

        /// <summary>
        /// Configures Razor Pages to use the specified <paramref name="rootDirectory"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IMvcCoreBuilder"/>.</param>
        /// <param name="rootDirectory">The application relative path to use as the root directory.</param>
        /// <returns></returns>
        public static IMvcBuilder WithRazorPagesRoot(this IMvcBuilder builder, string rootDirectory)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (string.IsNullOrEmpty(rootDirectory))
            {
                throw new ArgumentException(Resources.ArgumentCannotBeNullOrEmpty, nameof(rootDirectory));
            }

            builder.Services.Configure<RazorPagesOptions>(options => options.RootDirectory = rootDirectory);
            return builder;
        }
    }
}
