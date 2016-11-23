using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using ByteSheep.Events;

public class ColliderTrigger : MonoBehaviour {
    [SerializeField] private string nameForHumanReference;
    [SerializeField] private bool once = false;
    private bool fired = false;
    [SerializeField] private string tagFilter;
    public AdvancedEvent onTriggerEnter;
    public AdvancedEvent onTriggerExit;
    public AdvancedEvent onTriggerStay;

    void OnTriggerEnter2D(Collider2D other) {
        if (!shouldTrigger(other)) return;
        onTriggerEnter.Invoke();
        fired = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        if (!shouldTrigger(other)) return;
        onTriggerExit.Invoke();
        fired = true;
    }

    void OnTriggerStay2D(Collider2D other) {
        if (!shouldTrigger(other)) return;
        onTriggerStay.Invoke();
        fired = true;
    }

    bool shouldTrigger(Collider2D other) {
        return (!once || !fired) && (tagFilter == null || tagFilter == "" || tagFilter == other.gameObject.tag);
    }
}