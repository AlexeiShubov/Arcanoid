using UnityEngine;

[CreateAssetMenu(fileName = "EventLanguageContainer", menuName = "_Add/Event Listeners")]
public class EventLanguageContainer : EventContainer
{
    [SerializeField] private Localization.Languages language;

    protected override void InvokeEvent()
    {
        foreach (var item in _eventListeners)
        {
            item.OnAction(language);
        }
    }
}
