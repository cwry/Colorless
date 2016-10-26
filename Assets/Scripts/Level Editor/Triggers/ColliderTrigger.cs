using UnityEngine;
using System.Collections;
using uFAction;

public class ColliderTrigger : MonoBehaviour {
    [SerializeField] private string nameForHumanReference;
    [SerializeField] private string tagFilter = null;
    [ShowDelegate] public KickassDelegate onTriggerEnter;
    [ShowDelegate] public KickassDelegate onTriggerExit;
    [ShowDelegate] public KickassDelegate onTriggerStay;

    void OnTriggerEnter2D(Collider2D other) {
        if (!shouldTrigger(other)) return;
        onTriggerEnter.InvokeWithEditorArgs();
    }

    void OnTriggerExit2D(Collider2D other) {
        if (!shouldTrigger(other)) return;
        onTriggerExit.InvokeWithEditorArgs();
    }

    void OnTriggerStay2D(Collider2D other) {
        if (!shouldTrigger(other)) return;
        onTriggerStay.InvokeWithEditorArgs();
    }

    bool shouldTrigger(Collider2D other) {
        return tagFilter == null || tagFilter == "" || tagFilter == other.gameObject.tag;
    }
}