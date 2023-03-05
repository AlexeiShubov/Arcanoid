using UnityEngine;

public class AbstractPopup : MonoBehaviour, IPopup
{
    public IShowing IShowing { get; set; }

    public virtual void Init()
    {
        
    }
}
