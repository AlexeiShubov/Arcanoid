using UnityEngine;

public class Factory<T> where T : MonoBehaviour
{
    private readonly T _prefab;
    private readonly Vector3 _spawnPosition;
    private readonly Transform _container;

    public Factory(T prefab, Vector3 spawnPosition, Transform container)
    {
        _prefab = prefab;
        _spawnPosition = spawnPosition;
        _container = container;
    }

    public T Spawn(bool newEntityActive = false)
    {
        var newEntity = Object.Instantiate(_prefab, _spawnPosition, Quaternion.identity, _container);
        newEntity.GetComponent<RectTransform>().position = Vector3.zero;
        newEntity.gameObject.SetActive(newEntityActive);

        return newEntity;
    }
}
