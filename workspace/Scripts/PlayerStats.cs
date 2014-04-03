using UnityEngine;
using System.Collections;
 
public class PlayerStats : MonoBehaviour {

    public int health = 1; 
	public int lives = 3;
	public bool PowerUp = false;
	private float pTimeLeft = 5f;
	
	public GameObject respawn;
	
    void Start () 
	{}
 
    void Update () {
		DeadCheck ();
	   
		if (PowerUp && pTimeLeft > 0){
			//Invincible
			//KillsEnemies
			//DoubleJump??
			//Extra
			//Reduce Timer
		}
    }
	
	void DeadCheck(){
		if (health <= 0){
			lives -= 1;
			
			if (lives <= 0){
				Application.LoadLevel("GameOver");
			} else {
				Respawn ();
			}
		}
	}
	
	void Respawn ()
	{
		player.transform.position = respawn.transform.position;
	}
}