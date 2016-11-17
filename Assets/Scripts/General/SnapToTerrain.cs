using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CircleCollider2D))]
public class SnapToTerrain : MonoBehaviour {
    private CircleCollider2D coll;

    void Awake() {
        coll = GetComponent<CircleCollider2D>();
    }

    void Update() {
        RaycastHit2D ray = Physics2D.CircleCast(transform.position, coll.radius, Vector2.down, Mathf.Infinity, 1 << LayerMask.NameToLayer("Terrain"));
        Debug.Log(ray.centroid);
        transform.position = new Vector3(transform.position.x, ray.centroid.y, transform.position.z);
    }

}
