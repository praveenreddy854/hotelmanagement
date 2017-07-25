[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(HotelManagement.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(HotelManagement.App_Start.NinjectWebCommon), "Stop")]

namespace HotelManagement.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using HotelManagement.Data.Repositories;
    using HotelManagement.Data;
    using HotelManagement.Services.Services;
    using HotelManagement.Models.Models;
    using HotelMangement.Services.Services;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
                
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ICustomerRepository>().To<CustomerRepository>();
            kernel.Bind<IItemsRepository>().To<ItemsRepository>();
            kernel.Bind<IOrderRepository>().To<OrderRepository>();
            kernel.Bind<IMenuRepository>().To<MenuRepository>();
            kernel.Bind<ICommonUserRepository>().To<CommonUserRepository>();

            kernel.Bind<ICustomerService>().To<CustomerService>();
            kernel.Bind<IItemService>().To<ItemService>();
            kernel.Bind<IOrderService>().To<OrderService>();
            kernel.Bind<IMenuService>().To<MenuService>(); 
            kernel.Bind<ICommonUserService>().To<CommonUserService>();

        }        
    }
}
