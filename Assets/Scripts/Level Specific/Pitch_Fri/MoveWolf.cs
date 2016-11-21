using UnityEngine;
using System.Collections;

public class MoveWolf : MonoBehaviour {
    public float speed = 1;
    public float max;

    void Update() {
        if(transform.position.x >= max) return;
        transform.position = new Vector3(
            transform.position.x + Time.deltaTime * speed,
            transform.position.y,
            transform.position.z
        );
    }
}
