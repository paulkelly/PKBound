using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class ExplodingFloor : MonoBehaviour
{	
	public GameObject explosion;
		
	void Start()
	{		
		GetComponent<BoxCollider2D>().enabled = false;
	}

	public void Explode()
	{				
		Vector3 location = transform.position;
		
		location.z = location.z - 3;
		
		GameObject explosionEffect = (GameObject) Instantiate(explosion, location, Quaternion.identity);
		
		Destroy (explosionEffect, 1.5f);
		
		GetComponent<BoxCollider2D>().enabled = true;
		
		Invoke ("Reset", 0.2f);
	}
	
	void Reset()
	{		
		GetComponent<BoxCollider2D>().enabled = false;
	}
	
	
}
