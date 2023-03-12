using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
    [SerializeField] private List<EventContainer> eventContainers;
    [SerializeField] private UnityEvent<Localization.Languages> action;
    [SerializeField] private UnityEvent<ButtonNamesEnum> buttonAction;

    public void OnButtonAction(ButtonNamesEnum buttonName)
    {
        buttonAction.Invoke(buttonName);
    }
    
    public void OnAction(Localization.Languages language)
    {
        action.Invoke(language);
    }
    
    private void OnEnable()
    {
        foreach (var container in eventContainers)
        {
            container.AddListener(this);
        }
    }

    private void OnDisable()
    {
        foreach (var container in eventContainers)
        {
            container.RemoveListener(this);
        }
    }
}
