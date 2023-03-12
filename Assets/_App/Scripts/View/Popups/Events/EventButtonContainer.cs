using UnityEngine;

[CreateAssetMenu(fileName = "EventButtonContainer", menuName = "_Add/Event Buttons Listeners")]
public class EventButtonContainer : EventContainer
{
    [SerializeField] private ButtonNamesEnum _buttonName;
    
    protected override void InvokeEvent()
    {
        foreach (var item in _eventListeners)
        {
            item.OnButtonAction(_buttonName);
        }
    }
}
