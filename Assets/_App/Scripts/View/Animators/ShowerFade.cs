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
        Debug.Log($"{nameof(GetType)} Show: {_transform.gameObject.name}");
    }

    public void Hide()
    {
        Debug.Log($"{nameof(GetType)} Hide: {_transform.gameObject.name}");
        _transform.gameObject.SetActive(false);
    }
}
