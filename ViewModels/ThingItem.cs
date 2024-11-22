namespace Vssl.Samples.ViewModels;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Vssl.Samples.ViewModelInterfaces;
using Vssl.VisualFramework.ViewModelInterfaces;
using Vssl.VisualFramework.ViewModels;

public class ThingItem : UINotificationViewModelBase, IThing
{
    private int stype;

    /// <summary>
    /// Initializes a new instance of the <see cref="ThingItem"/> class.
    /// </summary>
    /// <param name="uiDispatcher">The interface to the UI Dispatcher facade.</param>
    public ThingItem(IDispatchOnUIThread uiDispatcher, int stype = 0)
        : base(uiDispatcher)
    {
        this.stype = stype;
    }
}
