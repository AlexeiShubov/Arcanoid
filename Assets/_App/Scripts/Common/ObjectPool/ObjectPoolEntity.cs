using System;
using UnityEngine;

public class ObjectPoolEntity<T>
{
    [SerializeField] protected string _tag;
    [SerializeField] protected int _count;
    [SerializeField] protected bool _autoExpand;
    [SerializeField] protected T _prefab;

    public string Tag => _tag ??= _prefab.GetType().ToString();
    public int Count => _count;
    public bool AutoExpand => _autoExpand;
    public T Prefab => _prefab;
}

[Serializable]
public class ObjectPoolEntityPopup : ObjectPoolEntity<AbstractPopup>
{
    
}
