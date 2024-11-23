// <copyright file="IMainViewModel.cs" company="Visual Software Systems Ltd.">Copyright (c) 2024 All rights reserved</copyright>
namespace Vssl.Samples.ViewModelInterfaces;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Vssl.Samples.FrameworkInterfaces;

/// <summary>
/// The view model for the main page
/// </summary>
public interface IMainViewModel : IUINotificationViewModelBase
{
    /// <summary>
    /// Gets the collection of things.
    /// </summary>
    IThingCollection ThingSet { get; }

    /// <summary>
    /// Gets the collection of things
    /// </summary>
    ObservableCollection<IThing> Things { get; }

    /// <summary>
    /// Called when the page size changes
    /// </summary>
    /// <param name="width">The page width</param>
    /// <param name="height">The page height</param>
    public void OnPageSizeChanged(double width, double height);

    /// <summary>
    /// Sets the view model of the things collection from the control.
    /// </summary>
    /// <param name="thingCollection">The things collection</param>
    void SetCollection(IThingCollection thingCollection);

    /// <summary>
    /// Add items to the collection.
    /// </summary>
    void AddItemsToCollection();
}
