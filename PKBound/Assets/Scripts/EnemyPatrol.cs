using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour
{
	public float MOVEMENT_SPEED;
	public GameObject FLAG_PREFAB;
	
	Vector3 target;

	public GameObject[] patrolMoves;
	
	GameObject[] worldPatrolMoves;
	
	void Start()
	{
	
		worldPatrolMoves = new GameObject[patrolMoves.Length];
		for(int i=0; i<patrolMoves.Length; i++)
		{
			GameObject flag = (GameObject) Instantiate(FLAG_PREFAB, patrolMoves[i].transform.position, Quaternion.identity);
			flag.GetComponent<SpriteRenderer>().enabled = false;
			Destroy (patrolMoves[i]);
			worldPatrolMoves[i] = flag;
		}
	}
	
	void FixedUpdate()
	{		
		if(worldPatrolMoves.Length > 0)
		{
			target = ((GameObject) worldPatrolMoves[0]).transform.position;
		}
		
		Vector2 moveTo = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
		float distance = moveTo.magnitude;
		if(distance > MOVEMENT_SPEED)
		{
			moveTo = moveTo.normalized;
			transform.position = new Vector3(transform.position.x + (moveTo.x * MOVEMENT_SPEED), transform.position.y + (moveTo.y * MOVEMENT_SPEED), transform.position.z);
		}
		else
		{
			transform.position = new Vector3(transform.position.x + moveTo.x, transform.position.y + moveTo.y, transform.position.z);
		}
	}
	
	void OnTriggerStay2D(Collider2D collider)
	{
		GameObject flag = collider.gameObject;
		if(worldPatrolMoves.Length > 1 && flag.Equals(worldPatrolMoves[0]))
		{
			for(int i=0; i<worldPatrolMoves.Length-1; i++)
			{
				worldPatrolMoves[i] = worldPatrolMoves[i+1];
			}
			worldPatrolMoves[worldPatrolMoves.Length-1] = flag;
		}
	}
	
	
}
