using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolPopup : ObjectPoolMono<Type, AbstractPopup>
{
    private readonly List<ObjectPoolEntityPopup> _entity;
    private Transform _parent;

    public ObjectPoolPopup(List<ObjectPoolEntityPopup> entity, Transform parent)
    {
        _entity = entity;
        _parent = parent;

        GeneratePoolMap();
    }

    private void GeneratePoolMap()
    {
        foreach (var popup in _entity)
        {
            for (var i = 0; i < popup.Count; i++)
            {
                var newPopup = new GameObjectFactory<AbstractPopup>(popup.Prefab, _parent).Spawn();
                newPopup.Init();

                if (!TryAddObject(popup.Prefab.GetType(), newPopup))
                {
                    TryReturnObject(popup.Prefab.GetType(), newPopup);
                }
            }
        }
    }
}
