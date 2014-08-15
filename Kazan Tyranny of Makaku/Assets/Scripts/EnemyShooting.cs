
using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour
{
	public float maximumDamage = 120f;                  // The maximum potential damage per shot.
	public float minimumDamage = 45f;                   // The minimum potential damage per shot.
	public AudioClip shotClip;                          // An audio clip to play when a shot happens.
	public float flashIntensity = 3f;                   // The intensity of the light when the shot happens.
	public float fadeSpeed = 10f;                       // How fast the light will fade after the shot.
	
	
	private Animator anim;                              // Reference to the animator.
	private HashIDs hash;                               // Reference to the HashIDs script.
	private LineRenderer laserShotLine;                 // Reference to the laser shot line renderer.
	private Light laserShotLight;                       // Reference to the laser shot light.
	private SphereCollider col;                         // Reference to the sphere collider.
	private Transform player;                           // Reference to the player's transform.
	//private PlayerHealth playerHealth;                  // Reference to the player's health.
	private bool shooting;                              // A bool to say whether or not the enemy is currently shooting.
	private float scaledDamage;                         // Amount of damage that is scaled by the distance from the player.
	
	
	void Awake ()
	{
		// Setting up the references.
		anim = GetComponent<Animator>();
		laserShotLine = GetComponentInChildren<LineRenderer>();
		laserShotLight = laserShotLine.gameObject.light;
		col = GetComponent<SphereCollider>();
		player = GameObject.FindGameObjectWithTag(Tags.player).transform;
		hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
		
		// The line renderer and light are off to start.
		laserShotLine.enabled = false;
		laserShotLight.intensity = 0f;
		
		// The scaledDamage is the difference between the maximum and the minimum damage.
		scaledDamage = maximumDamage - minimumDamage;
	}
	
	
	void Update ()
	{
		// Cache the current value of the shot curve.
		float shot = anim.GetFloat(hash.shotFloat);
		
		// If the shot curve is peaking and the enemy is not currently shooting...
		if(shot > 0.5f && !shooting)
			// ... shoot
			Shoot();
		
		// If the shot curve is no longer peaking...
		if(shot < 0.5f)
		{
			// ... the enemy is no longer shooting and disable the line renderer.
			shooting = false;
			laserShotLine.enabled = false;
		}
		
		// Fade the light out.
		laserShotLight.intensity = Mathf.Lerp(laserShotLight.intensity, 0f, fadeSpeed * Time.deltaTime);
	}
	
	
	void OnAnimatorIK (int layerIndex)
	{

	}
	
	
	void Shoot ()
	{

	}
	
	
	void ShotEffects ()
	{

	}
}