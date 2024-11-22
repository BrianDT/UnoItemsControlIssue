// <copyright file="Bootstrapper.cs" company="Visual Software Systems Ltd.">Copyright (c) 2024 All rights reserved</copyright>
namespace Vssl.UnoItemsControlIssue.Initialisation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssl.Samples.Framework;
using Vssl.Samples.FrameworkInterfaces;
using Vssl.VisualFramework.ViewModelInterfaces;

/// <summary>
/// Dependepcy injection manager
/// </summary>
public class Bootstrapper
{
    /// <summary>
    /// The application specific initialisation
    /// </summary>
    /// <returns>The DI container facade</returns>
    public IDependencyResolver OnStartup()
    {
        var containerCreator = new MSServiceContainer();
        var diFacade = containerCreator.PopulateContainer();

        var dispatcher = diFacade.Resolve<IDispatchOnUIThread>();
        dispatcher.Initialize();

        DependencyHelper.Container = diFacade;

        return diFacade;
    }
}
