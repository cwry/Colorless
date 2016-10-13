using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    public float jumpHight;

    public Transform groundPoint;
    public float radius;
    public LayerMask groundMask;

    bool isGrounded;
    Rigidbody2D rb2D;



	// Use this for initialization
	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 moveDir = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rb2D.velocity.y);
        rb2D.velocity = moveDir;

        isGrounded = Physics2D.OverlapCircle(groundPoint.position, radius, groundMask);

        if(Input.GetAxisRaw("Horizontal") == 1){
            transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        } else if(Input.GetAxisRaw("Horizontal") == -1){
            transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) { 
            rb2D.AddForce(new Vector2(0, jumpHight));
        }
	}

    void onDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundPoint.position, radius);
    } 

}
