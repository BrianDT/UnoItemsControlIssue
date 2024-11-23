// <copyright file="IThingCollection.cs" company="Visual Software Systems Ltd.">Copyright (c) 2024 All rights reserved</copyright>
namespace Vssl.Samples.ViewModelInterfaces;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssl.Samples.FrameworkInterfaces;

/// <summary>
/// A coillection of thing items
/// </summary>
public interface IThingCollection : IUINotificationViewModelBase
{
    /// <summary>
    /// Gets the collection of things.
    /// </summary>
    ObservableCollection<IThing> Things { get; }

    /// <summary>
    /// Add a thing.
    /// </summary>
    void AddItems();
}
