using System.Collections.Generic;

public abstract class ObjectPool<TS, T>
{
    protected Dictionary<TS, Queue<T>> _map;
    
    public abstract bool TryGetObject(TS key, out T obj);
    public abstract bool TryReturnObject(TS key, T obj);
    public abstract bool TryAddObject(TS key, T obj);
}
