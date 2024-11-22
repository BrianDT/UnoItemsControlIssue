namespace Vssl.Samples.ViewModelInterfaces;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vssl.VisualFramework.CommonInterfaces;
using Vssl.VisualFramework.ViewModelInterfaces;

public interface IThingCollection : IUINotificationViewModelBase
{
    ObservableCollection<IThing> Things { get; }
    void AddItems();
}
