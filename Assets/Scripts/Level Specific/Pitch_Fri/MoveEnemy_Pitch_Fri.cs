using UnityEngine;
using System.Collections;

public class MoveEnemy_Pitch_Fri : MonoBehaviour {
    public float speed = 1;

    void Update() {
        gameObject.transform.position = new Vector3(
            gameObject.transform.position.x + Time.deltaTime * speed,
            gameObject.transform.position.y,
            gameObject.transform.position.z
        );
    }
}
