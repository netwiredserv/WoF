using UnityEngine;
using System.Collections;
 
[RequireComponent(typeof (Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class TouchControls : MonoBehaviour {

	Animator anim;
	
    public GUITexture Left;
    public GUITexture Right;
    public GUITexture Jump;
 
    public float moveSpeed = 5f;
    public float jumpForce = 700f;
    public float maxJumpVelocity = 700f;  //Double check this
	private float move = 0;
	private bool facingRight = true;
 
    private bool moveLeft, moveRight, doJump = false;
	
	bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
 
	void Start() {
		anim = GetComponent<Animator>();
	}
	
    void Update () {
 
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
 
            if (t.phase == TouchPhase.Began)
            {
                if (Left.HitTest(t.position, Camera.main)){
                    moveLeft = true;
					move = -1;
				}
 
                if (Right.HitTest(t.position, Camera.main)){
					moveRight = true;
					move = 1;
				}

                if (Jump.HitTest(t.position, Camera.main))
					doJump = true;
            }
 
            if (t.phase == TouchPhase.Ended)
            {
                doJump = moveLeft = moveRight = false;
                rigidbody2D.velocity = Vector2.zero;
				move = 0;
            }
        }
    }
 
    void FixedUpdate()
    {
	
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
       anim.SetBool("Ground", grounded);
	   
        if (moveLeft)
            rigidbody2D.velocity = -Vector2.right * moveSpeed;
 
        if (moveRight)
            rigidbody2D.velocity = Vector2.right * moveSpeed;
			
		if (moveRight || moveLeft)
			anim.SetFloat("Speed", Mathf.Abs (move));
			
 
        if (doJump && grounded)
        {
			anim.SetBool("Ground", false);
            if (rigidbody2D.velocity.y < maxJumpVelocity)
            {
                rigidbody2D.AddForce(Vector2.up * jumpForce);
            } else {
                doJump = false;
            }
        }
		
		if(move > 0 && !facingRight){
			Flip ();
		}
		else if(move < 0 && facingRight){
			Flip ();
		}
    }
	
	void Flip(){
       facingRight = !facingRight;
       Vector3 theScale = transform.localScale;
       theScale.x *= -1;
       transform.localScale = theScale;
    }
}