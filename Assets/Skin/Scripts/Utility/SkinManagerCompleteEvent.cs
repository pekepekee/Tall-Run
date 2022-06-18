using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SkinManagerCompleteEvent : MonoBehaviour
{
    [SerializeField] SkinManager manager;
    [SerializeField] UnityEvent Event;
    bool managerStarted, done;

    private void Start()
    {
        manager.StartEvent += _ => managerStarted = true;
    }

    private void Update()
    {
        if (managerStarted && !done && manager.Buttons.Count == manager.Unlocks.Count)
        {
            done = true;
            Event.Invoke();
        }
    }
}