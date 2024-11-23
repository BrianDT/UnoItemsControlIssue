// <copyright file="ThingItem.cs" company="Visual Software Systems Ltd.">Copyright (c) 2024 All rights reserved</copyright>
namespace Vssl.Samples.ViewModels;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Vssl.Samples.Framework.ViewModels;
using Vssl.Samples.FrameworkInterfaces;
using Vssl.Samples.ViewModelInterfaces;

/// <summary>
/// A member of the things collection.
/// </summary>
public class ThingItem : UINotificationViewModelBase, IThing
{
    private int stype;

    /// <summary>
    /// Initializes a new instance of the <see cref="ThingItem"/> class.
    /// </summary>
    /// <param name="uiDispatcher">The interface to the UI Dispatcher facade.</param>
    /// <param name="stype">The style type</param>
    public ThingItem(IDispatchOnUIThread uiDispatcher, int stype = 0)
        : base(uiDispatcher)
    {
        this.stype = stype;
    }
}
