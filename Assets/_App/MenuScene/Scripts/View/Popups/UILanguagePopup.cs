using UnityEngine;

public class UILanguagePopup : AbstractPopup
{
    [SerializeField] private RectTransform rectTransform;

    public override void Init()
    {
        IShowing = new ShowerFade(rectTransform);
    }
}
