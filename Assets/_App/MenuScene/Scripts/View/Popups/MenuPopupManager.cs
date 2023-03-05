using UnityEngine;

public class MenuPopupManager : AbstractPopupManager
{
    public override void Init()
    {
        base.Init();
    }

    private void ClickPlayButton()
    {
        Debug.Log($"ClickPlayButton");
    }
    
    private void ClickLanguageButton()
    {
        Debug.Log($"ClickLanguageButton");
    }
    
    private void Subscribe()
    {
        UIStartPopup.OnClickPlayButton += ClickPlayButton;
        UIStartPopup.OnClickLanguageButton += ClickLanguageButton;
    }

    private void UnSubscribe()
    {
        UIStartPopup.OnClickPlayButton -= ClickPlayButton;
        UIStartPopup.OnClickLanguageButton -= ClickLanguageButton;
    }

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        UnSubscribe();
    }
}


