using UnityEngine;
using System.Collections;

public class ColorAnimationTrigger : MonoBehaviour {
    public float animationSpeed;
    public float fadeDelay;
    public ColorlessSprite sprite;

    private float startTime;
    private float fadeTime;

    void OnTriggerEnter2D(Collider2D other) {
        startTime = Time.time;
        fadeTime = Time.time + fadeDelay;
    }

    void Update() {
        float state = -1;
        if(Time.time < fadeTime && Time.time >= startTime) {
            state = 1;
        }
        if((state == 1 && sprite.animationState < 1) || (state == -1 && sprite.animationState > 0)) sprite.animationState = Mathf.Min(1, Mathf.Max(0, sprite.animationState + state * animationSpeed * Time.deltaTime));
    }
}
