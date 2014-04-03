using UnityEngine;
using System.Collections;
 
public class PlayerController : MonoBehaviour {

    public GUITexture Left;
    public GUITexture Right;
    public GUITexture Jump;
	private ButtonLogic rScript;
	private ButtonLogic lScript;
	private ButtonLogic jScript;
 
	public bool rButton, lButton, jButton;
 
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
	
    void Start () 
	{
		rScript = Right.GetComponent<ButtonLogic>();
		lScript = Left.GetComponent<ButtonLogic>();
		jScript = Jump.GetComponent<ButtonLogic>();
	}
 
    void Update () 
	{
		rButton = rScript.active;
		lButton = lScript.active;
		jButton = jScript.active;
		
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		
		if (jButton && grounded)
			rigidbody2D.AddForce(Vector2.up * jumpForce);
    }
	
	void FixedUpdate()
	{
		if (rButton)
			move = 1;
		if (lButton)
			move = -1;
		if(!lButton && !rButton)
			move = 0;
			
		rigidbody2D.AddForce(move * Vector2.right * moveSpeed);
		
		if(move > 0 && !facingRight)
		{Flip ();}
		else if(move < 0 && facingRight)
		{Flip ();}
	}
	void Flip()
	{
       facingRight = !facingRight;
       Vector3 theScale = transform.localScale;
       theScale.x *= -1;
       transform.localScale = theScale;
    }

}