using UnityEngine;

public abstract class AbstractPopup : MonoBehaviour
{
    [SerializeField] protected RectTransform rectTransform;
    
    public virtual void Init()
    {
        
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
        gameObject.transform.SetAsLastSibling();
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
