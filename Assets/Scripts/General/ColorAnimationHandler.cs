﻿using UnityEngine;
using System.Collections;
using System;

public class ColorAnimationHandler : MonoBehaviour {
    public float animationSpeed;
    public float fadeDelay;
    public ColorlessSprite sprite;
    public ColorlessMesh mesh;

    private float targetState;
    private float previousState;
    private float fadeTime;
    private bool shouldFade;
    private Action onDone;
    private Action onFaded;
    private bool animating = false;

    void Awake(){
    }

    public void animateVS(float targetState, bool shouldFade, PristineTrigger onDone, PristineTrigger onFaded) {
        animate(targetState, shouldFade, onDone == null ? null : onDone.curryTrigger(), onFaded == null ? null : onFaded.curryTrigger());
    }

    void setState(float state){
        if (sprite != null){
            sprite.animationState = state;
        } 
        if (mesh != null) {
            mesh.animationState = state;
        }
    }

    float getState(){
        if(sprite != null){
            return sprite.animationState;
        }
        if(mesh != null) {
            return mesh.animationState;
        }
        return -1;
    }

    public void animate(float targetState, bool shouldFade, Action onDone, Action onFaded) {
        this.targetState = targetState;
        previousState = getState();
        this.onDone = onDone;
        this.onFaded = onFaded;
        this.shouldFade = shouldFade;
        fadeTime = -1;
        animating = true;
    }

    void Update() {
        if (!animating || Time.time < fadeTime) return;
        float sign = Mathf.Sign(targetState - previousState);

        setState(getState() + sign * animationSpeed * Time.deltaTime);
        if((targetState >= previousState && getState() >= targetState) || (targetState <= previousState && getState() <= targetState)) {
            setState(targetState);
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
