﻿using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Web.Http.Dependencies;

namespace Library.Ninject.Core
{
    public static class NinjectWebCommon
    {
        public static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        public static IKernel Kernel
        {
            get
            {
                return Bootstrapper.Kernel;
            }
        }

        public static IDependencyResolver ServciceLocator
        {
            get
            {
                if (Bootstrapper.Kernel == null) return null;
                return new NinjectDependencyResolver(Bootstrapper.Kernel);
            }
        }

        public static void Start(params INinjectModule[] modules)
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(() => CreateKernel(modules));
        }

        public static void Stop()
        {
            Bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel(params INinjectModule[] modules)
        {
            var kernel = new StandardKernel();

            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                //kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                if (modules != null)
                {
                    kernel.Load(modules); // load modules 
                }
                var config = StartupConfig.Config;
                config.DependencyResolver = new NinjectDependencyResolver(kernel);
                return kernel;
            }
            catch (Exception ex)
            {
                kernel.Dispose();
                throw;
            }
        }
    }
}
