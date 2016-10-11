using UnityEngine;

[ExecuteInEditMode]
public class RenderCollider : MonoBehaviour {

    private PolygonCollider2D coll;

    void Start() {
        coll = GetComponent<PolygonCollider2D>();
    }

    void OnDrawGizmos() {
        Vector2[] pts = coll.points;
        Vector3 pos = coll.transform.position;
        Gizmos.color = Color.red;

        for (int i = 0; i < pts.Length; i++) {
            int end = (i + 1) % pts.Length;
            Gizmos.DrawLine(
                new Vector3(pts[i].x + pos.x, pts[i].y + pos.y),
                new Vector3(pts[end].x + pos.x, pts[end].y + pos.y)
            );
        }
    }

}