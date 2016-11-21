using UnityEngine;
using System.Collections;
using uFAction;

public class ColliderTrigger : MonoBehaviour {
    [SerializeField] private string nameForHumanReference;
    [SerializeField] private bool once = false;
    private bool fired = false;
    [SerializeField] private string tagFilter;
    [ShowDelegate] public KickassDelegate onTriggerEnter;
    [ShowDelegate] public KickassDelegate onTriggerExit;
    [ShowDelegate] public KickassDelegate onTriggerStay;

    void OnTriggerEnter2D(Collider2D other) {
        if (!shouldTrigger(other)) return;
        onTriggerEnter.InvokeWithEditorArgs();
        fired = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        if (!shouldTrigger(other)) return;
        onTriggerExit.InvokeWithEditorArgs();
        fired = true;
    }

    void OnTriggerStay2D(Collider2D other) {
        if (!shouldTrigger(other)) return;
        onTriggerStay.InvokeWithEditorArgs();
        fired = true;
    }

    bool shouldTrigger(Collider2D other) {
        return (!once || !fired) && (tagFilter == null || tagFilter == "" || tagFilter == other.gameObject.tag);
    }
}