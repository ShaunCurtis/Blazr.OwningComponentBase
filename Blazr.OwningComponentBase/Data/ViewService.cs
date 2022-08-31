using System.Diagnostics;

namespace Blazr.OwningComponentBase.Data;

public class ViewService : IDisposable
{
    public Guid Uid = Guid.NewGuid();
    public NotificationService1? NotificationService1 = default!;
    public NotificationService2? NotificationService2 = default!;
    public TransientService? TransientService = default!;

    public ViewService(NotificationService1 notificationService1, TransientService transientService)
    {
        Debug.WriteLine($"{this.GetType().Name} - created instance: {Uid}");
        NotificationService1 = notificationService1;
        Debug.WriteLine($"{this.GetType().Name} - {NotificationService1.GetType().Name} instance: {NotificationService1.Uid}");
        TransientService = transientService;
        Debug.WriteLine($"{this.GetType().Name} - {TransientService.GetType().Name} instance: {TransientService.Uid}");
    }

    public void SetParentServices(IServiceProvider serviceProvider)
    {
        NotificationService2 = serviceProvider.GetService<NotificationService2>();
        Debug.WriteLine($"{this.GetType().Name} - {NotificationService2?.GetType().Name} instance: {NotificationService2?.Uid ?? Guid.Empty}");
    }

    public void Dispose()
        => Debug.WriteLine($"{this.GetType().Name} - Disposed instance: {Uid}");
}
