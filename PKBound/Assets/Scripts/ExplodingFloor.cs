using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class ExplodingFloor : MonoBehaviour
{
	Color initialColour;
		
	void Start()
	{
		initialColour = GetComponent<SpriteRenderer>().color;
		
		GetComponent<BoxCollider2D>().enabled = false;
	}

	public void Explode()
	{		
		GetComponent<SpriteRenderer>().color = Color.red;
		
		GetComponent<BoxCollider2D>().enabled = true;
		
		Invoke ("Reset", 0.2f);
	}
	
	void Reset()
	{		
		GetComponent<BoxCollider2D>().enabled = false;
		
		GetComponent<SpriteRenderer>().color = initialColour;	
	}
	
	
}
