using UnityEngine;
using System.Collections;

public class DeathplaneTrigger : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other) {
        other.gameObject.transform.position = new Vector3(-5, -1, other.gameObject.transform.position.z);
    }
}
