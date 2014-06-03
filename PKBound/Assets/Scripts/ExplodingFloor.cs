using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class ExplodingFloor : MonoBehaviour
{
	Color initialColour;
	
	public GameObject explosion;
		
	void Start()
	{
		initialColour = GetComponent<SpriteRenderer>().color;
		
		GetComponent<BoxCollider2D>().enabled = false;
	}

	public void Explode()
	{		
		//GetComponent<SpriteRenderer>().color = Color.red;
		
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
		
		//GetComponent<SpriteRenderer>().color = initialColour;	
	}
	
	
}
