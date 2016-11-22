using UnityEngine;
using System.Collections;

public class ParallaxScroller : MonoBehaviour {

    public float scrollFactor;
    public Transform referencePosition = null;
    private float initial;
    private float start;

    void Awake() {
        initial = transform.position.x;
        start = Camera.main.transform.position.x;
    }

	void LateUpdate() {
        transform.position = new Vector3(initial + (Camera.main.transform.position.x - (referencePosition == null ? start : referencePosition.position.x)) * scrollFactor, transform.position.y, transform.position.z);
    }
}
