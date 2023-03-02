using UnityEngine;

public class InitializeMenuScene : MonoBehaviour
{
    [SerializeField] private Localization.Languages _startLanguage;
    
    private Localization _localization;
    
    private void Awake()
    {
        _localization = new Localization(_startLanguage);
    }
}
