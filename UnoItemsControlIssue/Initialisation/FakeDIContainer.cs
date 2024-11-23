// <copyright file="FakeDIContainer.cs" company="Visual Software Systems Ltd.">Copyright (c) 2024 All rights reserved</copyright>
namespace Vssl.UnoItemsControlIssue.Initialisation;

using System;
using Vssl.Samples.Framework;
using Vssl.Samples.FrameworkInterfaces;
using Vssl.Samples.ViewModelInterfaces;
using Vssl.Samples.ViewModels;

/// <summary>
/// A Fake dependency injection initialisation
/// </summary>
public class FakeDIContainer : IDependencyResolver
{
    /// <summary>
    /// The interface to the UI Dispatcher facade.
    /// </summary>
    private IDispatchOnUIThread uiDispatcher;

    /// <summary>
    /// Gets the type mapping from the unity container
    /// </summary>
    /// <typeparam name="InterfaceType">The registered interface type</typeparam>
    /// <returns>The mapped type</returns>
    public InterfaceType Resolve<InterfaceType>()
        where InterfaceType : class
    {
        return (InterfaceType)(object)this.Resolve(typeof(InterfaceType));
    }

    /// <summary>
    /// Gets the type mapping from the unity container
    /// </summary>
    /// <param name="interfaceType">The registered interface type</param>
    /// <returns>The mapped type</returns>
    public object Resolve(Type interfaceType)
    {
        if (interfaceType == typeof(IDispatchOnUIThread))
        {
            if (this.uiDispatcher == null)
            {
                this.uiDispatcher = new UIDispatcher();
            }

            return this.uiDispatcher;
        }
        else if (interfaceType == typeof(IThingCollection))
        {
            var uiDispatcher = this.Resolve<IDispatchOnUIThread>();
            return new ThingCollection(uiDispatcher) as IThingCollection;
        }

        throw new System.Exception("Type unknown");
    }

    /// <summary>
    /// Registers a class and its interface
    /// </summary>
    /// <typeparam name="TF">The type of the interface</typeparam>
    /// <typeparam name="TI">The type of the class</typeparam>
    public void Register<TF, TI>()
        where TF : class
        where TI : class, TF
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Registers a class as a singleton
    /// </summary>
    /// <typeparam name="TF">The type of the interface</typeparam>
    /// <typeparam name="TI">The type of the class</typeparam>
    public void RegisterSingleton<TF, TI>()
        where TF : class
        where TI : class, TF
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the mapped type from the container given the registered type
    /// </summary>
    /// <param name="interfaceType">The registered interface type</param>
    /// <returns>The mapped type</returns>
    public Type GetMappedType(Type interfaceType)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets the registered interface type from the container given the mapped object type.
    /// </summary>
    /// <param name="mappedType">The mapped object type</param>
    /// <returns>The registered interface type</returns>
    public Type GetRegisteredType(Type mappedType)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Determines if the given type is registered
    /// </summary>
    /// <param name="interfaceType">The registered interface type</param>
    /// <returns>True if mapped</returns>
    public bool IsMapped(Type interfaceType)
    {
        throw new NotImplementedException();
    }
}
