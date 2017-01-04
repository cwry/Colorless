using UnityEngine;
using System.Collections;

public class ClimbZone : MonoBehaviour {
    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag != "Player") return;
        other.gameObject.GetComponent<EntityController>().isInClimbZone = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag != "Player") return;
        other.gameObject.GetComponent<EntityController>().isInClimbZone = false;
    }
}
