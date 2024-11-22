// <copyright file="MainPage.xaml.cs" company="Visual Software Systems Ltd.">Copyright (c) 2024 All rights reserved</copyright>
namespace Vssl.UnoItemsControlIssue;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Vssl.Samples.ViewModelInterfaces;
using Vssl.Samples.ViewInterfaces;
using Vssl.Framework.DIUtilities;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainPage : Page, IMainPage
{
    /// <summary>
    /// A value indicating whether the page has been loaded
    /// </summary>
    private bool isloaded;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainPage"/> class.
    /// </summary>
    public MainPage()
    {
        this.InitializeComponent();
        var viewModel = DependencyHelper.Resolve<IMainViewModel>();
        this.DataContext = viewModel;

        /*
        this.Loaded += (s, e) =>
        {
            this.VM.SetCollection(this.itemView.VM);
        };
        */
    }

    #region [ Properties ]

    /// <summary>
    /// Gets the interface to the view model for compile time binding
    /// </summary>
    public IMainViewModel VM
    {
        get
        {
            return this.DataContext as IMainViewModel;
        }
    }

    #endregion

    /// <summary>
    /// The event handler called when the page size changes
    /// </summary>
    /// <param name="sender">The sender</param>
    /// <param name="e">The event args</param>
    private void OnDrawingSurfaceSizeChanged(object sender, SizeChangedEventArgs e)
    {
        if (this.isloaded && this.VM != null)
        {
            this.VM.OnPageSizeChanged(e.NewSize.Width, e.NewSize.Height);
        }
    }

    /*
    /// <summary>
    /// Event handler for add items button
    /// </summary>
    /// <param name="sender">The sender</param>
    /// <param name="e">The event args</param>
    private void Button_AddItems(object sender, RoutedEventArgs e)
    {
        this.VM.AddItemsToCollection();
    }
    */
}
