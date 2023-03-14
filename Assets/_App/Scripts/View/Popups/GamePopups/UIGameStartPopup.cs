using UnityEngine.UI;
using UnityEngine;

public class UIGameStartPopup : AbstractPopup
{
    [SerializeField] private Button menuButton;

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
        menuButton.onClick.AddListener(() => PopupManager.Instance.OnButtonClick(ButtonNames.GameMenu));
    }

    private void OnDisable()
    {
        menuButton.onClick.RemoveAllListeners();
    }
}
