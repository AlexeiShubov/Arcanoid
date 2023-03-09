using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolMono<TS, T> : ObjectPool<TS, T> where T : MonoBehaviour
{
    public ObjectPoolMono()
    {
        _map = new Dictionary<TS, Queue<T>>();
    }
    
    public override bool TryGetObject(TS key, out T obj)
    {
        obj = _map.ContainsKey(key) ? _map[key].Dequeue() : default;

        return obj != default;
    }

    public override bool TryReturnObject(TS key, T obj)
    {
        if (!_map.ContainsKey(key)) return false;
        
        _map[key].Enqueue(obj);

        return true;
    }

    public override bool TryAddObject(TS key, T obj)
    {
        if (_map.ContainsKey(key)) return false;
        
        var q = new Queue<T>();
            
        q.Enqueue(obj);
        _map.Add(key, q);

        return true;
    }
}
