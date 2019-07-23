using SimpleInjector;
using SimpleInjector.Advanced;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PCConfigurationTool.Core.Interfaces
{
    public interface IContainer
    {
        ContainerCollectionRegistrator Collections { get; }
        ContainerCollectionRegistrator Collection { get; }
        bool IsVerifying { get; }
        ContainerScope ContainerScope { get; }
        ContainerOptions Options { get; }

        event EventHandler<UnregisteredTypeEventArgs> ResolveUnregisteredType;
        event EventHandler<ExpressionBuiltEventArgs> ExpressionBuilt;
        event EventHandler<ExpressionBuildingEventArgs> ExpressionBuilding;

        void AddRegistration<TService>(Registration registration) where TService : class;
        void AddRegistration(Type serviceType, Registration registration);
        void Dispose();
        IEnumerable<object> GetAllInstances(Type serviceType);
        IEnumerable<TService> GetAllInstances<TService>() where TService : class;
        InstanceProducer[] GetCurrentRegistrations();
        TService GetInstance<TService>() where TService : class;
        object GetInstance(Type serviceType);
        InstanceProducer GetRegistration(Type serviceType, bool throwOnFailure);
        InstanceProducer GetRegistration(Type serviceType);
        InstanceProducer[] GetRootRegistrations();
        IEnumerable<Type> GetTypesToRegister(Type serviceType, IEnumerable<Assembly> assemblies);
        IEnumerable<Type> GetTypesToRegister(Type serviceType, params Assembly[] assemblies);
        IEnumerable<Type> GetTypesToRegister<TService>(params Assembly[] assemblies);
        IEnumerable<Type> GetTypesToRegister<TService>(IEnumerable<Assembly> assemblies);
        IEnumerable<Type> GetTypesToRegister(Type serviceType, IEnumerable<Assembly> assemblies, TypesToRegisterOptions options);
        void Register(Type serviceType, Type implementationType);
        void Register(Type concreteType);
        void Register(Type openGenericServiceType, Assembly assembly, Lifestyle lifestyle);
        void Register<TService>(Func<TService> instanceCreator) where TService : class;
        void Register(Type serviceType, Type implementationType, Lifestyle lifestyle);
        void Register(Type openGenericServiceType, IEnumerable<Type> implementationTypes);
        void Register(Type openGenericServiceType, IEnumerable<Assembly> assemblies, Lifestyle lifestyle);

        void Register<TService, TImplementation>(Lifestyle lifestyle)
            where TService : class
            where TImplementation : class, TService;
        //
        // Summary:
        //     Registers all concrete, non-generic, public and internal types in the given set
        //     of assemblies that implement the given openGenericServiceType with container's
        //     default lifestyle (which is transient by default). SimpleInjector.TypesToRegisterOptions.IncludeDecorators
        //     and SimpleInjector.TypesToRegisterOptions.IncludeGenericTypeDefinitions will
        //     be excluded from registration, while SimpleInjector.TypesToRegisterOptions.IncludeComposites
        //     are included.
        //
        // Parameters:
        //   openGenericServiceType:
        //     The definition of the open generic type.
        //
        //   assemblies:
        //     A list of assemblies that will be searched.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the arguments contain a null reference (Nothing in VB).
        //
        //   T:System.ArgumentException:
        //     Thrown when openGenericServiceType is not an open generic type.
        //
        //   T:System.InvalidOperationException:
        //     Thrown when the given set of assemblies contain multiple types that implement
        //     the same closed generic version of the given openGenericServiceType.
        void Register(Type openGenericServiceType, IEnumerable<Assembly> assemblies);
        //
        // Summary:
        //     Registers all concrete, non-generic, public and internal types in the given set
        //     of assemblies that implement the given openGenericServiceType with container's
        //     default lifestyle (which is transient by default). SimpleInjector.TypesToRegisterOptions.IncludeDecorators
        //     and SimpleInjector.TypesToRegisterOptions.IncludeGenericTypeDefinitions will
        //     be excluded from registration, while SimpleInjector.TypesToRegisterOptions.IncludeComposites
        //     are included.
        //
        // Parameters:
        //   openGenericServiceType:
        //     The definition of the open generic type.
        //
        //   assemblies:
        //     A list of assemblies that will be searched.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the arguments contain a null reference (Nothing in VB).
        //
        //   T:System.ArgumentException:
        //     Thrown when openGenericServiceType is not an open generic type.
        //
        //   T:System.InvalidOperationException:
        //     Thrown when the given set of assemblies contain multiple types that implement
        //     the same closed generic version of the given openGenericServiceType.
        void Register(Type openGenericServiceType, params Assembly[] assemblies);
        //
        // Summary:
        //     Registers the specified delegate that allows returning instances of serviceType.
        //
        // Parameters:
        //   serviceType:
        //     The base type or interface to register.
        //
        //   instanceCreator:
        //     The delegate that will be used for creating new instances.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when either serviceType or instanceCreator are null references (Nothing
        //     in VB).
        //
        //   T:System.ArgumentException:
        //     Thrown when serviceType represents an open generic type.
        //
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered, or when
        //     an the serviceType has already been registered.
        //
        // Remarks:
        //     This method uses the container's SimpleInjector.ContainerOptions.LifestyleSelectionBehavior
        //     to select the exact lifestyle for the specified type. By default this will be
        //     SimpleInjector.Lifestyle.Transient.
        void Register(Type serviceType, Func<object> instanceCreator);
        //
        // Summary:
        //     Registers that a new instance of TImplementation will be returned every time
        //     a TService is requested (transient).
        //
        // Type parameters:
        //   TService:
        //     The interface or base type that can be used to retrieve the instances.
        //
        //   TImplementation:
        //     The concrete type that will be registered.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered, or when
        //     an the TService has already been registered.
        //
        //   T:System.ArgumentException:
        //     Thrown when the given TImplementation type is not a type that can be created
        //     by the container.
        //
        // Remarks:
        //     This method uses the container's SimpleInjector.ContainerOptions.LifestyleSelectionBehavior
        //     to select the exact lifestyle for the specified type. By default this will be
        //     SimpleInjector.Lifestyle.Transient.
        void Register<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService;
        //
        // Summary:
        //     Registers the specified delegate instanceCreator that will produce instances
        //     of type serviceType and will be returned when an instance of type serviceType
        //     is requested. The delegate is expected to produce new instances on each call.
        //     The instances are cached according to the supplied lifestyle.
        //
        // Parameters:
        //   serviceType:
        //     The interface or base type that can be used to retrieve instances.
        //
        //   instanceCreator:
        //     The delegate that allows building or creating new instances.
        //
        //   lifestyle:
        //     The lifestyle that specifies how the returned instance will be cached.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered, or when
        //     the serviceType has already been registered.
        //
        //   T:System.ArgumentNullException:
        //     Thrown when one of the supplied arguments is a null reference (Nothing in VB).
        void Register(Type serviceType, Func<object> instanceCreator, Lifestyle lifestyle);
        //
        // Summary:
        //     Registers that a new instance of TConcrete will be returned every time it is
        //     requested (transient).
        //
        // Type parameters:
        //   TConcrete:
        //     The concrete type that will be registered.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered, or when
        //     an the TConcrete has already been registered.
        //
        //   T:System.ArgumentException:
        //     Thrown when the TConcrete is a type that can not be created by the container.
        //
        // Remarks:
        //     This method uses the container's SimpleInjector.ContainerOptions.LifestyleSelectionBehavior
        //     to select the exact lifestyle for the specified type. By default this will be
        //     SimpleInjector.Lifestyle.Transient.
        void Register<TConcrete>() where TConcrete : class;
        //
        // Summary:
        //     Registers all supplied implementationTypes based on the closed-generic version
        //     of the given openGenericServiceType with the given lifestyle.
        //
        // Parameters:
        //   openGenericServiceType:
        //     The definition of the open generic type.
        //
        //   implementationTypes:
        //     A list types to be registered.
        //
        //   lifestyle:
        //     The lifestyle to register instances with.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the arguments contain a null reference (Nothing in VB).
        //
        //   T:System.ArgumentException:
        //     Thrown when openGenericServiceType is not an open generic type or when one of
        //     the supplied types from the implementationTypes collection does not derive from
        //     openGenericServiceType.
        //
        //   T:System.InvalidOperationException:
        //     Thrown when the given set of implementationTypes contain multiple types that
        //     implement the same closed generic version of the given openGenericServiceType.
        void Register(Type openGenericServiceType, IEnumerable<Type> implementationTypes, Lifestyle lifestyle);
        //
        // Summary:
        //     Registers that an instance of TConcrete will be returned when it is requested.
        //     The instance is cached according to the supplied lifestyle.
        //
        // Parameters:
        //   lifestyle:
        //     The lifestyle that specifies how the returned instance will be cached.
        //
        // Type parameters:
        //   TConcrete:
        //     The concrete type that will be registered.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered, or when
        //     an the TConcrete has already been registered.
        //
        //   T:System.ArgumentException:
        //     Thrown when the TConcrete is a type that can not be created by the container.
        void Register<TConcrete>(Lifestyle lifestyle) where TConcrete : class;
        //
        // Summary:
        //     Registers the specified delegate instanceCreator that will produce instances
        //     of type TService and will be returned when an instance of type TService is requested.
        //     The delegate is expected to produce new instances on each call. The instances
        //     are cached according to the supplied lifestyle.
        //
        // Parameters:
        //   instanceCreator:
        //     The delegate that allows building or creating new instances.
        //
        //   lifestyle:
        //     The lifestyle that specifies how the returned instance will be cached.
        //
        // Type parameters:
        //   TService:
        //     The interface or base type that can be used to retrieve instances.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered, or when
        //     the TService has already been registered.
        //
        //   T:System.ArgumentNullException:
        //     Thrown when one of the supplied arguments is a null reference (Nothing in VB).
        void Register<TService>(Func<TService> instanceCreator, Lifestyle lifestyle) where TService : class;
        //
        // Summary:
        //     Registers a collection of singleton elements of type TService.
        //
        // Parameters:
        //   singletons:
        //     The collection to register.
        //
        // Type parameters:
        //   TService:
        //     The interface or base type that can be used to retrieve instances.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered, or when
        //     a singletons for TService has already been registered.
        //
        //   T:System.ArgumentNullException:
        //     Thrown when singletons is a null reference.
        //
        //   T:System.ArgumentException:
        //     Thrown when one of the elements of singletons is a null reference.
        [Obsolete("Please use Container.Collection.Register instead. Will be treated as an error from version 5.0. Will be removed in version 6.0.", false)]
          void RegisterCollection<TService>(params TService[] singletons) where TService : class;
        //
        // Summary:
        //     Registers a collection of registrations, whose instances will be resolved lazily
        //     each time the resolved collection of serviceType is enumerated. The underlying
        //     collection is a stream that will return individual instances based on their specific
        //     registered lifestyle, for each call to System.Collections.Generic.IEnumerator`1.Current.
        //     The order in which the types appear in the collection is the exact same order
        //     that the items were supplied to this method, i.e the resolved collection is deterministic.
        //
        // Parameters:
        //   serviceType:
        //     The base type or interface for elements in the collection. This can be an a non-generic
        //     type, closed generic type or generic type definition.
        //
        //   registrations:
        //     The collection of SimpleInjector.Registration objects whose instances will be
        //     requested from the container.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the supplied arguments is a null reference (Nothing in VB).
        //
        //   T:System.ArgumentException:
        //     Thrown when registrations contains a null (Nothing in VB) element or when serviceType
        //     is not assignable from any of the service types supplied by the given registrations
        //     instances.
        [Obsolete("Please use Container.Collection.Register instead. Will be treated as an error from version 5.0. Will be removed in version 6.0.", false)]
          void RegisterCollection(Type serviceType, IEnumerable<Registration> registrations);
        //
        // Summary:
        //     Registers a dynamic (container uncontrolled) collection of elements of type serviceType.
        //     A call to SimpleInjector.Container.GetAllInstances``1 will return the containerUncontrolledCollection
        //     itself, and updates to the collection will be reflected in the result. If updates
        //     are allowed, make sure the collection can be iterated safely if you're running
        //     a multi-threaded application.
        //
        // Parameters:
        //   serviceType:
        //     The base type or interface for elements in the collection.
        //
        //   containerUncontrolledCollection:
        //     The collection of items to register.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the supplied arguments is a null reference (Nothing in VB).
        //
        //   T:System.ArgumentException:
        //     Thrown when serviceType represents an open generic type.
        [Obsolete("Please use Container.Collection.Register instead. Will be treated as an error from version 5.0. Will be removed in version 6.0.", false)]
          void RegisterCollection(Type serviceType, IEnumerable containerUncontrolledCollection);
        //
        // Summary:
        //     Registers a collection of serviceTypes, whose instances will be resolved lazily
        //     each time the resolved collection of serviceType is enumerated. The underlying
        //     collection is a stream that will return individual instances based on their specific
        //     registered lifestyle, for each call to System.Collections.Generic.IEnumerator`1.Current.
        //     The order in which the types appear in the collection is the exact same order
        //     that the items were supplied to this method, i.e the resolved collection is deterministic.
        //
        // Parameters:
        //   serviceType:
        //     The base type or interface for elements in the collection.
        //
        //   serviceTypes:
        //     The collection of System.Type objects whose instances will be requested from
        //     the container.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the supplied arguments is a null reference (Nothing in VB).
        //
        //   T:System.ArgumentException:
        //     Thrown when serviceTypes contains a null (Nothing in VB) element, a generic type
        //     definition, or the serviceType is not assignable from one of the given serviceTypes
        //     elements.
        [Obsolete("Please use Container.Collection.Register instead. Will be treated as an error from version 5.0. Will be removed in version 6.0.", false)]
          void RegisterCollection(Type serviceType, IEnumerable<Type> serviceTypes);
        //
        // Summary:
        //     Registers all concrete, non-generic types (both public and internal) that are
        //     defined in the given set of assemblies and that implement the given TService
        //     with a default lifestyle and register them as a collection of TService. Unless
        //     overridden using a custom SimpleInjector.ContainerOptions.LifestyleSelectionBehavior,
        //     the default lifestyle is SimpleInjector.Lifestyle.Transient.
        //
        // Parameters:
        //   assemblies:
        //     A list of assemblies that will be searched.
        //
        // Type parameters:
        //   TService:
        //     The element type of the collections to register. This can be either a non-generic,
        //     closed-generic or open-generic type.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the supplied arguments contain a null reference (Nothing in
        //     VB).
        [Obsolete("Please use Container.Collection.Register instead. Will be treated as an error from version 5.0. Will be removed in version 6.0.", false)]
          void RegisterCollection<TService>(IEnumerable<Assembly> assemblies) where TService : class;
        //
        // Summary:
        //     Registers all concrete, non-generic types (both public and internal) that are
        //     defined in the given set of assemblies and that implement the given serviceType
        //     with a default lifestyle and register them as a collection of serviceType. Unless
        //     overridden using a custom SimpleInjector.ContainerOptions.LifestyleSelectionBehavior,
        //     the default lifestyle is SimpleInjector.Lifestyle.Transient. SimpleInjector.TypesToRegisterOptions.IncludeComposites,
        //     SimpleInjector.TypesToRegisterOptions.IncludeDecorators and SimpleInjector.TypesToRegisterOptions.IncludeGenericTypeDefinitions
        //     will be excluded from registration.
        //
        // Parameters:
        //   serviceType:
        //     The element type of the collections to register. This can be either a non-generic,
        //     closed-generic or open-generic type.
        //
        //   assemblies:
        //     A list of assemblies that will be searched.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the supplied arguments contain a null reference (Nothing in
        //     VB).
        [Obsolete("Please use Container.Collection.Register instead. Will be treated as an error from version 5.0. Will be removed in version 6.0.", false)]
          void RegisterCollection(Type serviceType, params Assembly[] assemblies);
        //
        // Summary:
        //     Registers all concrete, non-generic types (both public and internal) that are
        //     defined in the given set of assemblies and that implement the given serviceType
        //     with a default lifestyle and register them as a collection of serviceType. Unless
        //     overridden using a custom SimpleInjector.ContainerOptions.LifestyleSelectionBehavior,
        //     the default lifestyle is SimpleInjector.Lifestyle.Transient. SimpleInjector.TypesToRegisterOptions.IncludeComposites,
        //     SimpleInjector.TypesToRegisterOptions.IncludeDecorators and SimpleInjector.TypesToRegisterOptions.IncludeGenericTypeDefinitions
        //     will be excluded from registration.
        //
        // Parameters:
        //   serviceType:
        //     The element type of the collections to register. This can be either a non-generic,
        //     closed-generic or open-generic type.
        //
        //   assemblies:
        //     A list of assemblies that will be searched.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the supplied arguments contain a null reference (Nothing in
        //     VB).
        [Obsolete("Please use Container.Collection.Register instead. Will be treated as an error from version 5.0. Will be removed in version 6.0.", false)]
          void RegisterCollection(Type serviceType, IEnumerable<Assembly> assemblies);
        //
        // Summary:
        //     Registers a dynamic (container-uncontrolled) collection of elements of type TService.
        //     A call to SimpleInjector.Container.GetAllInstances``1 will return the containerUncontrolledCollection
        //     itself, and updates to the collection will be reflected in the result. If updates
        //     are allowed, make sure the collection can be iterated safely if you're running
        //     a multi-threaded application.
        //
        // Parameters:
        //   containerUncontrolledCollection:
        //     The container-uncontrolled collection to register.
        //
        // Type parameters:
        //   TService:
        //     The interface or base type that can be used to retrieve instances.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered, or when
        //     a containerUncontrolledCollection for TService has already been registered.
        //
        //   T:System.ArgumentNullException:
        //     Thrown when containerUncontrolledCollection is a null reference.
        [Obsolete("Please use Container.Collection.Register instead. Will be treated as an error from version 5.0. Will be removed in version 6.0.", false)]
          void RegisterCollection<TService>(IEnumerable<TService> containerUncontrolledCollection) where TService : class;
        //
        // Summary:
        //     Registers a collection of registrations, whose instances will be resolved lazily
        //     each time the resolved collection of TService is enumerated. The underlying collection
        //     is a stream that will return individual instances based on their specific registered
        //     lifestyle, for each call to System.Collections.Generic.IEnumerator`1.Current.
        //     The order in which the types appear in the collection is the exact same order
        //     that the items were supplied to this method, i.e the resolved collection is deterministic.
        //
        // Parameters:
        //   registrations:
        //     The collection of SimpleInjector.Registration objects whose instances will be
        //     requested from the container.
        //
        // Type parameters:
        //   TService:
        //     The base type or interface for elements in the collection.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the supplied arguments is a null reference (Nothing in VB).
        //
        //   T:System.ArgumentException:
        //     Thrown when registrations contains a null (Nothing in VB) element or when TService
        //     is not assignable from any of the service types supplied by the given registrations
        //     instances.
        [Obsolete("Please use Container.Collection.Register instead. Will be treated as an error from version 5.0. Will be removed in version 6.0.", false)]
          void RegisterCollection<TService>(IEnumerable<Registration> registrations) where TService : class;
        //
        // Summary:
        //     Registers a collection of serviceTypes, whose instances will be resolved lazily
        //     each time the resolved collection of TService is enumerated. The underlying collection
        //     is a stream that will return individual instances based on their specific registered
        //     lifestyle, for each call to System.Collections.Generic.IEnumerator`1.Current.
        //     The order in which the types appear in the collection is the exact same order
        //     that the items were supplied to this method, i.e the resolved collection is deterministic.
        //
        // Parameters:
        //   serviceTypes:
        //     The collection of System.Type objects whose instances will be requested from
        //     the container.
        //
        // Type parameters:
        //   TService:
        //     The base type or interface for elements in the collection.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when serviceTypes is a null reference (Nothing in VB).
        //
        //   T:System.ArgumentException:
        //     Thrown when serviceTypes contains a null (Nothing in VB) element, a generic type
        //     definition, or the TService is not assignable from one of the given serviceTypes
        //     elements.
        [Obsolete("Please use Container.Collection.Register instead. Will be treated as an error from version 5.0. Will be removed in version 6.0.", false)]
          void RegisterCollection<TService>(IEnumerable<Type> serviceTypes) where TService : class;
        //
        // Summary:
        //     Conditionally registers that registration will be used every time a TService
        //     requested and where the supplied predicate returns true. The predicate will only
        //     be evaluated a finite number of times; the predicate is unsuited for making decisions
        //     based on runtime conditions.
        //
        // Parameters:
        //   registration:
        //     The SimpleInjector.Registration instance to register.
        //
        //   predicate:
        //     The predicate that determines whether the registration can be applied for the
        //     requested service type. This predicate can be used to build a fallback mechanism
        //     where multiple registrations for the same service type are made. Note that the
        //     predicate will be called a finite number of times and its result will be cached
        //     for the lifetime of the container. It can't be used for selecting a type based
        //     on runtime conditions.
        //
        // Type parameters:
        //   TService:
        //     The base type or interface to register. This can be an open-generic type.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the arguments is a null reference (Nothing in VB).
        //
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered.
          void RegisterConditional<TService>(Registration registration, Predicate<PredicateContext> predicate);
        //
        // Summary:
        //     Conditionally registers that an instance of implementationType will be returned
        //     every time a serviceType is requested and where the supplied predicate returns
        //     true. The instance is cached according to the supplied lifestyle. The predicate
        //     will only be evaluated a finite number of times; the predicate is unsuited for
        //     making decisions based on runtime conditions.
        //
        // Parameters:
        //   serviceType:
        //     The base type or interface to register. This can be an open-generic type.
        //
        //   implementationType:
        //     The actual type that will be returned when requested.
        //
        //   lifestyle:
        //     The lifestyle that defines how returned instances are cached.
        //
        //   predicate:
        //     The predicate that determines whether the implementationType can be applied for
        //     the requested service type. This predicate can be used to build a fallback mechanism
        //     where multiple registrations for the same service type are made. Note that the
        //     predicate will be called a finite number of times and its result will be cached
        //     for the lifetime of the container. It can't be used for selecting a type based
        //     on runtime conditions.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the arguments is a null reference (Nothing in VB).
        //
        //   T:System.ArgumentException:
        //     Thrown when serviceType and implementationType are not a generic type or when
        //     serviceType is a partially-closed generic type.
        //
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered.
          void RegisterConditional(Type serviceType, Type implementationType, Lifestyle lifestyle, Predicate<PredicateContext> predicate);
        //
        // Summary:
        //     Conditionally registers that registration will be used every time a serviceType
        //     is requested and where the supplied predicate returns true. The predicate will
        //     only be evaluated a finite number of times; the predicate is unsuited for making
        //     decisions based on runtime conditions.
        //
        // Parameters:
        //   serviceType:
        //     The base type or interface to register. This can be an open-generic type.
        //
        //   registration:
        //     The SimpleInjector.Registration instance to register.
        //
        //   predicate:
        //     The predicate that determines whether the registration can be applied for the
        //     requested service type. This predicate can be used to build a fallback mechanism
        //     where multiple registrations for the same service type are made. Note that the
        //     predicate will be called a finite number of times and its result will be cached
        //     for the lifetime of the container. It can't be used for selecting a type based
        //     on runtime conditions.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the arguments is a null reference (Nothing in VB).
        //
        //   T:System.ArgumentException:
        //     Thrown when serviceType is open generic or registration is not assignable to
        //     serviceType.
        //
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered.
          void RegisterConditional(Type serviceType, Registration registration, Predicate<PredicateContext> predicate);
        //
        // Summary:
        //     Conditionally registers that a new instance of TImplementation will be returned
        //     every time a TService is requested (transient) and where the supplied predicate
        //     returns true. The predicate will only be evaluated a finite number of times;
        //     the predicate is unsuited for making decisions based on runtime conditions.
        //
        // Parameters:
        //   predicate:
        //     The predicate that determines whether the TImplementation can be applied for
        //     the requested service type. This predicate can be used to build a fallback mechanism
        //     where multiple registrations for the same service type are made. Note that the
        //     predicate will be called a finite number of times and its result will be cached
        //     for the lifetime of the container. It can't be used for selecting a type based
        //     on runtime conditions.
        //
        // Type parameters:
        //   TService:
        //     The interface or base type that can be used to retrieve the instances.
        //
        //   TImplementation:
        //     The concrete type that will be registered.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the arguments is a null reference (Nothing in VB).
        //
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered.
        //
        // Remarks:
        //     This method uses the container's SimpleInjector.ContainerOptions.LifestyleSelectionBehavior
        //     to select the exact lifestyle for the specified type. By default this will be
        //     SimpleInjector.Lifestyle.Transient.
          void RegisterConditional<TService, TImplementation>(Predicate<PredicateContext> predicate)
            where TService : class
            where TImplementation : class, TService;
        //
        // Summary:
        //     Conditionally registers that an instance of TImplementation will be returned
        //     every time a TService is requested and where the supplied predicate returns true.
        //     The instance is cached according to the supplied lifestyle. The predicate will
        //     only be evaluated a finite number of times; the predicate is unsuited for making
        //     decisions based on runtime conditions.
        //
        // Parameters:
        //   lifestyle:
        //     The lifestyle that specifies how the returned instance will be cached.
        //
        //   predicate:
        //     The predicate that determines whether the TImplementation can be applied for
        //     the requested service type. This predicate can be used to build a fallback mechanism
        //     where multiple registrations for the same service type are made. Note that the
        //     predicate will be called a finite number of times and its result will be cached
        //     for the lifetime of the container. It can't be used for selecting a type based
        //     on runtime conditions.
        //
        // Type parameters:
        //   TService:
        //     The interface or base type that can be used to retrieve the instances.
        //
        //   TImplementation:
        //     The concrete type that will be registered.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the arguments is a null reference (Nothing in VB).
        //
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered.
          void RegisterConditional<TService, TImplementation>(Lifestyle lifestyle, Predicate<PredicateContext> predicate)
            where TService : class
            where TImplementation : class, TService;
        //
        // Summary:
        //     Conditionally registers that a new instance of implementationType will be returned
        //     every time a serviceType is requested (transient) and where the supplied predicate
        //     returns true. The predicate will only be evaluated a finite number of times;
        //     the predicate is unsuited for making decisions based on runtime conditions.
        //
        // Parameters:
        //   serviceType:
        //     The base type or interface to register. This can be an open-generic type.
        //
        //   implementationType:
        //     The actual type that will be returned when requested.
        //
        //   predicate:
        //     The predicate that determines whether the implementationType can be applied for
        //     the requested service type. This predicate can be used to build a fallback mechanism
        //     where multiple registrations for the same service type are made. Note that the
        //     predicate will be called a finite number of times and its result will be cached
        //     for the lifetime of the container. It can't be used for selecting a type based
        //     on runtime conditions.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the arguments is a null reference (Nothing in VB).
        //
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered.
        //
        // Remarks:
        //     This method uses the container's SimpleInjector.ContainerOptions.LifestyleSelectionBehavior
        //     to select the exact lifestyle for the specified type. By default this will be
        //     SimpleInjector.Lifestyle.Transient.
          void RegisterConditional(Type serviceType, Type implementationType, Predicate<PredicateContext> predicate);
        //
        // Summary:
        //     Conditionally registers that an instance of the type returned from implementationTypeFactory
        //     will be returned every time a serviceType is requested and where the supplied
        //     predicate returns true. The instance is cached according to the supplied lifestyle.
        //     Both the predicate and implementationTypeFactory will only be evaluated a finite
        //     number of times; they unsuited for making decisions based on runtime conditions.
        //
        // Parameters:
        //   serviceType:
        //     The base type or interface to register. This can be an open-generic type.
        //
        //   implementationTypeFactory:
        //     A factory that allows building Type objects that define the implementation type
        //     to inject, based on the given contextual information. The delegate is allowed
        //     to return (partially) open-generic types.
        //
        //   lifestyle:
        //     The lifestyle that defines how returned instances are cached.
        //
        //   predicate:
        //     The predicate that determines whether the registration can be applied for the
        //     requested service type. This predicate can be used to build a fallback mechanism
        //     where multiple registrations for the same service type are made. Note that the
        //     predicate will be called a finite number of times and its result will be cached
        //     for the lifetime of the container. It can't be used for selecting a type based
        //     on runtime conditions.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the arguments is a null reference (Nothing in VB).
        //
        //   T:System.ArgumentException:
        //     Thrown when serviceType is a partially-closed generic type.
        //
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered.
          void RegisterConditional(Type serviceType, Func<TypeFactoryContext, Type> implementationTypeFactory, Lifestyle lifestyle, Predicate<PredicateContext> predicate);
        //
        // Summary:
        //     Ensures that the supplied decoratorType decorator is returned when the supplied
        //     predicate returns true, wrapping the original registered serviceType, by injecting
        //     that service type into the constructor of the supplied decoratorType. Multiple
        //     decorators may be applied to the same serviceType. Decorators can be applied
        //     to both open, closed, and non-generic service types. By default, a new decoratorType
        //     instance will be returned on each request (according the SimpleInjector.Lifestyle.Transient
        //     lifestyle), independently of the lifestyle of the wrapped service.
        //
        // Parameters:
        //   serviceType:
        //     The definition of the (possibly open generic) service type that will be wrapped
        //     by the given decoratorType.
        //
        //   decoratorType:
        //     The definition of the (possibly open generic) decorator type that will be used
        //     to wrap the original service type.
        //
        //   predicate:
        //     The predicate that determines whether the decoratorType must be applied to a
        //     service type.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the arguments is a null reference.
        //
        //   T:System.ArgumentException:
        //     Thrown when decoratorType does not inherit from or implement serviceType, when
        //     decoratorType does not have a single public constructor, or when decoratorType
        //     does not contain a constructor that has exactly one argument of type serviceType
        //     or System.Func`1 where T is serviceType.
        //
        // Remarks:
        //     This method uses the container's SimpleInjector.ContainerOptions.LifestyleSelectionBehavior
        //     to select the exact lifestyle for the specified type. By default this will be
        //     SimpleInjector.Lifestyle.Transient.
        //     The RegisterDecorator method works by hooking onto the container's SimpleInjector.Container.ExpressionBuilt
        //     event. This event fires after the SimpleInjector.Container.ResolveUnregisteredType
        //     event, which allows decoration of types that are resolved using unregistered
        //     type resolution.
        //     Multiple decorators can be applied to the same service type. The order in which
        //     they are registered is the order they get applied in. This means that the decorator
        //     that gets registered first, gets applied first, which means that the next registered
        //     decorator, will wrap the first decorator, which wraps the original service type.
        //     Constructor injection will be used on that type, and although it may have many
        //     constructor arguments, it must have exactly one argument of the type of serviceType,
        //     or an argument of type System.Func`1 where TResult is serviceType. An exception
        //     will be thrown when this is not the case.
        //     The registered decoratorType may have a constructor with an argument of type
        //     System.Func`1 where T is serviceType. In this case, the will not inject the decorated
        //     serviceType itself into the decoratorType instance, but it will inject a System.Func`1
        //     that allows creating instances of the decorated type, according to the lifestyle
        //     of that type. This enables more advanced scenarios, such as executing the decorated
        //     types on a different thread, or executing decorated instance within a certain
        //     scope (such as a lifetime scope).
          void RegisterDecorator(Type serviceType, Type decoratorType, Predicate<DecoratorPredicateContext> predicate);
        //
        // Summary:
        //     Ensures that the decorator type that is returned from decoratorTypeFactory is
        //     supplied when the supplied predicate returns true and cached with the given lifestyle,
        //     wrapping the original registered serviceType, by injecting that service type
        //     into the constructor of the decorator type that is returned by the supplied decoratorTypeFactory.
        //     Multiple decorators may be applied to the same serviceType. Decorators can be
        //     applied to both open, closed, and non-generic service types.
        //
        // Parameters:
        //   serviceType:
        //     The definition of the (possibly open generic) service type that will be wrapped
        //     by the decorator type that is returned from decoratorTypeFactory.
        //
        //   decoratorTypeFactory:
        //     A factory that allows building Type objects that define the decorators to inject,
        //     based on the given contextual information. The delegate is allowed to return
        //     (partially) open-generic types.
        //
        //   lifestyle:
        //     The lifestyle that specifies how the returned decorator will be cached.
        //
        //   predicate:
        //     The predicate that determines whether the decorator must be applied to a service
        //     type.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the arguments is a null reference.
        //
        // Remarks:
        //     The types returned from the decoratorTypeFactory may be non-generic, closed-generic,
        //     open-generic and even partially-closed generic. The container will try to fill
        //     in the generic parameters based on the resolved service type.
        //     The RegisterDecorator method works by hooking onto the container's SimpleInjector.Container.ExpressionBuilt
        //     event. This event fires after the SimpleInjector.Container.ResolveUnregisteredType
        //     event, which allows decoration of types that are resolved using unregistered
        //     type resolution.
        //     Multiple decorators can be applied to the same service type. The order in which
        //     they are registered is the order they get applied in. This means that the decorator
        //     that gets registered first, gets applied first, which means that the next registered
        //     decorator, will wrap the first decorator, which wraps the original service type.
        //     Constructor injection will be used on that type, and although it may have many
        //     constructor arguments, it must have exactly one argument of the type of serviceType,
        //     or an argument of type System.Func`1 where TResult is serviceType. An exception
        //     will be thrown when this is not the case.
        //     The type returned from decoratorTypeFactory may have a constructor with an argument
        //     of type System.Func`1 where T is serviceType. In this case, the library will
        //     not inject the decorated serviceType itself into the decorator instance, but
        //     it will inject a System.Func`1 that allows creating instances of the decorated
        //     type, according to the lifestyle of that type. This enables more advanced scenarios,
        //     such as executing the decorated types on a different thread, or executing decorated
        //     instance within a certain scope (such as a lifetime scope).
          void RegisterDecorator(Type serviceType, Func<DecoratorPredicateContext, Type> decoratorTypeFactory, Lifestyle lifestyle, Predicate<DecoratorPredicateContext> predicate);
        //
        // Summary:
        //     Ensures that the supplied decoratorType decorator is returned when the supplied
        //     predicate returns true and cached with the given lifestyle, wrapping the original
        //     registered serviceType, by injecting that service type into the constructor of
        //     the supplied decoratorType. Multiple decorators may be applied to the same serviceType.
        //     Decorators can be applied to both open, closed, and non-generic service types.
        //
        // Parameters:
        //   serviceType:
        //     The definition of the (possibly open generic) service type that will be wrapped
        //     by the given decoratorType.
        //
        //   decoratorType:
        //     The definition of the (possibly open generic) decorator type that will be used
        //     to wrap the original service type.
        //
        //   lifestyle:
        //     The lifestyle that specifies how the returned decorator will be cached.
        //
        //   predicate:
        //     The predicate that determines whether the decoratorType must be applied to a
        //     service type.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the arguments is a null reference.
        //
        //   T:System.ArgumentException:
        //     Thrown when serviceType is not an open generic type, when decoratorType does
        //     not inherit from or implement serviceType, when decoratorType does not have a
        //     single public constructor, or when decoratorType does not contain a constructor
        //     that has exactly one argument of type serviceType or System.Func`1 where T is
        //     serviceType.
        //
        // Remarks:
        //     The RegisterDecorator method works by hooking onto the container's SimpleInjector.Container.ExpressionBuilt
        //     event. This event fires after the SimpleInjector.Container.ResolveUnregisteredType
        //     event, which allows decoration of types that are resolved using unregistered
        //     type resolution.
        //     Multiple decorators can be applied to the same service type. The order in which
        //     they are registered is the order they get applied in. This means that the decorator
        //     that gets registered first, gets applied first, which means that the next registered
        //     decorator, will wrap the first decorator, which wraps the original service type.
        //     Constructor injection will be used on that type, and although it may have many
        //     constructor arguments, it must have exactly one argument of the type of serviceType,
        //     or an argument of type System.Func`1 where TResult is serviceType. An exception
        //     will be thrown when this is not the case.
        //     The registered decoratorType may have a constructor with an argument of type
        //     System.Func`1 where T is serviceType. In this case, the will not inject the decorated
        //     serviceType itself into the decoratorType instance, but it will inject a System.Func`1
        //     that allows creating instances of the decorated type, according to the lifestyle
        //     of that type. This enables more advanced scenarios, such as executing the decorated
        //     types on a different thread, or executing decorated instance within a certain
        //     scope (such as a lifetime scope).
          void RegisterDecorator(Type serviceType, Type decoratorType, Lifestyle lifestyle, Predicate<DecoratorPredicateContext> predicate);
        //
        // Summary:
        //     Ensures that the supplied decoratorType decorator is returned, wrapping the original
        //     registered serviceType, by injecting that service type into the constructor of
        //     the supplied decoratorType. Multiple decorators may be applied to the same serviceType.
        //     Decorators can be applied to both open, closed, and non-generic service types.
        //     By default, a new decoratorType instance will be returned on each request (according
        //     the SimpleInjector.Lifestyle.Transient lifestyle), independently of the lifestyle
        //     of the wrapped service.
        //
        // Parameters:
        //   serviceType:
        //     The (possibly open generic) service type that will be wrapped by the given decoratorType.
        //
        //   decoratorType:
        //     The (possibly the open generic) decorator type that will be used to wrap the
        //     original service type.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the arguments is a null reference.
        //
        //   T:System.ArgumentException:
        //     Thrown when serviceType is not an open generic type, when decoratorType does
        //     not inherit from or implement serviceType, when decoratorType does not have a
        //     single public constructor, or when decoratorType does not contain a constructor
        //     that has exactly one argument of type serviceType or System.Func`1 where T is
        //     serviceType.
        //
        // Remarks:
        //     This method uses the container's SimpleInjector.ContainerOptions.LifestyleSelectionBehavior
        //     to select the exact lifestyle for the specified type. By default this will be
        //     SimpleInjector.Lifestyle.Transient.
        //     The RegisterDecorator method works by hooking onto the container's SimpleInjector.Container.ExpressionBuilt
        //     event. This event fires after the SimpleInjector.Container.ResolveUnregisteredType
        //     event, which allows decoration of types that are resolved using unregistered
        //     type resolution.
        //     Multiple decorators can be applied to the same service type. The order in which
        //     they are registered is the order they get applied in. This means that the decorator
        //     that gets registered first, gets applied first, which means that the next registered
        //     decorator, will wrap the first decorator, which wraps the original service type.
        //     Constructor injection will be used on that type, and although it may have many
        //     constructor arguments, it must have exactly one argument of the type of serviceType,
        //     or an argument of type System.Func`1 where TResult is serviceType. An exception
        //     will be thrown when this is not the case.
        //     The registered decoratorType may have a constructor with an argument of type
        //     System.Func`1 where T is serviceType. In this case, an decorated instance will
        //     not injected into the decoratorType, but it will inject a System.Func`1 that
        //     allows creating instances of the decorated type, according to the lifestyle of
        //     that type. This enables more advanced scenarios, such as executing the decorated
        //     types on a different thread, or executing decorated instance within a certain
        //     scope (such as a lifetime scope).
          void RegisterDecorator(Type serviceType, Type decoratorType);
        //
        // Summary:
        //     Ensures that the supplied TDecorator decorator is returned and cached with the
        //     given lifestyle, wrapping the original registered TService, by injecting that
        //     service type into the constructor of the supplied TDecorator. Multiple decorators
        //     may be applied to the same TService. Decorators can be applied to both open,
        //     closed, and non-generic service types.
        //
        // Parameters:
        //   lifestyle:
        //     The lifestyle that specifies how the returned decorator will be cached.
        //
        // Type parameters:
        //   TService:
        //     The service type that will be wrapped by the given TDecorator.
        //
        //   TDecorator:
        //     The decorator type that will be used to wrap the original service type.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the arguments is a null reference.
        //
        //   T:System.ArgumentException:
        //     Thrown when TDecorator does not have a single public constructor, or when TDecorator
        //     does not contain a constructor that has exactly one argument of type TService
        //     or System.Func`1 where T is TService.
        //
        // Remarks:
        //     The RegisterDecorator method works by hooking onto the container's SimpleInjector.Container.ExpressionBuilt
        //     event. This event fires after the SimpleInjector.Container.ResolveUnregisteredType
        //     event, which allows decoration of types that are resolved using unregistered
        //     type resolution.
        //     Multiple decorators can be applied to the same service type. The order in which
        //     they are registered is the order they get registered. This means that the decorator
        //     that gets registered first, gets applied first, which means that the next registered
        //     decorator, will wrap the first decorator, which wraps the original service type.
        //     Constructor injection will be used on that type, and although it may have many
        //     constructor arguments, it must have exactly one argument of the type of TService,
        //     or an argument of type System.Func`1 where TResult is TService. An exception
        //     will be thrown when this is not the case.
        //     The registered TDecorator may have a constructor with an argument of type System.Func`1
        //     where T is TService. In this case, the will not inject the decorated TService
        //     itself into the TDecorator instance, but it will inject a System.Func`1 that
        //     allows creating instances of the decorated type, according to the lifestyle of
        //     that type. This enables more advanced scenarios, such as executing the decorated
        //     types on a different thread, or executing decorated instance within a certain
        //     scope (such as a lifetime scope).
          void RegisterDecorator<TService, TDecorator>(Lifestyle lifestyle)
            where TService : class
            where TDecorator : class, TService;
        //
        // Summary:
        //     Ensures that the supplied decoratorType decorator is returned and cached with
        //     the given lifestyle, wrapping the original registered serviceType, by injecting
        //     that service type into the constructor of the supplied decoratorType. Multiple
        //     decorators may be applied to the same serviceType. Decorators can be applied
        //     to both open, closed, and non-generic service types.
        //
        // Parameters:
        //   serviceType:
        //     The definition of the (possibly open generic) service type that will be wrapped
        //     by the given decoratorType.
        //
        //   decoratorType:
        //     The definition of the (possibly open generic) decorator type that will be used
        //     to wrap the original service type.
        //
        //   lifestyle:
        //     The lifestyle that specifies how the returned decorator will be cached.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the arguments is a null reference.
        //
        //   T:System.ArgumentException:
        //     Thrown when serviceType is not an open generic type, when decoratorType does
        //     not inherit from or implement serviceType, when decoratorType does not have a
        //     single public constructor, or when decoratorType does not contain a constructor
        //     that has exactly one argument of type serviceType or System.Func`1 where T is
        //     serviceType.
        //
        // Remarks:
        //     The RegisterDecorator method works by hooking onto the container's SimpleInjector.Container.ExpressionBuilt
        //     event. This event fires after the SimpleInjector.Container.ResolveUnregisteredType
        //     event, which allows decoration of types that are resolved using unregistered
        //     type resolution.
        //     Multiple decorators can be applied to the same service type. The order in which
        //     they are registered is the order they get registered. This means that the decorator
        //     that gets registered first, gets applied first, which means that the next registered
        //     decorator, will wrap the first decorator, which wraps the original service type.
        //     Constructor injection will be used on that type, and although it may have many
        //     constructor arguments, it must have exactly one argument of the type of serviceType,
        //     or an argument of type System.Func`1 where TResult is serviceType. An exception
        //     will be thrown when this is not the case.
        //     The registered decoratorType may have a constructor with an argument of type
        //     System.Func`1 where T is serviceType. In this case, the will not inject the decorated
        //     serviceType itself into the decoratorType instance, but it will inject a System.Func`1
        //     that allows creating instances of the decorated type, according to the lifestyle
        //     of that type. This enables more advanced scenarios, such as executing the decorated
        //     types on a different thread, or executing decorated instance within a certain
        //     scope (such as a lifetime scope).
        void RegisterDecorator(Type serviceType, Type decoratorType, Lifestyle lifestyle);
        //
        // Summary:
        //     Ensures that the supplied TDecorator decorator is returned, wrapping the original
        //     registered TService, by injecting that service type into the constructor of the
        //     supplied TDecorator. Multiple decorators may be applied to the same TService.
        //     By default, a new TDecorator instance will be returned on each request (according
        //     the SimpleInjector.Lifestyle.Transient lifestyle), independently of the lifestyle
        //     of the wrapped service.
        //
        // Type parameters:
        //   TService:
        //     The service type that will be wrapped by the given TDecorator.
        //
        //   TDecorator:
        //     The decorator type that will be used to wrap the original service type.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     Thrown when TDecorator does not have a single   constructor, or when TDecorator
        //     does not contain a constructor that has exactly one argument of type TService
        //     or System.Func`1 where T is TService.
        //
        // Remarks:
        //     This method uses the container's SimpleInjector.ContainerOptions.LifestyleSelectionBehavior
        //     to select the exact lifestyle for the specified type. By default this will be
        //     SimpleInjector.Lifestyle.Transient.
        //     The RegisterDecorator method works by hooking onto the container's SimpleInjector.Container.ExpressionBuilt
        //     event. This event fires after the SimpleInjector.Container.ResolveUnregisteredType
        //     event, which allows decoration of types that are resolved using unregistered
        //     type resolution.
        //     Multiple decorators can be applied to the same service type. The order in which
        //     they are registered is the order they get applied in. This means that the decorator
        //     that gets registered first, gets applied first, which means that the next registered
        //     decorator, will wrap the first decorator, which wraps the original service type.
        //     Constructor injection will be used on that type, and although it may have many
        //     constructor arguments, it must have exactly one argument of the type of TService,
        //     or an argument of type System.Func`1 where TResult is TService. An exception
        //     will be thrown when this is not the case.
        //     The registered TDecorator may have a constructor with an argument of type System.Func`1
        //     where T is TService. In this case, an decorated instance will not injected into
        //     the TService, but it will inject a System.Func`1 that allows creating instances
        //     of the decorated type, according to the lifestyle of that type. This enables
        //     more advanced scenarios, such as executing the decorated types on a different
        //     thread, or executing decorated instance within a certain scope (such as a lifetime
        //     scope).
          void RegisterDecorator<TService, TDecorator>()
            where TService : class
            where TDecorator : class, TService;
        //
        // Summary:
        //     Registers an System.Action`1 delegate that runs after the creation of instances
        //     for which the supplied predicate returns true. Please note that only instances
        //     that are created by the container can be initialized this way.
        //
        // Parameters:
        //   instanceInitializer:
        //     The delegate that will be called after the instance has been constructed and
        //     before it is returned.
        //
        //   predicate:
        //     The predicate that will be used to check whether the given delegate must be applied
        //     to a registration or not. The given predicate will be called once for each registration
        //     in the container.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when either the instanceInitializer or predicate are null references.
        //
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered.
        //
        // Remarks:
        //     Note: Initializers are guaranteed to be executed in the order they are registered.
        //     Note: The predicate is not guaranteed to be called once per registration; when
        //     a registration's instance is requested for the first time simultaneously over
        //     multiple thread, the predicate might be called multiple times. The caller of
        //     this method is responsible of supplying a predicate that is thread-safe.
          void RegisterInitializer(Action<InstanceInitializationData> instanceInitializer, Predicate<InitializerContext> predicate);
        //
        // Summary:
        //     Registers an System.Action`1 delegate that runs after the creation of instances
        //     that implement or derive from the given TService. Please note that only instances
        //     that are created by the container (using constructor injection) can be initialized
        //     this way.
        //
        // Parameters:
        //   instanceInitializer:
        //     The delegate that will be called after the instance has been constructed and
        //     before it is returned.
        //
        // Type parameters:
        //   TService:
        //     The type for which the initializer will be registered.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when the instanceInitializer is a null reference.
        //
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered.
        //
        // Remarks:
        //     Multiple instanceInitializer delegates can be registered per TService and multiple
        //     initializers can be applied on a created instance, before it is returned. For
        //     instance, when registering a instanceInitializer for type System.Object, the
        //     delegate will be called for every instance created by the container, which can
        //     be nice for debugging purposes.
        //     Note: Initializers are guaranteed to be executed in the order they are registered.
        //     The following example shows the usage of the SimpleInjector.Container.RegisterInitializer``1(System.Action{``0})
        //     method:
        //     The container does not use the type information of the requested service type,
        //     but it uses the type information of the actual implementation to find all initialized
        //     that apply for that type. This makes it possible to have multiple initializers
        //     to be applied on a single returned instance while keeping performance high.
        //     Registered initializers will only be applied to instances that are created by
        //     the container self (using constructor injection). Types that are newed up manually
        //     by supplying a System.Func`1 delegate to the container (using the SimpleInjector.Container.Register``1(System.Func{``0})
        //     method) or registered as single instance (using SimpleInjector.Container.RegisterInstance``1(``0))
        //     will not trigger initialization. When initialization of these instances is needed,
        //     this must be done manually, as can be seen in the following example: The previous
        //     example shows how a manually created instance can still be initialized. Try to
        //     prevent creating types manually, by changing the design of those classes. If
        //     possible, create a single   constructor that only contains dependencies
        //     that can be resolved.
          void RegisterInitializer<TService>(Action<TService> instanceInitializer) where TService : class;
        //
        // Summary:
        //     Registers a single instance that will be returned when an instance of type serviceType
        //     is requested. This instance must be thread-safe when working in a multi-threaded
        //     environment. NOTE: Do note that instances supplied by this method NEVER get disposed
        //     by the container, since the instance is assumed to outlive this container instance.
        //     If disposing is required, use SimpleInjector.Container.RegisterSingleton(System.Type,System.Func{System.Object}).
        //
        // Parameters:
        //   serviceType:
        //     The base type or interface to register.
        //
        //   instance:
        //     The instance to register.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when either serviceType or instance are null references (Nothing in VB).
        //
        //   T:System.ArgumentException:
        //     Thrown when instance is no sub type from serviceType.
        //
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered, or when
        //     an the serviceType has already been registered.
          void RegisterInstance(Type serviceType, object instance);
        //
        // Summary:
        //     Registers a single instance that will be returned when an instance of type TService
        //     is requested. This instance must be thread-safe when working in a multi-threaded
        //     environment. NOTE: Do note that instances supplied by this method NEVER get disposed
        //     by the container, since the instance is assumed to outlive this container instance.
        //     If disposing is required, use SimpleInjector.Container.RegisterSingleton``1(System.Func{``0}).
        //
        // Parameters:
        //   instance:
        //     The instance to register.
        //
        // Type parameters:
        //   TService:
        //     The interface or base type that can be used to retrieve the instance.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered, or when
        //     the TService has already been registered.
        //
        //   T:System.ArgumentNullException:
        //     Thrown when instance is a null reference.
          void RegisterInstance<TService>(TService instance) where TService : class;
        //
        // Summary:
        //     Registers the specified delegate that allows constructing a single serviceType
        //     instance. The container will call this delegate at most once during the lifetime
        //     of the application.
        //
        // Parameters:
        //   serviceType:
        //     The base type or interface to register.
        //
        //   instanceCreator:
        //     The delegate that will be used for creating that single instance.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     Thrown when serviceType represents an open generic type.
        //
        //   T:System.ArgumentNullException:
        //     Thrown when either serviceType or instanceCreator are null references (Nothing
        //     in VB).
        //
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered, or when
        //     an the serviceType has already been registered.
          void RegisterSingleton(Type serviceType, Func<object> instanceCreator);
        //
        // Summary:
        //     Registers that the same instance of type implementationType will be returned
        //     every time an instance of type serviceType type is requested. If serviceType
        //     and implementationType represent the same type, the type is registered by itself.
        //     implementationType must be thread-safe when working in a multi-threaded environment.
        //     Open and closed generic types are supported.
        //
        // Parameters:
        //   serviceType:
        //     The base type or interface to register. This can be an open-generic type.
        //
        //   implementationType:
        //     The actual type that will be returned when requested. This can be an open-generic
        //     type.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when either serviceType or implementationType are null references (Nothing
        //     in VB).
        //
        //   T:System.ArgumentException:
        //     Thrown when implementationType is no sub type from serviceType, or when one of
        //     them represents an open generic type.
        //
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered, or when
        //     an the serviceType has already been registered.
          void RegisterSingleton(Type serviceType, Type implementationType);
        //
        // Summary:
        //     Registers the specified delegate that allows constructing a single instance of
        //     TService. This delegate will be called at most once during the lifetime of the
        //     application. The returned instance must be thread-safe when working in a multi-threaded
        //     environment. If the instance returned from instanceCreator implements System.IDisposable,
        //     the created instance will get disposed when SimpleInjector.Container.Dispose
        //     gets called.
        //
        // Parameters:
        //   instanceCreator:
        //     The delegate that allows building or creating this single instance.
        //
        // Type parameters:
        //   TService:
        //     The interface or base type that can be used to retrieve instances.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered, or when
        //     a instanceCreator for TService has already been registered.
        //
        //   T:System.ArgumentNullException:
        //     Thrown when instanceCreator is a null reference.
          void RegisterSingleton<TService>(Func<TService> instanceCreator) where TService : class;
        //
        // Summary:
        //     Registers that the same a single instance of type TImplementation will be returned
        //     every time an TService type is requested. If TService and TImplementation represent
        //     the same type, the type is registered by itself. TImplementation must be thread-safe
        //     when working in a multi-threaded environment. If TImplementation implements System.IDisposable,
        //     a created instance will get disposed when SimpleInjector.Container.Dispose gets
        //     called.
        //
        // Type parameters:
        //   TService:
        //     The interface or base type that can be used to retrieve the instances.
        //
        //   TImplementation:
        //     The concrete type that will be registered.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered, or when
        //     the TService has already been registered.
        //
        //   T:System.ArgumentException:
        //     Thrown when the given TImplementation type is not a type that can be created
        //     by the container.
          void RegisterSingleton<TService, TImplementation>()
            where TService : class
            where TImplementation : class, TService;
        //
        // Summary:
        //     Registers a single concrete instance that will be constructed using constructor
        //     injection and will be returned when this instance is requested by type TConcrete.
        //     This TConcrete must be thread-safe when working in a multi-threaded environment.
        //     If TConcrete implements System.IDisposable, a created instance will get disposed
        //     when SimpleInjector.Container.Dispose gets called.
        //
        // Type parameters:
        //   TConcrete:
        //     The concrete type that will be registered.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered, or when
        //     TConcrete has already been registered.
        //
        //   T:System.ArgumentException:
        //     Thrown when the TConcrete is a type that can not be created by the container.
          void RegisterSingleton<TConcrete>() where TConcrete : class;
        //
        // Summary:
        //     Registers a single instance that will be returned when an instance of type serviceType
        //     is requested. This instance must be thread-safe when working in a multi-threaded
        //     environment.
        //
        // Parameters:
        //   serviceType:
        //     The base type or interface to register.
        //
        //   instance:
        //     The instance to register.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when either serviceType or instance are null references (Nothing in VB).
        //
        //   T:System.ArgumentException:
        //     Thrown when instance is no sub type from serviceType.
        //
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered, or when
        //     an the serviceType has already been registered.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Please use RegisterInstance(Type, object) instead. Will be treated as an error from version 5.0. Will be removed in version 6.0.", false)]
          void RegisterSingleton(Type serviceType, object instance);
        //
        // Summary:
        //     Registers all concrete, non-generic, public and internal types in the given set
        //     of assemblies that implement the given openGenericServiceType with SimpleInjector.Lifestyle.Singleton
        //     lifestyle. SimpleInjector.TypesToRegisterOptions.IncludeDecorators and SimpleInjector.TypesToRegisterOptions.IncludeGenericTypeDefinitions
        //     will be excluded from registration, while SimpleInjector.TypesToRegisterOptions.IncludeComposites
        //     are included.
        //
        // Parameters:
        //   openGenericServiceType:
        //     The definition of the open generic type.
        //
        //   assemblies:
        //     A list of assemblies that will be searched.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the arguments contain a null reference (Nothing in VB).
        //
        //   T:System.ArgumentException:
        //     Thrown when openGenericServiceType is not an open generic type.
        //
        //   T:System.InvalidOperationException:
        //     Thrown when the given set of assemblies contain multiple types that implement
        //     the same closed generic version of the given openGenericServiceType.
          void RegisterSingleton(Type openGenericServiceType, IEnumerable<Assembly> assemblies);
        //
        // Summary:
        //     Registers all concrete, non-generic, public and internal types in the given set
        //     of assemblies that implement the given openGenericServiceType with SimpleInjector.Lifestyle.Singleton
        //     lifestyle. SimpleInjector.TypesToRegisterOptions.IncludeDecorators and SimpleInjector.TypesToRegisterOptions.IncludeGenericTypeDefinitions
        //     will be excluded from registration, while SimpleInjector.TypesToRegisterOptions.IncludeComposites
        //     are included.
        //
        // Parameters:
        //   openGenericServiceType:
        //     The definition of the open generic type.
        //
        //   assemblies:
        //     A list of assemblies that will be searched.
        //
        // Exceptions:
        //   T:System.ArgumentNullException:
        //     Thrown when one of the arguments contain a null reference (Nothing in VB).
        //
        //   T:System.ArgumentException:
        //     Thrown when openGenericServiceType is not an open generic type.
        //
        //   T:System.InvalidOperationException:
        //     Thrown when the given set of assemblies contain multiple types that implement
        //     the same closed generic version of the given openGenericServiceType.
          void RegisterSingleton(Type openGenericServiceType, params Assembly[] assemblies);
        //
        // Summary:
        //     Registers a single instance that will be returned when an instance of type TService
        //     is requested. This instance must be thread-safe when working in a multi-threaded
        //     environment. NOTE: Do note that instances supplied by this method NEVER get disposed
        //     by the container, since the instance is assumed to outlive this container instance.
        //     If disposing is required, use the overload that accepts a System.Func`1 delegate.
        //
        // Parameters:
        //   instance:
        //     The instance to register.
        //
        // Type parameters:
        //   TService:
        //     The interface or base type that can be used to retrieve the instance.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     Thrown when this container instance is locked and can not be altered, or when
        //     the TService has already been registered.
        //
        //   T:System.ArgumentNullException:
        //     Thrown when instance is a null reference.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("Please use RegisterInstance<TService>(TService) instead. Will be treated as an error from version 5.0. Will be removed in version 6.0.", false)]
          void RegisterSingleton<TService>(TService instance) where TService : class;
        //
        // Summary:
        //     Verifies the Container. This method will call all registered delegates, iterate
        //     registered collections and throws an exception if there was an error.
        //
        // Parameters:
        //   option:
        //     Specifies how the container should verify its configuration.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     Thrown when the registration of instances was invalid.
        //
        //   T:SimpleInjector.DiagnosticVerificationException:
        //     Thrown in case there are diagnostic errors and the SimpleInjector.VerificationOption.VerifyAndDiagnose
        //     option is supplied.
        //
        //   T:System.ArgumentException:
        //     Thrown when option has an invalid value.
          void Verify(VerificationOption option);
        //
        // Summary:
        //     Verifies and diagnoses this Container instance. This method will call all registered
        //     delegates, iterate registered collections and throws an exception if there was
        //     an error.
        //
        // Exceptions:
        //   T:System.InvalidOperationException:
        //     Thrown when the registration of instances was invalid.
          void Verify();
    }
}
