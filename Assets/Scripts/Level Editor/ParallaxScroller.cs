using UnityEngine;
using System.Collections;

public class ParallaxScroller : MonoBehaviour {

    public float scrollFactor;
    private float start;

    void Awake() {
        start = Camera.main.transform.position.x;
    }

	void LateUpdate() {
        transform.position = new Vector3((Camera.main.transform.position.x - start) * scrollFactor, transform.position.y, transform.position.z);
    }
}
