using Assets.SimpleLocalization;

public class Localization
{
    public enum Languages
    {
        English,
        Russian
    }

    public void SetLanguage(Languages languages)
    {
        LocalizationManager.Read();
        LocalizationManager.Language = languages.ToString();
    }
}
