namespace UnoItemsControlIssue.ViewModelHelper;

using UnoItemsControlIssue.ViewModelInterfaces;
using UnoItemsControlIssue.ViewModels;

public static class DependencyHelper
{
    public static T Resolve<T>() where T : class
    {
        if (typeof(T) == typeof(IThingCollection))
        {
            return new ThingCollection() as T;
        }

        throw new System.Exception("Type unknown");
    }
}
