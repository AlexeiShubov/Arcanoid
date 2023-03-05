using UnityEngine;

public class ShowerFade : IShowing
{
    private readonly RectTransform _rectTransform;

    public ShowerFade(RectTransform rectTransform)
    {
        _rectTransform = rectTransform;
    }
    
    public void Show()
    {
        Debug.Log($"{nameof(GetType)} Show {_rectTransform.gameObject.name}");
    }

    public void Hide()
    {
        Debug.Log($"{nameof(GetType)} Hide {_rectTransform.gameObject.name}");
    }
}
