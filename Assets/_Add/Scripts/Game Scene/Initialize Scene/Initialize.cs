using UnityEngine;

public class Initialize : MonoBehaviour
{
    [SerializeField] private EntitySO _entitySo;

    private ObjectPool _objectPool;

    private void Awake()
    {
        _objectPool = new ObjectPool(_entitySo, transform);
    }
}
