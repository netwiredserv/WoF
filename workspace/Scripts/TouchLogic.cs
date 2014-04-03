using UnityEngine;
using System.Collections;

public class TouchLogic : MonoBehaviour {
	
    void CheckTouches () 
	{
 
        if (Input.touchCount > 0)
        {
			for (int t = 0; t < Input.touchCount; t++)
			{
				if (t.phase == TouchPhase.Began && hit.collider.name == this.name)
				{
					this.SendMessage("OnTouch");
				}
				
				if (t.phase == TouchPhase.Ended)
				{
					this.SendMessage("OffTouch");
				}
			}
        }
    }
}