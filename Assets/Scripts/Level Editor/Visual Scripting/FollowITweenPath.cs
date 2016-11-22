using UnityEngine;
using System.Collections;
using System;

public class FollowITweenPath : MonoBehaviour {
    public void move(GameObject go, iTweenPath path, float speed, bool reverse, Action done) {
        Vector3[] nodes = path.nodes.ToArray();
        if (reverse) Array.Reverse(nodes);
        iTween.MoveTo(go, iTween.Hash("path", nodes, "speed", speed, "easeType", "easeInOutSine", "onComplete", (Action<object>)((arg) => { if (done != null) done(); })));
    }
}
