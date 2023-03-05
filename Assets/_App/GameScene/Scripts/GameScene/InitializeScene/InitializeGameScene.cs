using UnityEngine;

public class InitializeGameScene : MonoBehaviour
{
    private Localization _localization;

    private void Awake()
    {
        _localization = new Localization();
    }
}
