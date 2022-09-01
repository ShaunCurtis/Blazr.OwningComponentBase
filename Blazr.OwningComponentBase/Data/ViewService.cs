using System.Diagnostics;

namespace Blazr.OwningComponentBase.Data;

public class ViewService : IDisposable
{
    public Guid Uid = Guid.NewGuid();
    private NotificationService? _notificationService;
    public TransientService TransientService;
    public NotificationService NotificationService
    {
        get
        {
            if (_notificationService is null)
                throw new InvalidOperationException("No service is registered.  You must run SetParentServices before using the service.");

            return _notificationService!;
        }
    }


    //public ViewService(NotificationService notificationService, TransientService transientService)
    //{
    //    Debug.WriteLine($"{this.GetType().Name} - created instance: {Uid}");
    //    _notificationService = notificationService;
    //    Debug.WriteLine($"{this.GetType().Name} - {NotificationService.GetType().Name} instance: {NotificationService.Uid}");
    //    TransientService = transientService;
    //    Debug.WriteLine($"{this.GetType().Name} - {TransientService.GetType().Name} instance: {TransientService.Uid}");
    //}

    public ViewService(TransientService transientService)
    {
        TransientService = transientService;
        Debug.WriteLine($"{this.GetType().Name} - created instance: {Uid}");
    }

    public void SetServices(IServiceProvider serviceProvider)
    {
        _notificationService = serviceProvider.GetService<NotificationService>();
    }

    public void UpdateView()
        => NotificationService.NotifyChanged();

    public void Dispose()
    {
        Debug.WriteLine($"{this.GetType().Name} - Disposed instance: {Uid}");
    }
}
