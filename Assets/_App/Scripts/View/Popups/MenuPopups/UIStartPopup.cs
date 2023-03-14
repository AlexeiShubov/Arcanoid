using System;
using UnityEngine;
using UnityEngine.UI;

public class UIStartPopup : AbstractPopup
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button languageButton;

    public override void Show(IShowing animator)
    {
        base.Show(animator);
    }

    public override void Hide(IShowing animator)
    {
        base.Hide(animator);
    }

    private void OnEnable()
    {
        playButton.onClick.AddListener(() => PopupManager.Instance.OnButtonClick(ButtonNames.Play));
        languageButton.onClick.AddListener(() => PopupManager.Instance.OnButtonClick(ButtonNames.Language));
    }

    private void OnDisable()
    {
        playButton.onClick.RemoveAllListeners();
        languageButton.onClick.RemoveAllListeners();
    }
}
