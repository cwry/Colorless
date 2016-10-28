using UnityEngine;
using System.Collections;
using System;

public class ColorAnimationHandler : MonoBehaviour {
    public float animationSpeed;
    public float fadeDelay;
    public ColorlessSprite sprite;

    private float targetState;
    private float previousState;
    private float fadeTime;
    private bool shouldFade;
    private Action onDone;
    private Action onFaded;
    private bool animating = false;

    public void animate(float targetState, bool shouldFade, Action onDone, Action onFaded) {
        this.targetState = targetState;
        previousState = sprite.animationState;
        this.onDone = onDone;
        this.onFaded = onFaded;
        this.shouldFade = shouldFade;
        fadeTime = -1;
        animating = true;
    }

    void Update() {
        if (!animating || Time.time < fadeTime) return;
        float sign = Mathf.Sign(targetState - previousState);

        sprite.animationState += sign * animationSpeed * Time.deltaTime;

        if((targetState >= previousState && sprite.animationState >= targetState) || (targetState <= previousState && sprite.animationState <= targetState)) {
            sprite.animationState = targetState;
            if(onDone != null) onDone();
            if (!shouldFade) {
                animating = false;
                return;
            }
            float ts = targetState;
            fadeTime = Time.time + fadeDelay;
            targetState = previousState;
            previousState = ts;
            onDone = onFaded;
            shouldFade = false;
        }
    }
}
