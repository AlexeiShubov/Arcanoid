using UnityEngine;

public abstract class AbstractPopup : MonoBehaviour
{
    [SerializeField] protected RectTransform rectTransform;
    
    public virtual void Init()
    {
        
    }

    public virtual void Show(IShowing animator)
    {
        animator.Show();
    }

    public virtual void Hide(IShowing animator)
    {
        animator.Hide();
    }
}
