using UnityEngine;

public class AbstractFactory
{
    private Transform _prefab;
    private Vector2 _spawnPosition;
    private Transform _parent;

    public AbstractFactory(Transform prefab, Vector2 spawnPosition, Transform parent)
    {
        _prefab = prefab;
        _spawnPosition = spawnPosition;
        _parent = parent;
    }

    public Transform Spawn()
    {
        return Object.Instantiate(_prefab, _spawnPosition, Quaternion.identity, _parent);
    }
}
