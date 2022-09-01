using System.Diagnostics;

namespace Blazr.OwningComponentBase.Data;

public class InstanceTrackerService
{
    public Dictionary<Guid, string> Instances = new Dictionary<Guid, string>();

    public void AddInstance(Guid id, string name)
    {
        if (!this.Instances.ContainsKey(id))
            this.Instances.Add(id, name);
    }
    
    public void RemoveInstance(Guid id)
    {
        if (!this.Instances.ContainsKey(id))
            this.Instances.Remove(id);
    }
}
