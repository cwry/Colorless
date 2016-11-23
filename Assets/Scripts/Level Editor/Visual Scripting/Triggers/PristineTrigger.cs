using UnityEngine;
using System.Collections;
using System;
using ByteSheep.Events;

//acts as a "curry-proxy" for visual scripting
public class PristineTrigger : MonoBehaviour {
    [SerializeField] private string nameForHumanReference;
    [SerializeField] private bool once = false;
    private bool fired = false;
    public AdvancedEvent onTrigger;

    public Action curryTrigger(){
        return () => {
            if(!once || !fired) {
                onTrigger.Invoke();
                fired = true;
            }
        };
    }
}