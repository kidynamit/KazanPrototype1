using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour
{
	public float deadZone = 5f;             // The number of degrees for which the rotation isn't controlled by Mecanim.
	
	
	private Transform player;               // Reference to the player's transform.
	private EnemySight enemySight;          // Reference to the EnemySight script.
	private NavMeshAgent nav;               // Reference to the nav mesh agent.
	private Animator anim;                  // Reference to the Animator.
	private HashIDs hash;                   // Reference to the HashIDs script.
	private AnimatorSetup animSetup;        // An instance of the AnimatorSetup helper class.
	
	
	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag(Tags.player).transform;
		enemySight = GetComponent<EnemySight>();
		nav = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
		
		// Making sure the rotation is controlled by Mecanim.
		nav.updateRotation = false;
		
		// Creating an instance of the AnimatorSetup class and calling it's constructor.
		//animSetup = new AnimatorSetup(anim, hash);
		
		// Set the weights for the shooting and gun layers to 1.
		anim.SetLayerWeight(1, 1f);
		anim.SetLayerWeight(2, 1f);
		
		// We need to convert the angle for the deadzone from degrees to radians.
		deadZone *= Mathf.Deg2Rad;
	}
	
	
	void Update () 
	{
		// Calculate the parameters that need to be passed to the animator component.
		NavAnimSetup();
	}
	
	
	void OnAnimatorMove ()
	{
		// Set the NavMeshAgent's velocity to the change in position since the last frame, by the time it took for the last frame.
		nav.velocity = anim.deltaPosition / Time.deltaTime;
		
		// The gameobject's rotation is driven by the animation's rotation.
		transform.rotation = anim.rootRotation;
	}
	
	
	void NavAnimSetup ()
	{

	}
	
	
	float FindAngle (Vector3 fromVector, Vector3 toVector, Vector3 upVector)
	{
		if(toVector == Vector3.zero)
			return 0f;

		float angle = Vector3.Angle(fromVector, toVector);
		Vector3 normal = Vector3.Cross (fromVector, toVector);	
		angle *= Mathf.Sign(Vector3.Dot(normal, upVector));
		angle *= Mathf.Deg2Rad;
		
		return angle;
	}
}
