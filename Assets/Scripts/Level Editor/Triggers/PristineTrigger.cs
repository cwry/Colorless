using UnityEngine;
using System.Collections;
using uFAction;

//acts as a "curry-proxy" for visual scripting
public class PristineTrigger : MonoBehaviour {
    [SerializeField]
    private string nameForHumanReference;
    [ShowDelegate]
    [SerializeField]
    private KickassDelegate onTrigger;
}