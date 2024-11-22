namespace Vssl.Samples.ViewModels;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssl.Samples.ViewModelInterfaces;
using Vssl.VisualFramework.ViewModelInterfaces;
using Vssl.VisualFramework.ViewModels;

public class ThingCollection : UINotificationViewModelBase, IThingCollection
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ThingCollection"/> class.
    /// </summary>
    /// <param name="uiDispatcher">The interface to the UI Dispatcher facade.</param>
    public ThingCollection(IDispatchOnUIThread uiDispatcher)
        : base(uiDispatcher)
    {
        this.Things = new ObservableCollection<IThing>();
        for (int i = 0; i < 4; i++)
        {
            this.Things.Add(new ThingItem(uiDispatcher));
        }
    }

    public ObservableCollection<IThing> Things { get; private set; }

    public void AddItems()
    {
        this.Things.Add(new ThingItem(this.UIDispatcher, 1));
        this.Things.Add(new ThingItem(this.UIDispatcher, 1));
        this.Things.Add(new ThingItem(this.UIDispatcher, 1));
    }
}
