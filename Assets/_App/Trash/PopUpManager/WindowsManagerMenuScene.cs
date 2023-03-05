using UnityEngine;
using UnityEngine.Serialization;

public class WindowsManagerMenuScene : MonoBehaviour
{
    [SerializeField] private UIStartPanel buttonsPopUp;
    [FormerlySerializedAs("popUpLanguage")] [SerializeField] private UILanguagePanel uiLanguagePanel;
    
    public void Init(Localization localization)
    {
        buttonsPopUp.Init();
        buttonsPopUp.Show();
        buttonsPopUp.OnLanguageButtonOnClick += ShowLanguagePopUp;
        
        uiLanguagePanel.Init(localization);
        uiLanguagePanel.Hide();
        uiLanguagePanel.OnLanguageSelected += ShowButtonsPopUp;
    }
    
    private void ShowButtonsPopUp()
    {
        buttonsPopUp.Show();
        uiLanguagePanel.Hide();
    }

    private void ShowLanguagePopUp()
    {
        uiLanguagePanel.Show();
        buttonsPopUp.Hide();
    }

    private void OnDisable()
    {
        buttonsPopUp.OnLanguageButtonOnClick -= ShowLanguagePopUp;
        uiLanguagePanel.OnLanguageSelected -= ShowButtonsPopUp;
    }
}
