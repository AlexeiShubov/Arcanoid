using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance { get; private set; }
    
    [SerializeField] private List<ObjectPoolEntityPopup> _poolEntity;

    private ObjectPoolPopup _objectPool;
    private Stack<AbstractPopup> _openWindows;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            return;
        }
        
        Destroy(gameObject);
    }

    public void Init()
    {
        _objectPool = new ObjectPoolPopup(_poolEntity, transform);
        _openWindows = new Stack<AbstractPopup>();

        if (!_objectPool.TryGetObject(typeof(UIStartPopup), out AbstractPopup obj)) return;
        
        obj.Show();
        _openWindows.Push(obj);
    }

    private void CloseAllWindows()
    {
        while (_openWindows.Count > 0)
        {
            _openWindows.Pop().Hide();
        }
    }
}
