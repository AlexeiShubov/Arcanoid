using UnityEngine;

public class InitializeMenuScene : MonoBehaviour
{
    [SerializeField] private PopupManager _popupManager;
    
    private Localization _localization;

    private void Awake()
    {
        _localization = new Localization();
        new GameObjectFactory<PopupManager>(_popupManager).Spawn(true).Init();
    }
}