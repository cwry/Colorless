using UnityEngine;
using System.Collections;
using ByteSheep.Events;

public class Draggable : MonoBehaviour {
    public float distanceCheck;
    public GameObject distanceCheckTarget;
    public float minX = 0;
    public AdvancedEvent onMin;
    public float maxX = 0;
    public AdvancedEvent onMax;
    public AdvancedEvent onAttached;
    public AdvancedEvent onDetached;

    private float? lastTargetX = null;

    void Update() {
        if(lastTargetX != null) {
            float nextX = transform.position.x + (distanceCheckTarget.transform.position.x - (float)lastTargetX);
            if (nextX != transform.position.x && Mathf.Sign(distanceCheckTarget.transform.position.x - transform.position.x) == Mathf.Sign((distanceCheckTarget.transform.position.x - (float)lastTargetX))){
                lastTargetX = null;
                onDetached.Invoke();
                EntityController ec = distanceCheckTarget.GetComponent<EntityController>();
                if (ec != null) ec.stopPushAnimation();
                return;
            }
            if(nextX <= minX) {
                nextX = minX;
                if(transform.position.x > minX) {
                    lastTargetX = null;
                    onMin.Invoke();
                    onDetached.Invoke();
                    EntityController ec = distanceCheckTarget.GetComponent<EntityController>();
                    if (ec != null) ec.stopPushAnimation();
                    return;
                }
            }

            if(nextX >= maxX) {
                nextX = maxX;
                if(transform.position.x < maxX) {
                    lastTargetX = null;
                    onMax.Invoke();
                    onDetached.Invoke();
                    EntityController ec = distanceCheckTarget.GetComponent<EntityController>();
                    if (ec != null) ec.stopPushAnimation();
                    return;
                }
            }

            transform.position = new Vector3(nextX, transform.position.y, transform.position.z);
            lastTargetX = distanceCheckTarget.transform.position.x;
            if (!Input.GetKey(KeyCode.V) && !Input.GetKeyDown(KeyCode.Joystick1Button1)) {
                lastTargetX = null;
                onDetached.Invoke();
                EntityController ec = distanceCheckTarget.GetComponent<EntityController>();
                if (ec != null) ec.stopPushAnimation();
            }
        }else if (!Globals.suppressPlayInput && (Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.Joystick1Button1)) && distanceCheck >= 0 && Mathf.Abs(distanceCheckTarget.transform.position.x - transform.position.x) <= distanceCheck) {
            lastTargetX = distanceCheckTarget.transform.position.x;
            onAttached.Invoke();
            EntityController ec = distanceCheckTarget.GetComponent<EntityController>();
            if (ec != null) ec.playPushAnimation();
        }
    }
}
