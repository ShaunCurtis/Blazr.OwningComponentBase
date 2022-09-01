using System.Diagnostics;

namespace Blazr.OwningComponentBase.Data;

public class TransientService : IDisposable
{
    public Guid Uid = Guid.NewGuid();

    public TransientService()
        => Debug.WriteLine($"{this.GetType().Name} - created instance: {Uid}");

    public virtual void Dispose()
        => Debug.WriteLine($"{this.GetType().Name} - Disposed instance: {Uid}");
}
