// <copyright file="MSServiceContainer.cs" company="Visual Software Systems Ltd.">Copyright (c) 2024 All rights reserved</copyright>
namespace Vssl.UnoItemsControlIssue.Initialisation;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#if ANDROID || __IOS__
using Microsoft.Extensions.Configuration;
#endif
using Microsoft.Extensions.DependencyInjection;
using Vssl.Samples.Framework;
using Vssl.Samples.Framework.MSExtFacade;
using Vssl.Samples.FrameworkInterfaces;
using Vssl.Samples.ViewModelInterfaces;
using Vssl.Samples.ViewModels;

/// <summary>
/// Microsoft extensions dependepcy injection initialisation
/// </summary>
public class MSServiceContainer
{
    /// <summary>
    /// returns the container
    /// </summary>
    /// <returns>This class as a container</returns>
    public IDependencyResolver PopulateContainer()
    {
#if ANDROID || __IOS__
        IConfiguration config = ConfigurationHelper.BuildConfig("appsettings.json");
#endif
        var services = new ServiceCollection();
        services.AddSingleton<IDependencyResolver, MSExtDI>();
#if ANDROID || __IOS__
        services.AddTransient<IConfiguration>(_ => config);
#endif
        services.AddSingleton<IDispatchOnUIThread, UIDispatcher>();

        services.AddTransient<IMainViewModel, MainViewModel>();
        services.AddTransient<IThingCollection, ThingCollection>();

        var serviceProvider = services.BuildServiceProvider();
        var diFacade = serviceProvider.GetRequiredService<IDependencyResolver>();
        ((MSExtDI)diFacade).Configure(serviceProvider);

        return diFacade;
    }
}
