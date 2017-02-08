using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ToBeContinued : MonoBehaviour {

    public float speed = 1;
    public float showDuration = 3;

    public void show(PristineTrigger onDone) {
        show(onDone.curryTrigger());
    }

    public void show(Action onDone) {
        gameObject.SetActive(true);
        StartCoroutine(fade(onDone));
    }

    IEnumerator fade (Action onDone) {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        while (canvasGroup.alpha < 1) {
            canvasGroup.alpha += Time.deltaTime * speed;
            yield return null;
        }
        float showTime = 0;
        while(showTime < showDuration) {
            showTime += Time.deltaTime;
            yield return null;
        }
        if (onDone != null) onDone();
    }
}
