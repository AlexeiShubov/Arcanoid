using UnityEngine;
using UnityEngine.UI;

public class UILanguagePopup : AbstractPopup
{
    [SerializeField] private Button russianButton;
    [SerializeField] private Button englishButton;

    public override void Init()
    {
        Subscribe();
    }
    
    public override void Show(IShowing animator)
    {
        base.Show(animator);
    }

    public override void Hide(IShowing animator)
    {
        base.Hide(animator);
    }
    
    private void Subscribe()
    {
        russianButton.onClick.AddListener(() => PopupManager.Instance.OnButtonClick(ButtonNames.Russian));
        englishButton.onClick.AddListener(() => PopupManager.Instance.OnButtonClick(ButtonNames.English));
    }
}
