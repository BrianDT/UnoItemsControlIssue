// <copyright file="BindableBase.cs" company="Visual Software Systems Ltd.">Copyright (c) 2013 All rights reserved</copyright>

namespace Vssl.VisualFramework.Common;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

using Vssl.VisualFramework.CommonInterfaces;

/// <summary>
/// Implementation of <see cref="INotifyPropertyChanged"/> to simplify models.
/// </summary>
public abstract class BindableBase : IBindableBase
{
    #region [ Events ]

    /// <summary>
    /// Multicast event for property change notifications.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /////// <summary>
    /////// Multicast event for property change notifications.
    /////// </summary>
    ////public event BulkPropertyChangedEventHandler PropertiesChanged;

    #endregion

    #region [ Properties ]

    /// <summary>
    /// Gets a value indicating whether the model has been disposed (abstract)
    /// </summary>
    public abstract bool IsDisposed
    {
        get;
    }

    #endregion

    #region [ Public Methods ]

    /// <summary>
    /// A public interface to OnPropertyChanged
    /// </summary>
    /// <param name="propertyName">The property name</param>
    public virtual void NotifyPropertyChanged(string propertyName)
    {
        this.OnPropertyChanged(propertyName);
    }

    /*
    /// <summary>
    /// A public interface to OnPropertyChanged
    /// </summary>
    /// <param name="propertyNames">The property names</param>
    public virtual void NotifyBulkPropertyChanges(List<string> propertyNames)
    {
        if (this.PropertiesChanged != null)
        {
            try
            {
                this.PropertiesChanged?.Invoke(this, new BulkPropertyChangedEventArgs(propertyNames));
            }
            catch (Exception ex)
            {
#if DEBUG
                Debug.WriteLine(string.Format("Exception {0}", ex.Message));
#endif
            }
        }
        else
        {
            foreach (var name in propertyNames)
            {
                this.NotifyPropertyChanged(name);
            }
        }
    }
    */

    #endregion

    #region [ Protected Methods ]

    /// <summary>
    /// Checks if a property already matches a desired value.  Sets the property and
    /// notifies listeners only when necessary.
    /// </summary>
    /// <typeparam name="T">Type of the property.</typeparam>
    /// <param name="storage">Reference to a property with both getter and setter.</param>
    /// <param name="value">Desired value for the property.</param>
    /// <param name="propertyName">Name of the property used to notify listeners.  This
    /// value is optional and can be provided automatically when invoked from compilers that
    /// support CallerMemberName.</param>
    /// <returns>True if the value was changed, false if the existing value matched the
    /// desired value.</returns>
    protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
    {
        if (object.Equals(storage, value))
        {
            return false;
        }

        storage = value;
        this.NotifyPropertyChanged(propertyName);
        return true;
    }

    /// <summary>
    /// Notifies listeners that a property value has changed.
    /// </summary>
    /// <param name="propertyName">Name of the property used to notify listeners.  This
    /// value is optional and can be provided automatically when invoked from compilers
    /// that support <see cref="CallerMemberNameAttribute"/>.</param>
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        try
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        catch (Exception ex)
        {
#if DEBUG
            Debug.WriteLine(string.Format("Exception {0}", ex.Message));
#endif
        }
    }

    #endregion
}
