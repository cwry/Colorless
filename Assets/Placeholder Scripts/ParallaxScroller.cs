using UnityEngine;
using System.Collections;

public class ParallaxScroller : MonoBehaviour {

    public float scrollFactor;

	void LateUpdate() {
        transform.position = new Vector3(Camera.main.transform.position.x * scrollFactor, transform.position.y, transform.position.z);
    }
}
