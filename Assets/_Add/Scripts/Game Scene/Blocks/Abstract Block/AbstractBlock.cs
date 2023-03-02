using UnityEngine;

public class AbstractBlock : MonoBehaviour
{
    [SerializeField] protected string _tag;

    public string Tag => _tag;
}
