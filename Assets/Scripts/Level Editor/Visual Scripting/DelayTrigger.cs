using UnityEngine;
using System.Collections;
using System;

public class DelayTrigger : MonoBehaviour {
    public void delayTrigger(PristineTrigger pt, float delay) {
        StartCoroutine(delayedExecution(pt, delay));
    }

    IEnumerator delayedExecution(PristineTrigger pt, float delay) {
        float targetTime = Time.time + delay;
        while (Time.time < targetTime) {
            yield return null;
        }
        pt.curryTrigger()();
    }
}
