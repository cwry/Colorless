using UnityEngine;

public class EntityController : MonoBehaviour {
    private Rigidbody2D rb;
    private CircleCollider2D coll;

    private bool shouldJump = false;
    private bool jumping = false;

    public float groundBias = 0.1f;
    public float heightCorrectionBias = 1f;
    public float maxSpeed = 4f;
    public float acceleration = 2f;
    public float jumpForce = 5;
    public float maxJumpSlope = 45f;
    public float maxSlope = 45f;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
    }

    void Update() {
        shouldJump = shouldJump || Input.GetKeyDown("space");
    }

    void FixedUpdate() {
        float dir = Input.GetAxisRaw("Horizontal");
        RaycastHit2D ray = Physics2D.CircleCast(rb.position, coll.radius, Vector2.down, Mathf.Infinity, 1 << LayerMask.NameToLayer("Terrain"));
        float slope = Mathf.Atan2(ray.normal.x, ray.normal.y) * Mathf.Rad2Deg;
        bool isGrounded = ray.distance <= groundBias;

        if (!jumping && shouldJump && Mathf.Abs(slope) <= maxJumpSlope) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumping = true;
        }
        shouldJump = false;

        if(ray.distance > heightCorrectionBias) {
            jumping = true;
        }

        if(jumping && isGrounded && rb.velocity.y <= 0) {
            jumping = false;
        }

        if(!isGrounded && !jumping) {
            rb.position = new Vector2(rb.position.x, ray.centroid.y);
        }

        if (dir * rb.velocity.x < maxSpeed && (Mathf.Abs(slope) <= maxSlope || Mathf.Sign(dir) == Mathf.Sign(slope))) {
            rb.velocity += Vector2.right * dir * acceleration;
        }

        if (Mathf.Abs(rb.velocity.x) > maxSpeed) {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }

        if (!jumping && Mathf.Abs(dir) < 0.1) {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
