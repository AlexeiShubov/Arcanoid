using UnityEngine;
using Assets.SimpleLocalization;

public class InitializeMenuScene : MonoBehaviour
{
    private void Awake()
    {
        LocalizationManager.Language = Application.systemLanguage.ToString();
        Debug.Log("sdf");
    }
}
