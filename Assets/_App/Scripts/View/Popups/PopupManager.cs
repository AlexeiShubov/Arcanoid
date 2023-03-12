using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance { get; private set; }
    
    [SerializeField] private List<ObjectPoolEntityPopup> _poolEntity;

    private ObjectPoolPopup _objectPoolPopup;
    private Stack<AbstractPopup> _openWindows;
    private Localization _localization;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            Init();

            return;
        }
        
        Destroy(gameObject);
    }

    public void Init()
    {
        _localization = new Localization();
        _objectPoolPopup = new ObjectPoolPopup(_poolEntity, transform);
        _openWindows = new Stack<AbstractPopup>();

        if (!_objectPoolPopup.TryGetObject(typeof(UIStartPopup), out AbstractPopup obj)) return;
        
        obj.Show();
        _openWindows.Push(obj);
    }

    public void ChangeLanguage(Localization.Languages language)
    {
        _localization.SetLanguage(language);
    }

    public void OnButtonDown(ButtonNamesEnum buttonName)
    {
        switch (buttonName)
        {
            case ButtonNamesEnum.Play:
                SceneManager.LoadScene("Game");
                
                break;
            case ButtonNamesEnum.Language:
                if (_objectPoolPopup.TryGetObject(typeof(UILanguagePopup), out AbstractPopup languagePopup))
                {
                    languagePopup.Show();
                    _openWindows.Push(languagePopup);
                }
                
                break;
            case ButtonNamesEnum.SelectLanguage:
                var currentPopup = _openWindows.Pop();
                currentPopup.Hide();
                _objectPoolPopup.TryReturnObject(typeof(UILanguagePopup), currentPopup);
                
                break;
        }
    }
    
    private void CloseAllWindows()
    {
        while (_openWindows.Count > 0)
        {
            var currentPopup = _openWindows.Pop();
            
            currentPopup.Hide();
            _objectPoolPopup.TryReturnObject(currentPopup.GetType(), currentPopup);
        }
    }
}
