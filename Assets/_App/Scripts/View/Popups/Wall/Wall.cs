using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private bool narrow;
    [SerializeField] private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        var screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        
        if (narrow)
        {
            boxCollider2D.size = new Vector2(10f, Screen.height);
        }
        else
        {
            boxCollider2D.size = new Vector2(Screen.width, 10f);
        }
    }
}
