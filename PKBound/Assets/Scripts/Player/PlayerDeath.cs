using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

	void KillPlayer()
	{
		Application.LoadLevel(0);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		KillPlayer();
	}
}
