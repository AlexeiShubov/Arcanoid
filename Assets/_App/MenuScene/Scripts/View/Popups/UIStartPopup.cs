using System;
using UnityEngine;
using UnityEngine.UI;

public class UIStartPopup : AbstractPopup
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Button playButton;
    [SerializeField] private Button languageButton;

    public static Action OnClickPlayButton;
    public static Action OnClickLanguageButton;

    public override void Init()
    {
        IShowing = new ShowerFade(rectTransform);
        playButton.onClick.AddListener(OnClickPlayButton.Invoke);
        languageButton.onClick.AddListener(OnClickLanguageButton.Invoke);
    }
}
