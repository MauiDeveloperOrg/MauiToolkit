using MauiToolkit.Configurations;
using Microsoft.Maui.LifecycleEvents;
using System.Collections.Specialized;

namespace MauiToolkit.Primitives;
internal partial class StatusBarWorker
{
    public StatusBarWorker(StatusBarConfigurations config)
    {
        ArgumentNullException.ThrowIfNull(config, nameof(StatusBarConfigurations));
        _Configurations = config;
        var collectionChangedObject = config.MenuItems as INotifyCollectionChanged;
        if (collectionChangedObject is not null)
            collectionChangedObject.CollectionChanged += CollectionChangedObject_CollectionChanged;
    }

    readonly StatusBarConfigurations _Configurations;

    internal void RegisterApplicationLifeCycle(ILifecycleBuilder builder) => ConfigLifeCycle(builder);

    void CollectionChangedObject_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e) => MenuItemsChanged(e);

    partial void ConfigLifeCycle(ILifecycleBuilder builder);

    partial void MenuItemsChanged(NotifyCollectionChangedEventArgs arg);

    partial void OnDisposing();
}
