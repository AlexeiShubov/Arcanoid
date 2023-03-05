using UnityEngine;

public class InitializeMenuScene : MonoBehaviour
{
    [SerializeField] private MenuPopupManager menuPopupManager;
    
    private Localization _localization;

    private void Awake()
    {
        Instantiate(menuPopupManager).Init();

        _localization = new Localization();
    }
}
