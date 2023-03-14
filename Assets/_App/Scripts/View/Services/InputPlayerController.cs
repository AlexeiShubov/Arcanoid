using UnityEngine;

public class InputPlayerController : MonoBehaviour
{
    public static InputPlayerController Instance { get; private set; }

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
}
