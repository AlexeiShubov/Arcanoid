using UnityEngine;

public class InitializeGameScene : MonoBehaviour
{
    [SerializeField] private Localization.Languages _startLanguage;
    [SerializeField] private EntitySO _entitySo;

    private Localization _localization;
    private ObjectPool _objectPool;

    private void Awake()
    {
        _localization = new Localization(_startLanguage);
        _objectPool = new ObjectPool(_entitySo, transform);
    }
}
