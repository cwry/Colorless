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
            if(nextX <= minX) {
                nextX = minX;
                if(transform.position.x > minX) {
                    onMin.Invoke();
                }
            }

            if(nextX >= maxX) {
                nextX = maxX;
                if(transform.position.x < maxX) {
                    onMin.Invoke();
                }
            }

            transform.position = new Vector3(nextX, transform.position.y, transform.position.z);
            lastTargetX = distanceCheckTarget.transform.position.x;
            if (!Input.GetKey(KeyCode.V)) {
                lastTargetX = null;
                onDetached.Invoke();
            }
        }else if (!Globals.suppressPlayInput && Input.GetKey(KeyCode.V) && distanceCheck >= 0 && Mathf.Abs(distanceCheckTarget.transform.position.x - transform.position.x) <= distanceCheck) {
            lastTargetX = distanceCheckTarget.transform.position.x;
            onAttached.Invoke();
        }
    }
}
