namespace UnoItemsControlIssue.Controls;

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Vssl.Samples.Framework;
using Vssl.Samples.ViewModelInterfaces;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

public sealed partial class ItemControl : UserControl
{
    public ItemControl()
    {
        this.InitializeComponent();

        this.DataContext = DependencyHelper.Resolve<IThingCollection>();
    }

    /// <summary>
    /// Gets or sets the view model for the menu container
    /// </summary>
    public IThingCollection VM
    {
        get
        {
            return this.DataContext as IThingCollection;
        }
    }

    /// <summary>
    /// Event handler for the wrap grid loaded
    /// </summary>
    /// <param name="sender">The sender</param>
    /// <param name="e">The event args</param>
    private void Col1_Loaded(object sender, RoutedEventArgs e)
    {
    }

    /// <summary>
    /// Event handler for size changed on the wrap panel
    /// Required in order to catch any chan ge in shape of the panel
    /// </summary>
    /// <param name="sender">The sender</param>
    /// <param name="e">The event args</param>
    private void Col1_SizeChanged(object sender, SizeChangedEventArgs e)
    {
    }
}
