using System;
using System.Collections.Generic;
using UnityEngine;

public enum EntityTag
{
    UIStartPopup,
    UILanguagePopup
}

[Serializable]
public class ObjectPoolEntity<T> where T : MonoBehaviour
{
    [SerializeField] private EntityTag entityTag;
    [SerializeField] private T prefab;
    [SerializeField] private int defaultCount;
    [SerializeField] private bool autoExpand;
    [SerializeField] private Transform container;

    private Queue<T> _pool;
    private Factory<T> _factory;

    public string Tag => entityTag.ToString();
    public T Prefab => prefab;
    public int DefaultCount => defaultCount;
    public bool AutoExpand => autoExpand;

    public ObjectPoolEntity(EntityTag entityTag, T prefab, int defaultCount, bool autoExpand)
    {
        this.entityTag = entityTag;
        this.prefab = prefab;
        this.defaultCount = defaultCount;
        this.autoExpand = autoExpand;
        container = null;
        
        CreatePool();
    }
    
    public ObjectPoolEntity(EntityTag entityTag, T prefab, int defaultCount, bool autoExpand, Transform container)
    {
        this.entityTag = entityTag;
        this.prefab = prefab;
        this.defaultCount = defaultCount;
        this.autoExpand = autoExpand;
        this.container = container;
        
        CreatePool();
    }

    public void Init()
    {
        CreatePool();
    }

    public bool HasFreeEntity(out T entity)
    {
        if (_pool == null)
        {
            CreatePool();
        }

        if (_pool.Count > 0)
        {
            entity = _pool.Dequeue();
            
            return true;
        }

        entity = autoExpand ? CreateEntity() : null;
        
        Debug.Log("Error: No free entity!");
        
        return entity != null;
    }

    public void ReturnEntityToPool(T entity, bool entityActive = false)
    {
        entity.gameObject.SetActive(entityActive);
        _pool.Enqueue(entity);
    }
    
    private void CreatePool()
    {
        _pool = new Queue<T>();
        _factory = new Factory<T>(prefab, Vector3.zero, container);
        
        for (var i = 0; i < defaultCount; i++)
        {
            CreateEntity();
        }
    }

    private T CreateEntity()
    {
        var newEntity = _factory.Spawn();
        _pool.Enqueue(newEntity);
        
        return newEntity;
    }
}
