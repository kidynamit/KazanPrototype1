using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public AudioClip shoutingClip;      // Audio clip of the player shouting.
	public float turnSmoothing = 15f;   // A smoothing value for turning the player.
	public float speedDampTime = 0.1f;  // The damping for the speed parameter
	
	
	private Animator anim;              // Reference to the animator component.
	private HashIDs hash;               // Reference to the HashIDs.
	
	
	void Awake ()
	{
		// Setting up the references.
		anim = GetComponent<Animator>();
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
		
		// Set the weight of the shouting layer to 1.
		anim.SetLayerWeight(1, 1f);
	}
	
	
	void FixedUpdate ()
	{

	}
	
	
	void Update ()
	{

	}
	
	
	void MovementManagement (float horizontal, float vertical, bool sneaking)
	{

	}
	
	
	void Rotating (float horizontal, float vertical)
	{

	}
	
	
	void AudioManagement (bool shout)
	{

	}
}