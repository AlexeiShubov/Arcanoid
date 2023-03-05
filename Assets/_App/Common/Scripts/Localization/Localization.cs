using Assets.SimpleLocalization;
using UnityEngine;

public class Localization
{
    public enum Languages
    {
        English,
        Russian
    }

    public Localization()
    {
        LocalizationManager.Language = Application.systemLanguage.ToString();
    }
    
    public void SetLanguage(Languages languages)
    {
        LocalizationManager.Read();
        LocalizationManager.Language = languages.ToString();
    }
}
