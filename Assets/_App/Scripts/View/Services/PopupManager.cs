using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance { get; private set; }
    
    [SerializeField] private List<ObjectPoolEntityPopup> poolEntity;

    private IShowing _animator;
    private ObjectPoolPopup _objectPool;
    private Stack<AbstractPopup> _openPopups;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
            Init();
            
            DontDestroyOnLoad(gameObject);
            
            return;
        }
        
        Destroy(gameObject);
    }
    
    public void OnButtonClick(ButtonNames buttonName)
    {
        switch (buttonName)
        {
            case ButtonNames.Russian:
                OnLanguageButtonClick(Localization.Languages.Russian);

                return;
            
            case ButtonNames.English:
                OnLanguageButtonClick(Localization.Languages.English);

                return;
            
            case ButtonNames.Language:
                ShowPopup(typeof(UILanguagePopup));

                return;
            
            case ButtonNames.Play:
                OnPlayButtonClick();

                return;
            
            case ButtonNames.GameMenu:
                OnGameMenuButtonClick();

                return;
            
            case ButtonNames.Restart:
                OnRestartButtonClick();

                return;
            
            case ButtonNames.GameBack:
                OnGameBackButtonClick();

                return;
            
            case ButtonNames.Continue:
                OnContinueButtonClick();

                return;
        }
    }

    private void Init()
    {
        new Localization();
        _objectPool = new ObjectPoolPopup(poolEntity, transform);
        _openPopups = new Stack<AbstractPopup>();

        ShowPopup(typeof(UIStartPopup));
    }

    private void OnContinueButtonClick()
    {
        HideTopPopup();
        
        Debug.Log("Game Is Not Paused");
    }
    
    private void OnPlayButtonClick()
    {
        CloseAllPopups();
        ShowPopup(typeof(UIGameStartPopup));
        SceneManager.LoadScene(1);
    }

    private void OnGameBackButtonClick()
    {
        CloseAllPopups();
        ShowPopup(typeof(UIStartPopup));
        SceneManager.LoadScene(0);
        
        Debug.Log("Game Is Not Paused");
    }

    private void OnGameMenuButtonClick()
    {
        ShowPopup(typeof(UIGameMenuPopup));
        
        Debug.Log("Game On Pause");
    }

    private void OnRestartButtonClick()
    {
        HideTopPopup();
        
        Debug.Log("Game Restarted");
        Debug.Log("Game Is Not Paused");
    }

    private void OnLanguageButtonClick(Localization.Languages language)
    {
        new Localization().SetLanguage(language);

        HideTopPopup();
    }

    private void ShowPopup(Type popup)
    {
        _objectPool.TryGetObject(popup, out AbstractPopup uiPopup);
        uiPopup.Show(new ShowerFade(uiPopup.transform));
        _openPopups.Push(uiPopup);
    }

    private void HideTopPopup()
    {
        if (_openPopups.Count > 0)
        {
            var topPopup = _openPopups.Pop();
            
            topPopup.Hide(new ShowerFade(topPopup.transform));
            _objectPool.TryReturnObject(topPopup.GetType(), topPopup);
        }
    }

    private void CloseAllPopups()
    {
        AbstractPopup currentPopup;
        
        while (_openPopups.Count > 0)
        {
            currentPopup = _openPopups.Pop();
            
            _objectPool.TryReturnObject(currentPopup.GetType(), currentPopup);
            currentPopup.Hide(new ShowerFade(currentPopup.transform));
        }
    }
}
