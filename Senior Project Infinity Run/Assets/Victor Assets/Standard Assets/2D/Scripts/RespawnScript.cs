using UnityEngine;
using System.Collections;

public class RespawnScript : MonoBehaviour {

	public Transform respawnPoint; //Place holder for the spawn point

	// Triggers when the player enters the water
	void OnTriggerEnter(Collider other)
	{
		// Moves the player to the spawn point
		other.gameObject.transform.position = respawnPoint.position;
	}
}
