using UnityEngine;
using System.Collections;

public class MoveWolf : MonoBehaviour {
    void Awake() {
        iTween.MoveTo(gameObject, iTween.Hash("x", 0, "time", 16, "easeType", "linear"));
    }
}
