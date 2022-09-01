using System.Diagnostics;

namespace Blazr.OwningComponentBase.Data;

public class NotificationService : IDisposable
{
    public Guid Uid = Guid.NewGuid();
    public event EventHandler? Updated;
    public string Message { get; private set; } = string.Empty;

    public NotificationService()
        => Debug.WriteLine($"{this.GetType().Name} - created instance: {Uid}");

    public void Dispose()
        => Debug.WriteLine($"{this.GetType().Name} - Disposed instance: {Uid}");

    public void NotifyChanged()
    {
        this.Message = $"Updated at {DateTime.Now.ToLongTimeString()}";
        this.Updated?.Invoke(this, EventArgs.Empty);
    }
}
