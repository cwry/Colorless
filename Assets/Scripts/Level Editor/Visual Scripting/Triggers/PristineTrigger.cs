using UnityEngine;
using System.Collections;
using uFAction;
using System;

//acts as a "curry-proxy" for visual scripting
public class PristineTrigger : MonoBehaviour {
    [SerializeField] private string nameForHumanReference;
    [SerializeField] private bool once = false;
    private bool fired = false;
    [ShowDelegate][SerializeField] private KickassDelegate onTrigger;

    public Action curryTrigger(){
        return () => {
            if(!once || !fired) {
                onTrigger.InvokeWithEditorArgs();
                fired = true;
            }
        };
    }
}