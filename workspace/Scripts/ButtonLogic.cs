using UnityEngine;
using System.Collections;

public class ButtonLogic : TouchLogic 
{
	public bool enableTouch = true;
	public bool active;
	
	void Update()
	{
		if(enableTouch)
			CheckTouches();
		else
			active = false;
	}
	
	void OnTouch()
	{
		active = true;
	}
	
	void OffTouch()
	{
		active = false;
	}
}