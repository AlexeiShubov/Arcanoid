using UnityEngine.UI;
using UnityEngine;

public class UIGameMenuPopup : AbstractPopup
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button backButton;
    [SerializeField] private Button continueButton;
    
    public override void Show(IShowing animator)
    {
        base.Show(animator);
    }

    public override void Hide(IShowing animator)
    {
        base.Hide(animator);
    }

    private void OnEnable()
    {
        restartButton.onClick.AddListener(() => PopupManager.Instance.OnButtonClick(ButtonNames.Restart));
        backButton.onClick.AddListener(() => PopupManager.Instance.OnButtonClick(ButtonNames.GameBack));
        continueButton.onClick.AddListener(() => PopupManager.Instance.OnButtonClick(ButtonNames.Continue));
    }

    private void OnDisable()
    {
        restartButton.onClick.RemoveAllListeners();
        backButton.onClick.RemoveAllListeners();
        continueButton.onClick.RemoveAllListeners();
    }
}
