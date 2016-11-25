using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

    void Start() {
        StartCoroutine (DoFade());
    }

    IEnumerator DoFade () {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        while (canvasGroup.alpha < 1) {
            canvasGroup.alpha += Time.deltaTime / 2;
            yield return null;
        }
        yield return null;
    }
}
