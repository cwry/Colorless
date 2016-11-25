using UnityEngine;
using Spine.Unity;

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

    public Spine.AnimationState animationState;
    public Spine.Skeleton skeleton;

    public SkeletonAnimation skeletonAnimation;
    public string walkAnimation;
    public float walkTimescaleFactor;
    public string idleAnimation;
    public float idleTimeScale;
    string currentAnimation;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<CircleCollider2D>();
    }

    void Start() {
        animationState = skeletonAnimation.state;
        skeleton = skeletonAnimation.skeleton;
    }

    void Update() {
        shouldJump = !Globals.suppressPlayInput && (shouldJump || Input.GetKeyDown("space") || Input.GetKeyDown(KeyCode.Joystick1Button0));
    }

    void FixedUpdate() {
        float dir = Input.GetAxisRaw("Horizontal");
        if (Globals.suppressPlayInput) dir = 0;
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

        if((Mathf.Abs(dir) < 0.1 || jumping)) {
            if (currentAnimation != idleAnimation) {
                currentAnimation = idleAnimation;
                animationState.SetAnimation(0, idleAnimation, true);
            }
            animationState.TimeScale = idleTimeScale;
        }else{
            if(currentAnimation != walkAnimation) {
                currentAnimation = walkAnimation;
                animationState.SetAnimation(0, walkAnimation, true);
            }
            animationState.TimeScale = Mathf.Abs(rb.velocity.x) * walkTimescaleFactor;
        }

        if (dir < - 0.1) {
            skeleton.flipX = true;
        } else if(dir > 0.1) {
            skeleton.flipX = false;
        }

        if (!jumping && Mathf.Abs(dir) < 0.1) {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}
