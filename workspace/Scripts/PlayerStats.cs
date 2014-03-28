using UnityEngine;
using System.Collections;
 
public class CombatSystem : MonoBehaviour {

    public CharacterController controller;
    public int health = 1; 
	public int lives = 3;
	public bool PowerUp = false;
	private float pTimeLeft = 5f;
	
	public GameObject respawn;
	
    void Start () {
 
    }
 
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
 
    void onControllerColliderHit(ControllerColliderHit hit){
		if (hit.gameObject.tag == "Enemy" && !PowerUp){
			health = 0;
		}
    }
	
	void DeadCheck(){
		if (health <= 0){
			collider.enabled = false;
			lives -= 1;
			
			if (lives <= 0){
				Application.LoadLevel("GameOver");
			} else {
				Respawn ();
			}
		}
	}
	
	void Respawn (){
		respawn = GameObject.FindGameObjectWithTag("Respawn");
		player.transform = respawn.transform
		collider.enabled = true;
	}
}