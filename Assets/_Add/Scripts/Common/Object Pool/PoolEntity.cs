using System;
using UnityEngine;

[Serializable]
public class PoolEntity
{
    public Transform Prefab;
    public int Count;
    public string Tag;

    public PoolEntity(Transform prefab, int count, string tag)
    {
        Prefab = prefab;
        Count = count;
        Tag = tag;
    }
}
