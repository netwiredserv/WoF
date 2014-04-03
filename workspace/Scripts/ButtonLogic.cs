using UnityEngine;
using System.Collections;

public class ButtonLogic : TouchLogic 
{
	public bool active;
	
	void OnTouch()
	{
		active = true;
	}
	
	void OffTouch()
	{
		active = false;
	}
}