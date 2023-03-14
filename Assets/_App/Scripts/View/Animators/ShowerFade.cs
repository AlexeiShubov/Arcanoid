using UnityEngine;

public class ShowerFade : IShowing
{
    private readonly Transform _transform;

    public ShowerFade(Transform rectTransform)
    {
        _transform = rectTransform;
    }
    
    public void Show()
    {
        _transform.SetAsLastSibling();
        _transform.gameObject.SetActive(true);
    }

    public void Hide()
    {
        _transform.gameObject.SetActive(false);
    }
}
