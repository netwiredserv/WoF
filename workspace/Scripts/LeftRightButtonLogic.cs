using UnityEngine;
using System.Collections;

public class LeftRightButtonLogic : TouchLogic 
{
	public GameObject player;
	private float moveSpeed;
	private int left_right;
	
	void Start()
	{
		PlayerStats pStats = player.GetComponent<PlayerStats>();
	}
	
	void Update()
	{
		moveSpeed = pStats.maxSpeed;
		if(pStats.facingRight)
		{left_right = 1;}
		else
		{left_right = -1;}
	}
	
	void OnTouch()
	{
		player.rigidbody2D.velocity = left_right * Vector2.right * moveSpeed;
	}
	
	void OffTouch()
	{
		player.rigidbody2D.velocity = 0;
	}
}