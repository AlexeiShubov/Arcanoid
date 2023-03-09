using System;
using UnityEngine;
using UnityEngine.UI;

public class UIStartPopup : AbstractPopup
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button languageButton;

    public event Action OnClickPlayButton;
    public event Action OnClickLanguageButton;

    public override void Init()
    {
        playButton.onClick.AddListener(OnClickPlayButton.Invoke);
        languageButton.onClick.AddListener(OnClickLanguageButton.Invoke);
    }

    public override void Show()
    {
        base.Show();
    }

    public override void Hide()
    {
        base.Hide();
    }
}
