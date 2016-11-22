using UnityEngine;
using System.Collections;
using uFAction;

public class ColorTrigger : MonoBehaviour {
    public GameObject distanceCheckTarget;
    public float maxDistance = 1;
    [SerializeField] private bool once = false;
    private bool fired = false;
    [ShowDelegate][SerializeField] private KickassDelegate onTrigger;

    void Update() {
        if (!(!once || !fired)) return;
        if (!Globals.suppressPlayInput && (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.Joystick1Button2))) {
            if(maxDistance >= 0) {
                Vector2 delta = new Vector2(transform.position.x - distanceCheckTarget.transform.position.x, transform.position.y - distanceCheckTarget.transform.position.y);
                float distance = Mathf.Sqrt(delta.x * delta.x + delta.y * delta.y);
                if (distance > maxDistance) return;
            }
            fired = true;
            onTrigger.InvokeWithEditorArgs();
        }
    }
}
