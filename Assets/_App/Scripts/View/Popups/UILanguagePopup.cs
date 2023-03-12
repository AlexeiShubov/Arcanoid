using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class UILanguagePopup : AbstractPopup
{
    private CanvasGroup _canvasGroup;
        
    public override void Init()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public override void Show()
    {
        base.Show();
    }

    public override void Hide()
    {
        _canvasGroup.blocksRaycasts = true;
        
        base.Hide();
    }
}
