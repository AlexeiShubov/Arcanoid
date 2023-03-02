using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PoolEntity
{
     public AbstractBlock Prefab;
     public int Count;

     public PoolEntity(AbstractBlock prefab, int count)
     {
          Prefab = prefab;
          Count = count;
     }
}

public class ObjectPool
{
     private EntitySO _entitySO;
     private Dictionary<string, Queue<AbstractBlock>> _poolMap;
     private Transform _parentForEntities;

     public ObjectPool(EntitySO entitySO, Transform parentForEntities)
     {
          _poolMap = new Dictionary<string, Queue<AbstractBlock>>();
          _entitySO = entitySO;
          _parentForEntities = parentForEntities;

          GeneratePoolMap(_entitySO);
     }

     private void GeneratePoolMap(EntitySO entitySO)
     {
          foreach (var entity in entitySO.EntitiesList)
          {
               AddBlockToMap(entity);
          }
     }

     private void AddBlockToMap(PoolEntity poolEntity)
     {
          if (!_poolMap.ContainsKey(poolEntity.Prefab.Tag))
          {
               _poolMap.Add(poolEntity.Prefab.Tag, GenerateBlocksToPool(poolEntity));
          }
     }

     private Queue<AbstractBlock> GenerateBlocksToPool(PoolEntity poolEntity)
     {
          var newQueue = new Queue<AbstractBlock>();
          var factory = new AbstractFactory(poolEntity.Prefab, Vector2.zero, _parentForEntities);
          
          for (var i = 0; i < poolEntity.Count; i++)
          {
               newQueue.Enqueue(factory.Spawn());
          }

          return newQueue;
     }
}
