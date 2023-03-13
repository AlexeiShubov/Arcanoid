using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            case ButtonNames.Play:
                CloseAllPopups();
                SceneManager.LoadScene(1);
                
                return;
            case ButtonNames.Language:
                _objectPool.TryGetObject(typeof(UILanguagePopup), out AbstractPopup popup);
                ShowPopup(popup);

                return;
            case ButtonNames.Russian:
                OnLanguageButtonClick(Localization.Languages.Russian);

                return;
            case ButtonNames.English:
                OnLanguageButtonClick(Localization.Languages.English);

                return;
        }
    }

    private void Init()
    {
        _objectPool = new ObjectPoolPopup(poolEntity, transform);
        _openPopups = new Stack<AbstractPopup>();

        if (!_objectPool.TryGetObject(typeof(UIStartPopup), out AbstractPopup popup)) return;
        
        ShowPopup(popup);
    }

    private void OnLanguageButtonClick(Localization.Languages language)
    {
        var popup = _openPopups.Peek();
        
        new Localization().SetLanguage(language);
        _objectPool.TryReturnObject(popup.GetType(), popup);
        
        HideTopPopup();
    }

    private void ShowPopup(AbstractPopup popup)
    {
        popup.Show(new ShowerFade(popup.transform));
        _openPopups.Push(popup);
    }

    private void HideTopPopup()
    {
        if (_openPopups.Count > 0)
        {
            _openPopups.Peek().Hide(new ShowerFade(_openPopups.Pop().transform));
        }
    }

    private void CloseAllPopups()
    {
        while (_openPopups.Count > 0)
        {
            _openPopups.Peek().Hide(new ShowerFade(_openPopups.Pop().transform));
        }
    }
}
