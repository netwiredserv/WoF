using UnityEngine;
using System.Collections;
 
public class EnemyController : MonoBehaviour {

	public float moveSpeed = 5f;
	public int move = 1;
	public bool hitPlayer = false;
	
    void Update () 
	{
		rigidbody2D.AddForce(move * Vector2.right * moveSpeed);
    }
	
	void OnCollisionEnter (Collision col)
    {
		if (col.gameObject.name != "Player")
		{
			Flip();
		}
		else
		{
			Debug.Log("Hit Player");
			hitPlayer = true;
		}
    }
	
	void Flip()
	{
       facingRight = !facingRight;
       Vector3 theScale = transform.localScale;
       theScale.x *= -1;
       transform.localScale = theScale;
	   move *= -1;
    }

}