using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : ObjectPoolEntity<MonoBehaviour>
{
    private Dictionary<string, T> _poolMap;

    public ObjectPool(List<T> poolList)
    {
        _poolMap = new Dictionary<string, T>();
        
        GeneratePoolMap(poolList);
    }
    
    public bool TryAddEntityToPool(T objectPoolEntity)
    {
        if (!_poolMap.ContainsKey(objectPoolEntity.Tag))
        {
            _poolMap.Add(objectPoolEntity.Tag, objectPoolEntity);

            return true;
        }

        Debug.LogError("Error: This key is already reserved!");

        return false;
    }

    public bool TryGetEntity(string entityTag, out T objectPoolEntity)
    {
        if (_poolMap.ContainsKey(entityTag))
        {
            objectPoolEntity = _poolMap[entityTag];

            return true;
        }

        objectPoolEntity = null;

        return false;
    }

    private void GeneratePoolMap(List<T> poolList)
    {
        foreach (var entity in poolList)
        {
            TryAddEntityToPool(entity);
        }
    }
}