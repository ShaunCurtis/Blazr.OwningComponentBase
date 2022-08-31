using System.Diagnostics;

namespace Blazr.OwningComponentBase.Data;

public class NotificationService1 : IDisposable
{
    public Guid Uid = Guid.NewGuid();

    public NotificationService1()
        => Debug.WriteLine($"{this.GetType().Name} - created instance: {Uid}");

    public void Dispose()
        => Debug.WriteLine($"{this.GetType().Name} - Disposed instance: {Uid}");
}
