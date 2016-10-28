using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    [HideInInspector] public CameraFollowSettings cfs;
    public GameObject target;

    void Update() {
        if (cfs == null) return;
        Camera.main.orthographicSize = cfs.sanitizeCameraSize(Camera.main.orthographicSize);
        Camera.main.transform.position = new Vector3(cfs.sanitizeCameraXPos(target.transform.position.x), cfs.sanitizeCameraYPos(target.transform.position.y), Camera.main.transform.position.z);
    }
}
