using UnityEngine;
using System.Collections;

public class NewArrows : MonoBehaviour 
{
	// Update is called once per frame
	void Update () 
	{
	    if(Input.GetKeyDown(KeyCode.Return)) 
		{
			Application.LoadLevel (Application.loadedLevelName);
		}
	}
}
