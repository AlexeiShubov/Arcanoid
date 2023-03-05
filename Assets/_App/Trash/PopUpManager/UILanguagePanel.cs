using System;
using UnityEngine;
using UnityEngine.UI;

public class UILanguagePanel : MonoBehaviour, IViewerable
{
    [SerializeField] private Image foneImage;
    [SerializeField] private Button russLanguageButton;
    [SerializeField] private Button engLanguageButton;
    
    private Localization _localization;
    
    public Action OnLanguageSelected;

    public void Init(Localization localization)
    {
        _localization = localization;
        
        Subscribe();
    }
    
    public void Show()
    {
        SetVisibleButtons(true);
        
        Debug.LogError($"{name} show");
    }

    public void Hide()
    {
        SetVisibleButtons(false);
        
        Debug.LogError($"{name} hide");
    }

    private void SetVisibleButtons(bool value)
    {
        foneImage.enabled = value;
        russLanguageButton.gameObject.SetActive(value);
        engLanguageButton.gameObject.SetActive(value);
    }

    private void SwitchLanguage(Localization.Languages language)
    {
        OnLanguageSelected.Invoke();
        _localization.SetLanguage(language);
    }
    
    private void Subscribe()
    {
        russLanguageButton.onClick.AddListener(delegate { SwitchLanguage(Localization.Languages.Russian); });
        engLanguageButton.onClick.AddListener(delegate { SwitchLanguage(Localization.Languages.English); });
    }
}
