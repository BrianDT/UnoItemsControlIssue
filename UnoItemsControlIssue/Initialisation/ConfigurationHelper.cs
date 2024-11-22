// <copyright file="ConfigurationHelper.cs" company="Visual Software Systems Ltd.">Copyright (c) 2023, 2024 All rights reserved</copyright>
namespace Vssl.UnoItemsControlIssue.Initialisation;

#if NET6_0_OR_GREATER && (ANDROID || __IOS__)
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
public static class ConfigurationHelper
{
    /// <summary>
    /// Creates a configuration for the given file
    /// </summary>
    /// <param name="settingsPath">The path of the settings file</param>
    /// <param name="isOptional">Whether the file is optional.</param>
    /// <param name="reloadOnChange">Whether the configuration should be reloaded if the file changes.</param>
    /// <returns>The configuration</returns>
    public static IConfiguration BuildConfig(string settingsPath, bool isOptional = true, bool reloadOnChange = true)
    {
        IFileProvider fileProvider = null;
        IConfigurationBuilder builder = new ConfigurationBuilder();
#if __IOS__
        ////fileProvider = new IOSFileProvider();
        string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        builder.SetBasePath(path);
#endif
        builder.Add<WritableJsonConfigurationSource>((Action<WritableJsonConfigurationSource>)(s =>
        {
            s.FileProvider = fileProvider;
            s.Path = settingsPath;
            s.Optional = isOptional;
            s.ReloadOnChange = reloadOnChange;
            s.ResolveFileProvider();
        }));
        builder.AddJsonFile("appsettings.json", true, true);
        IConfigurationRoot root = builder.Build();

        return root;
    }
}
#endif
