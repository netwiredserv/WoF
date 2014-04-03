using UnityEngine;
using System.Collections;
 
public class EnemyStats : MonoBehaviour 
{
	public GameObject player;
	private PlayerStats pStats;
	
	private EnemyController eController;
	
	void Start ()
	{
		pStats = player.GetComponent<PlayerStats>();
	}
    void Update () 
	{
		eController = this.gameObject.GetComponent<EnemyController>();
		
		if (eController.hitPlayer && pStats.PowerUp)
			Destroy(this.gameObject);
		else if (eController.hitPlayer && !pStats.PowerUp)
			pStats.health -= 1;
			
    }

}