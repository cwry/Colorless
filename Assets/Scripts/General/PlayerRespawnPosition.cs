using UnityEngine;
using System.Collections;

public class PlayerRespawnPosition : MonoBehaviour {

	void Awake() {
        if (Globals.respawnPosition != null) {
            Vector2 respawnPosition = (Vector2)Globals.respawnPosition;
            transform.position = new Vector3(respawnPosition.x, respawnPosition.y, transform.position.z);
            Globals.respawnPosition = null;
        }
    }
}
