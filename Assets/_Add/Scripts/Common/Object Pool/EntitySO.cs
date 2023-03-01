using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Pool Entities", fileName = "Entities")]
public class EntitySO : ScriptableObject
{
    [SerializeField] private List<PoolEntity> _entitiesList;

    public List<PoolEntity> EntitiesList => _entitiesList;
}
