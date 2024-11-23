// <copyright file="MainViewModel.cs" company="Visual Software Systems Ltd.">Copyright (c) 2024 All rights reserved</copyright>
namespace Vssl.Samples.ViewModels;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Vssl.Samples.Framework.ViewModels;
using Vssl.Samples.FrameworkInterfaces;
using Vssl.Samples.ViewModelInterfaces;

/// <summary>
/// The view model for the main page
/// </summary>
public class MainViewModel : UINotificationViewModelBase, IMainViewModel
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MainViewModel"/> class.
    /// </summary>
    /// <param name="uiDispatcher">The interface to the UI Dispatcher facade.</param>
    public MainViewModel(IDispatchOnUIThread uiDispatcher)
        : base(uiDispatcher)
    {
        this.Things = new ObservableCollection<IThing>();
    }

    /// <summary>
    /// Gets the collection of things.
    /// </summary>
    public IThingCollection ThingSet { get; private set; }

    /// <summary>
    /// Gets the collection of things
    /// </summary>
    public ObservableCollection<IThing> Things { get; private set; }

    /// <summary>
    /// Called when the page size changes
    /// </summary>
    /// <param name="width">The page width</param>
    /// <param name="height">The page height</param>
    public void OnPageSizeChanged(double width, double height)
    {
    }

    /// <summary>
    /// Sets the view model of the things collection from the control.
    /// </summary>
    /// <param name="thingCollection">The things collection</param>
    public void SetCollection(IThingCollection thingCollection)
    {
        this.ThingSet = thingCollection;
    }

    /// <summary>
    /// Add items to the collection.
    /// </summary>
    public void AddItemsToCollection()
    {
        this.ThingSet.AddItems();
    }
}
