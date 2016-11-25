using UnityEngine;
using System.Collections;
using System;

public class Tween : MonoBehaviour {
    public void tween(GameObject target, Transform goal, float time, PristineTrigger done) {
        iTween.RotateTo(target, iTween.Hash("rotation", goal.transform.eulerAngles, "time", time, "easeType", "easeInOutSine"));
        iTween.MoveTo(target, iTween.Hash("position", goal.transform.position, "time", time, "easeType", "easeInOutSine", "onComplete", (Action<object>)((arg) => { if (done != null) done.curryTrigger()(); })));
        iTween.ScaleTo(target, iTween.Hash("scale", goal.transform.localScale, "time", time, "easeType", "easeInOutSine"));

    }
}
