using UnityEngine;
using TMPro;

namespace Assets.SimpleLocalization
{
	/// <summary>
	/// Localize text component.
	/// </summary>
    public class LocalizedText : MonoBehaviour
    {
        private TextMeshProUGUI _text;
        
        public string LocalizationKey;

        public void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
            
            Localize();

            LocalizationManager.LocalizationChanged += Localize;
        }

        public void OnDestroy()
        {
            LocalizationManager.LocalizationChanged -= Localize;
        }

        private void Localize()
        {
            _text.text = LocalizationManager.Localize(LocalizationKey);
        }
    }
}