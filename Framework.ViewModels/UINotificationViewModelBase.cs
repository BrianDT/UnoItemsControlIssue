// <copyright file="UINotificationViewModelBase.cs" company="Visual Software Systems Ltd.">Copyright (c) 2015 All rights reserved</copyright>
namespace Vssl.Samples.Framework.ViewModels;

using System.Collections.Generic;
using System;
using System.Text;
using System.Diagnostics;
using Vssl.Samples.FrameworkInterfaces;

/// <summary>
/// This view model forces property change notification onto the UI thread
/// </summary>
public class UINotificationViewModelBase : BindableBase, IUINotificationViewModelBase
{
    #region [ Private fields ]

    /// <summary>
    /// Indicates that the object has already been disposed
    /// </summary>
    private bool disposed;

    /// <summary>
    /// The interface to the UI Dispatcher facade.
    /// </summary>
    private IDispatchOnUIThread uiDispatcher;

    #endregion

    #region [ Constructor ]

    /// <summary>
    /// Initializes a new instance of the <see cref="UINotificationViewModelBase"/> class.
    /// </summary>
    /// <param name="uiDispatcher">The interface to the UI Dispatcher facade.</param>
    public UINotificationViewModelBase(IDispatchOnUIThread uiDispatcher)
    {
        this.uiDispatcher = uiDispatcher;
    }

    #endregion

    #region [ Properties ]

    /// <summary>
    /// Gets a value indicating whether the model has been disposed
    /// </summary>
    public override bool IsDisposed
    {
        get
        {
            return this.disposed;
        }
    }

    /// <summary>
    /// Gets or sets a value indicating whether diagnostics are enabled
    /// </summary>
    protected bool EnableDiagnostics
    {
        get;
        set;
    }

    /// <summary>
    /// Gets the interface to the UI Dispatcher facade.
    /// </summary>
    protected IDispatchOnUIThread UIDispatcher => this.uiDispatcher;

    #endregion

    #region [ Public Methods ]

    /// <summary>
    /// A public interface to OnPropertyChanged
    /// </summary>
    /// <param name="propertyName">The property name</param>
    public override void NotifyPropertyChanged(string propertyName)
    {
        this.OnNotifyUIPropertyChange(propertyName);
    }

    /*
    /// <summary>
    /// A public interface to OnPropertyChanged
    /// </summary>
    /// <param name="propertyNames">The property names</param>
    public override void NotifyBulkPropertyChanges(List<string> propertyNames)
    {
        this.OnNotifyBulkUIPropertyChange(propertyNames);
    }
    */

    #endregion

    #region [ IDisposable Methods ]

    /// <summary>
    /// Dispose the view model
    /// </summary>
    public void Dispose()
    {
        if (!this.disposed)
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
            this.disposed = true;
        }
    }

    #endregion

    #region [ Protected Methods ]

    /// <summary>
    /// Child classes can override this method to perform
    /// clean-up logic, such as removing event handlers.
    /// </summary>
    /// <param name="disposing">True if already disposing</param>
    protected virtual void Dispose(bool disposing)
    {
    }

    /// <summary>
    /// Generates a property change on the UI thread
    /// </summary>
    /// <param name="propertyName">The property name</param>
    protected virtual void OnNotifyUIPropertyChange(string propertyName)
    {
#if NETFX_CORE
            this.uiDispatcher.Invoke(() =>
            {
                this.OnPropertyChanged(propertyName);
            });
#else
        this.uiDispatcher.Invoke(() =>
        {
            this.OnPropertyChanged(propertyName);
            if (this.EnableDiagnostics)
            {
                Debug.WriteLine(string.Format("OnNotifyUIPropertyChange: {0}", propertyName));
            }
        });
#endif
    }

    /// <summary>
    /// Generates a set of property changes on the UI thread
    /// </summary>
    /// <param name="properties">The list of property names</param>
    protected virtual void OnNotifyBulkUIPropertyChange(List<string> properties)
    {
        this.uiDispatcher.Invoke(() =>
        {
            StringBuilder propertyString = new StringBuilder();
            bool first = true;
            foreach (var propertyName in properties)
            {
                this.OnPropertyChanged(propertyName);
                if (this.EnableDiagnostics)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        propertyString.Append(",");
                    }

                    propertyString.Append(propertyName);
                }
            }

            if (this.EnableDiagnostics)
            {
                Debug.WriteLine(string.Format("OnNotifyBulkUIPropertyChange: {0}", propertyString));
            }
        });
    }

    #endregion
}
