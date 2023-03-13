using UnityEngine;

public class InitializeMenuScene : MonoBehaviour
{
    private Localization _localization;

    private void Awake()
    {
        _localization = new Localization();
    }
}
