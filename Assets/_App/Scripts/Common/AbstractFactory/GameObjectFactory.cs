using UnityEngine;

public class GameObjectFactory<T> : AbstractFactory<T> where T : MonoBehaviour
{
    private readonly T _prefab;
    private readonly Transform _parent;

    public GameObjectFactory(T prefab)
    {
        _prefab = prefab;
        _parent = null;
    }

    public GameObjectFactory(T prefab, Transform parent)
    {
        _prefab = prefab;
        _parent = parent;
    }

    public override T Spawn(bool newEntityActive = default, Vector2 spawnPosition = default)
    {
        var prefab = Object.Instantiate(_prefab, spawnPosition, Quaternion.identity, _parent);
        
        prefab.gameObject.SetActive(newEntityActive);

        return prefab;
    }
}
