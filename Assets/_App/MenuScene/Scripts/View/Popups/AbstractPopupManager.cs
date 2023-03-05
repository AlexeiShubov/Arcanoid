using System.Collections.Generic;
using UnityEngine;

public class AbstractPopupManager : MonoBehaviour
{
    [SerializeField] protected List<ObjectPoolEntity<MonoBehaviour>> popupList;

    protected ObjectPool<ObjectPoolEntity<MonoBehaviour>> _objectPoolPopup;
    
    public virtual void Init()
    {
        foreach (var popup in popupList)
        {
            popup.Init();
        }
        
        _objectPoolPopup = new ObjectPool<ObjectPoolEntity<MonoBehaviour>>(popupList);
        
        if (_objectPoolPopup.TryGetEntity(EntityTag.UIStartPopup.ToString(),
                out ObjectPoolEntity<MonoBehaviour> poolEntity))
        {
            if (poolEntity.HasFreeEntity(out MonoBehaviour entity))
            {
                if (entity.TryGetComponent(out RectTransform RectTransform))
                {
                    Debug.Log("=====");
                    RectTransform.position = Vector2.zero;
                }
                
                entity.gameObject.SetActive(true);
            }
        }
    }
}
