using UnityEngine;

public class AbstractFactory
{
    private AbstractBlock _prefab;
    private Vector2 _spawnPosition;
    private Transform _parent;

    public AbstractFactory(AbstractBlock prefab, Vector2 spawnPosition, Transform parent)
    {
        _prefab = prefab;
        _spawnPosition = spawnPosition;
        _parent = parent;
    }

    public AbstractBlock Spawn()
    {
        return Object.Instantiate(_prefab, _spawnPosition, Quaternion.identity, _parent);
    }
}
