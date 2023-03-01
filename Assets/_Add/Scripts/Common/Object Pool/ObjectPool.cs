using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
     private EntitySO _entitySO;
     private Dictionary<string, Queue<Transform>> _poolMap;
     private Transform _parentForEntities;

     public ObjectPool(EntitySO entitySO, Transform parentForEntities)
     {
          _poolMap = new Dictionary<string, Queue<Transform>>();
          _entitySO = entitySO;
          _parentForEntities = parentForEntities;

          GeneratePoolMap(_entitySO);
     }

     private void GeneratePoolMap(EntitySO entitySO)
     {
          foreach (var entity in entitySO.EntitiesList)
          {
               AddEntityToMap(entity);
          }
     }

     private void AddEntityToMap(PoolEntity poolEntity)
     {
          if (!_poolMap.ContainsKey(poolEntity.Tag))
          {
               _poolMap.Add(poolEntity.Tag, GenerateQueueEntities(poolEntity));
          }
     }

     private Queue<Transform> GenerateQueueEntities(PoolEntity poolEntity)
     {
          var newQueue = new Queue<Transform>();
          var factory = new AbstractFactory(poolEntity.Prefab, Vector2.zero, _parentForEntities);
          
          for (var i = 0; i < poolEntity.Count; i++)
          {
               newQueue.Enqueue(factory.Spawn());
          }

          return newQueue;
     }
}
