using System;
using UnityEngine;
using UnityEngine.UI;

public class UIStartPanel : MonoBehaviour, IViewerable
{
    [SerializeField] private Button languageButton;
    [SerializeField] private Button playButton;

    public Action OnLanguageButtonOnClick;

    public void Init()
    {
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
        playButton.gameObject.SetActive(value);
        languageButton.gameObject.SetActive(value);
    }
    
    private void Subscribe()
    {
        playButton.onClick.AddListener(delegate {});
        languageButton.onClick.AddListener(OnLanguageButtonClick);
    }

    private void OnLanguageButtonClick()
    {
        OnLanguageButtonOnClick.Invoke();
    }
}
