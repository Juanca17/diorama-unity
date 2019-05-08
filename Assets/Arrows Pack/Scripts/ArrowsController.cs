using UnityEngine;
using System.Collections;

public class ArrowsController : MonoBehaviour 
{

	private Animator animator;  //Animator Controller for Arrow Controller
	private RuntimeAnimatorController ac; //Runtime from current Animator Controller for access to Animation info
	private float AnimationTime = 0.0f;
	private bool isRunning = false; //For one time method calling in Update method

	// Use this for initialization
	void Start () 
	{
		animator = gameObject.GetComponent<Animator>(); //Get Animator Controller from Arrow Controller.
		ac = animator.runtimeAnimatorController; //Get Runtime from current Animator Controller for access to Animation info

		for (int i = 0; i < ac.animationClips.Length; i++) 
		{   
			//Iterate over all Animation CLips 
			if (ac.animationClips [i].name == "Explode") 
			{ 
				//If Animation Clip name is "Explode"
				AnimationTime = ac.animationClips [i].length; //Then take length in Explode time
			} 
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
		    if (!isRunning)
		    {
			    StartCoroutine(Explode(AnimationTime)); //Play Explode animation
		    }
		}
	}

	private IEnumerator Explode(float time) //A method that creates a delay time length animation of "Explode" clip to make the animation was played completely. 
	{
		isRunning = true;

		animator.SetTrigger("Explode"); //Switch Animation State
		yield return new WaitForSeconds (time);
		Destroy(this.gameObject); //Delete Arrow game object from scene after Explode Animation

		isRunning = false;
	}
}
