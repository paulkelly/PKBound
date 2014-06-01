using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Break();
	}
}
