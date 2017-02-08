using UnityEngine;
using System.Collections;
using ByteSheep.Events;

public class TriggerOnAwake : MonoBehaviour {

    public AdvancedEvent onTrigger;

    void Awake() {
        onTrigger.Invoke();
    }
}
