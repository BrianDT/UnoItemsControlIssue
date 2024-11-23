# UnoItemsControlIssue
# UnoItemsControlIssue
Reproduces binding issues when binding a ObservableCollection as the source of an ItemsControl

Reported as a Uno Platform issue #18901 here:
https://github.com/unoplatform/uno/issues/18901

Issue Title
Publishing trimmed caused exception when binding to an ObservableCollection
Typical call stack
```
 	WinRT.Runtime.dll!WinRT.TypeExtensions.GetAbiToProjectionVftblPtr(System.Type value)	Unknown
 	WinRT.Runtime.dll!WinRT.ComWrappersSupport.GetInterfaceTableEntries.__AddInterfaceToVtable|16_1(System.Type value, System.Collections.Generic.List<System.Runtime.InteropServices.ComWrappers.ComInterfaceEntry> value, bool value)	Unknown
 	WinRT.Runtime.dll!WinRT.ComWrappersSupport.GetInterfaceTableEntries.__GetInterfaceTableEntriesForJitEnvironment|16_2(System.Type value, System.Collections.Generic.List<System.Runtime.InteropServices.ComWrappers.ComInterfaceEntry> value, bool value)	Unknown
 	WinRT.Runtime.dll!WinRT.ComWrappersSupport.GetInterfaceTableEntries(System.Type value)	Unknown
 	WinRT.Runtime.dll!WinRT.DefaultComWrappers.ComputeVtables.AnonymousMethod__7_0(System.Type type)	Unknown
 	System.Private.CoreLib.dll!System.Runtime.CompilerServices.ConditionalWeakTable<System.Type, WinRT.DefaultComWrappers.VtableEntries>.GetValueLocked(System.Type value, System.Runtime.CompilerServices.ConditionalWeakTable<System.Type, WinRT.DefaultComWrappers.VtableEntries>.CreateValueCallback value)	Unknown
 	System.Private.CoreLib.dll!System.Runtime.CompilerServices.ConditionalWeakTable<System.__Canon, System.__Canon>.GetValue(System.__Canon value, System.Runtime.CompilerServices.ConditionalWeakTable<System.__Canon, System.__Canon>.CreateValueCallback value)	Unknown
 	WinRT.Runtime.dll!WinRT.DefaultComWrappers.ComputeVtables(object value, System.Runtime.InteropServices.CreateComInterfaceFlags value, out int value)	Unknown
 	System.Private.CoreLib.dll!System.Runtime.InteropServices.ComWrappers.CallComputeVtables(System.Runtime.InteropServices.ComWrappersScenario value, System.Runtime.InteropServices.ComWrappers value, object value, System.Runtime.InteropServices.CreateComInterfaceFlags value, out int value)	Unknown
 	[Native to Managed Transition]	
 	[Managed to Native Transition]	
 	System.Private.CoreLib.dll!System.Runtime.InteropServices.ComWrappers.TryGetOrCreateComInterfaceForObjectInternal(System.Runtime.CompilerServices.ObjectHandleOnStack value, long value, System.Runtime.CompilerServices.ObjectHandleOnStack value, System.Runtime.InteropServices.CreateComInterfaceFlags value, out System.IntPtr value)	Unknown
 	System.Private.CoreLib.dll!System.Runtime.InteropServices.ComWrappers.TryGetOrCreateComInterfaceForObjectInternal(System.Runtime.InteropServices.ComWrappers value, object value, System.Runtime.InteropServices.CreateComInterfaceFlags value, out System.IntPtr value)	Unknown
 	System.Private.CoreLib.dll!System.Runtime.InteropServices.ComWrappers.GetOrCreateComInterfaceForObject(object value, System.Runtime.InteropServices.CreateComInterfaceFlags value)	Unknown
 	WinRT.Runtime.dll!WinRT.ComWrappersSupport.CreateCCWForObjectForABI(object value, System.Guid value)	Unknown
 	WinRT.Runtime.dll!WinRT.MarshalInspectable<System.__Canon>.CreateMarshaler2(System.__Canon value, System.Guid value, bool value)	Unknown
 	WinRT.Runtime.dll!WinRT.MarshalInspectable<object>.CreateMarshaler2(object value, bool value)	Unknown
 	Microsoft.WinUI.dll!ABI.Microsoft.UI.Xaml.IFrameworkElementMethods.set_DataContext(WinRT.IObjectReference value, object value)	Unknown
>	Vssl.UnoItemsControlIssue.dll!Vssl.UnoItemsControlIssue.MainPage.MainPage() Line 27	C#
 	Vssl.UnoItemsControlIssue.dll!Vssl.UnoItemsControlIssue.UnoItemsControlIssue_XamlTypeInfo.XamlTypeInfoProvider.Activate_4_MainPage() Line 291	C#
 	Microsoft.WinUI.dll!ABI.Microsoft.UI.Xaml.Markup.IXamlType.Do_Abi_ActivateInstance_13(System.IntPtr thisPtr, System.IntPtr* result)	Unknown
 	[Native to Managed Transition]	
 	[Managed to Native Transition]	
 	Microsoft.WinUI.dll!ABI.Microsoft.UI.Xaml.Controls.IFrameMethods.Navigate(WinRT.IObjectReference value, System.Type value, object value)	Unknown
 	Vssl.UnoItemsControlIssue.dll!Vssl.UnoItemsControlIssue.App.OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs value) Line 132	C#
 	Microsoft.WinUI.dll!Microsoft.UI.Xaml.Application.Microsoft.UI.Xaml.IApplicationOverrides.OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs value)	Unknown
 	Microsoft.WinUI.dll!ABI.Microsoft.UI.Xaml.IApplicationOverrides.Do_Abi_OnLaunched_0(System.IntPtr thisPtr, System.IntPtr args)	Unknown
 	[Native to Managed Transition]	
 	[Managed to Native Transition]	
 	Microsoft.WinUI.dll!ABI.Microsoft.UI.Xaml.IApplicationStaticsMethods.Start(WinRT.IObjectReference value, Microsoft.UI.Xaml.ApplicationInitializationCallback value)	Unknown
 	Vssl.UnoItemsControlIssue.dll!Vssl.UnoItemsControlIssue.Program.Main(string[] value) Line 26	C#
```

Current behavior
Trimming the release build on publication causes a binding failure on itemcontrols when the datacontext is set on the page.

Expected behavior
The release build should execute correctly in the same way that the debug build does.

Workaround
If you have a  win-AnyCPU.pubxml Publisg profile file, set PublishTrimmed to false for all build types.
```
<!--<PublishTrimmed Condition="'$(Configuration)' == 'Debug'">False</PublishTrimmed>
<PublishTrimmed Condition="'$(Configuration)' != 'Debug'">True</PublishTrimmed>-->
        <PublishTrimmed>False</PublishTrimmed>
```


Reproduces binding issues when binding a ObservableCollection as the source of an ItemsControl

