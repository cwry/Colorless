using UnityEngine;
using System.Collections;

public class PlaceholderSound : MonoBehaviour {

	void Awake() {
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType(GetType()).Length > 1) {
            Destroy(gameObject);
        }
    }
}
