using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MavenThought.Commons.Logging;
using MavenThought.Commons.Properties;
using Microsoft.Practices.Composite;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Logging;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Presentation.Regions;
using Microsoft.Practices.Composite.Presentation.Regions.Behaviors;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.ServiceLocation;

namespace MavenThought.Commons.WPF.Windsor
{
    /// <summary>
    /// Bootstrapper that uses the windsor container
    /// </summary>
    public abstract class WindsorBootstrapper
    {
        /// <summary>
        /// Logger facade to use
        /// </summary>
        private readonly ILoggerFacade _loggerFacade = new Log4NetLogger();
        
        /// <summary>
        /// Flag to indicate whether the default configuration should be used
        /// </summary>
        private bool _useDefaultConfiguration = true;

        /// <summary>
        /// Gets the default <see cref="IWindsorContainer"/> for the application.
        /// </summary>
        /// <value>The default <see cref="IWindsorContainer"/> instance.</value>
        public IWindsorContainer Container { get; private set; }

        /// <summary>
        /// Gets the default <see cref="ILoggerFacade"/> for the application.
        /// </summary>
        /// <value>A <see cref="ILoggerFacade"/> instance.</value>
        protected virtual ILoggerFacade LoggerFacade
        {
            get { return this._loggerFacade; }
        }

        /// <summary>
        /// Runs the bootstrapper process.
        /// </summary>
        public void Run()
        {
            this.Run(true);
        }

        /// <summary>
        /// Run the bootstrapper process.
        /// </summary>
        /// <param name="runWithDefaultConfiguration">If <see langword="true"/>, registers default Composite Application Library services in the container. This is the default behavior.</param>
        public void Run(bool runWithDefaultConfiguration)
        {
            this._useDefaultConfiguration = runWithDefaultConfiguration;

            var logger = this.LoggerFacade;

            if (logger == null)
            {
                throw new InvalidOperationException(Resources.NullLoggerFacadeException);
            }

            logger.Debug("Creating Windsor container");
            
            this.Container = this.CreateContainer();
            
            if (this.Container == null)
            {
                throw new InvalidOperationException(Resources.NullWindsorContainerException);
            }

            logger.Debug("Configuring container");
            
            this.ConfigureContainer();

            logger.Debug("Configuring region adapters");

            this.ConfigureRegionAdapterMappings();

            this.ConfigureDefaultRegionBehaviors();

            this.RegisterFrameworkExceptionTypes();

            logger.Debug("Configuring Service Directory");

            logger.Debug("Creating shell");

            var shell = this.CreateShell();

            if (shell != null)
            {
                RegionManager.SetRegionManager(shell, this.Container.Resolve<IRegionManager>());
                
                RegionManager.UpdateRegions();
            }

            logger.Debug("Initializing modules");

            this.InitializeModules();

            logger.Debug("Bootstrapper sequence completed");
        }

        /// <summary>
        /// Registers in the <see cref="IWindsorContainer"/> the <see cref="Type"/> of the Exceptions
        /// that are not considered root exceptions by the <see cref="ExceptionExtensions"/>.
        /// </summary>
        protected virtual void RegisterFrameworkExceptionTypes()
        {
            ExceptionExtensions.RegisterFrameworkExceptionType(typeof(ActivationException));

            ExceptionExtensions.RegisterFrameworkExceptionType(typeof(ComponentNotFoundException));

            ExceptionExtensions.RegisterFrameworkExceptionType(typeof(ComponentRegistrationException));
        }

        /// <summary>
        /// Configures the <see cref="IWindsorContainer"/>. May be overwritten in a derived class to add specific
        /// type mappings required by the application.
        /// </summary>
        protected virtual void ConfigureContainer()
        {
            this.Container.Register(Component
                                        .For<ILoggerFacade>()
                                        .Instance(this.LoggerFacade));

            this.Container.Register(Component
                                        .For<IWindsorContainer>()
                                        .Instance(this.Container));

            var catalog = this.GetModuleCatalog();

            if (catalog != null)
            {
                this.Container.Register(Component
                                            .For<IModuleCatalog>()
                                            .Instance(catalog));
            }

            if (this._useDefaultConfiguration)
            {
                RegisterTypeIfMissing<IServiceLocator, WindsorServiceLocator>(true);
                RegisterTypeIfMissing<IModuleInitializer, ModuleInitializer>(true);
                RegisterTypeIfMissing<IModuleManager, ModuleManager>(true);
                RegisterTypeIfMissing<RegionAdapterMappings, RegionAdapterMappings>(true);
                RegisterTypeIfMissing<IRegionManager, RegionManager>(true);
                RegisterTypeIfMissing<IEventAggregator, EventAggregator>(true);
                RegisterTypeIfMissing<IRegionViewRegistry, RegionViewRegistry>(true);
                RegisterTypeIfMissing<IRegionBehaviorFactory, RegionBehaviorFactory>(true);

                ServiceLocator.SetLocatorProvider(() => this.Container.Resolve<IServiceLocator>());
            }
        }

        /// <summary>
        /// Configures the default region adapter mappings to use in the application, in order
        /// to adapt UI controls defined in XAML to use a region and register it automatically.
        /// May be overwritten in a derived class to add specific mappings required by the application.
        /// </summary>
        /// <returns>The <see cref="RegionAdapterMappings"/> instance containing all the mappings.</returns>
        protected virtual RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            var regionAdapterMappings = ServiceLocator.Current.GetInstance<RegionAdapterMappings>();
            if (regionAdapterMappings != null)
            {
#if SILVERLIGHT
                regionAdapterMappings.RegisterMapping(typeof(TabControl), 
                                    ServiceLocator.Current.GetInstance<TabControlRegionAdapter>());
#endif
                regionAdapterMappings.RegisterMapping(typeof(Selector), ServiceLocator.Current.GetInstance<SelectorRegionAdapter>());
                regionAdapterMappings.RegisterMapping(typeof(ItemsControl), ServiceLocator.Current.GetInstance<ItemsControlRegionAdapter>());
                regionAdapterMappings.RegisterMapping(typeof(ContentControl), ServiceLocator.Current.GetInstance<ContentControlRegionAdapter>());
            }

            return regionAdapterMappings;
        }

        /// <summary>
        /// Configures the <see cref="IRegionBehaviorFactory"/>. This will be the list of default
        /// behaviors that will be added to a region. 
        /// </summary>
        /// <returns>
        /// The configure default region behaviors.
        /// </returns>
        protected virtual IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
        {
            var factory = ServiceLocator.Current.TryResolve<IRegionBehaviorFactory>();

            if (factory != null)
            {
                factory
                    .AddIfMissing(AutoPopulateRegionBehavior.BehaviorKey, typeof(AutoPopulateRegionBehavior));

                factory
                    .AddIfMissing(BindRegionContextToDependencyObjectBehavior.BehaviorKey, typeof(BindRegionContextToDependencyObjectBehavior));

                factory
                    .AddIfMissing(RegionActiveAwareBehavior.BehaviorKey, typeof(RegionActiveAwareBehavior));

                factory
                    .AddIfMissing(SyncRegionContextWithHostBehavior.BehaviorKey, typeof(SyncRegionContextWithHostBehavior));

                factory
                    .AddIfMissing(RegionManagerRegistrationBehavior.BehaviorKey, typeof(RegionManagerRegistrationBehavior));
            }

            return factory;
        }

        /// <summary>
        /// Initializes the modules. May be overwritten in a derived class to use a custom Modules Catalog
        /// </summary>
        protected virtual void InitializeModules()
        {
            IModuleManager manager;

            try
            {
                manager = this.Container.Resolve<IModuleManager>();
            }
            catch (ComponentNotFoundException ex)
            {
                if (ex.Message.Contains("IModuleCatalog"))
                {
                    throw new InvalidOperationException(Resources.NullModuleCatalogException);
                }

                throw;
            }

            manager.Run();
        }

        /// <summary>
        /// Returns the module catalog that will be used to initialize the modules.
        /// </summary>
        /// <remarks>
        /// When using the default initialization behavior, this method must be overwritten by a derived class.
        /// </remarks>
        /// <returns>An instance of <see cref="IModuleCatalog"/> that will be used to initialize the modules.</returns>
        protected virtual IModuleCatalog GetModuleCatalog()
        {
            return null;
        }

        /// <summary>
        /// Creates the <see cref="IWindsorContainer"/> that will be used as the default container.
        /// </summary>
        /// <returns>A new instance of <see cref="IWindsorContainer"/>.</returns>
        protected virtual IWindsorContainer CreateContainer()
        {
            return new WindsorContainer();
        }

        /// <summary>
        /// Registers a type in the container only if that type was not already registered.
        /// </summary>
        /// <typeparam name="TFromType">Source type</typeparam>
        /// <typeparam name="TToType">Target type</typeparam>
        /// <param name="registerAsSingleton">
        /// Registers the type as a singleton.
        /// </param>
        protected void RegisterTypeIfMissing<TFromType, TToType>(bool registerAsSingleton) where TToType : TFromType
        {
            var logger = this.LoggerFacade;

            if (this.Container.IsTypeRegistered<TFromType>())
            {
                logger.Debug(Resources.TypeMappingAlreadyRegistered, typeof(TFromType).Name);
            }
            else
            {
                this.Container.Register(Component
                                            .For<TFromType>()
                                            .ImplementedBy<TToType>()
                                            .LifeStyle.Is(registerAsSingleton
                                                              ? LifestyleType.Singleton
                                                              : LifestyleType.Transient));
            }
        }

        /// <summary>
        /// Creates the shell or main window of the application.
        /// </summary>
        /// <returns>The shell of the application.</returns>
        /// <remarks>
        /// If the returned instance is a <see cref="DependencyObject"/>, the
        /// <see cref="IWindsorContainer"/> will attach the default <seealso cref="IRegionManager"/> of
        /// the application in its <see cref="RegionManager.RegionManagerProperty"/> attached property
        /// in order to be able to add regions by using the <seealso cref="RegionManager.RegionNameProperty"/>
        /// attached property from XAML.
        /// </remarks>
        protected abstract DependencyObject CreateShell();
    }
}