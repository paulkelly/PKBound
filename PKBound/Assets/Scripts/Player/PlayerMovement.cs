using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {

	public float MOVEMENT_THRESHOLD;
	public float MOVEMENT_SPEED;
	
	public GameObject FLAG_PREFAB;

	Vector3 target;
	
	ArrayList queuedMoves = new ArrayList();

	Animator anim;

	void Start()
	{
		anim = this.GetComponent<Animator>();
		target = transform.position;
	}

	void FixedUpdate()
	{		
		if(queuedMoves.Count > 0)
		{
			target = ((GameObject) queuedMoves[0]).transform.position;
		}
		
		Vector2 moveTo = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
		
		float distance = moveTo.magnitude;
		if(distance > MOVEMENT_SPEED)
		{
			moveTo = moveTo.normalized;
			transform.position = new Vector3(transform.position.x + (moveTo.x * MOVEMENT_SPEED), transform.position.y + (moveTo.y * MOVEMENT_SPEED), transform.position.z);
			RotateToFaceMovementDirection((moveTo.x * MOVEMENT_SPEED), (moveTo.y * MOVEMENT_SPEED));
			PlayWalkAnimation();
		}
		else
		{
			transform.position = new Vector3(transform.position.x + moveTo.x, transform.position.y + moveTo.y, transform.position.z);
			RotateToFaceMovementDirection((moveTo.x), (moveTo.y));
			StopWalkAnimation();
		}
	}
	
	void RotateToFaceMovementDirection(float v, float h)
	{
	
		Vector2 direction = new Vector2 (h, v);
		
		if (direction.magnitude > 0.1f)
		{
			Vector3 rotation = new Vector3( 0, 0, Mathf.Atan2(-v, h) * 180 / Mathf.PI);
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler (rotation), 0.4f);
		}
	}
	
	public void MoveTo(Vector3 position)
	{
		ClearQueuedMoves();
		target = position;
	}
	
	public void QueuedMoveTo(Vector3 position)
	{
		if(queuedMoves.Count == 0)
		{
			target.z = 0;
			GameObject currentMoveFlag = (GameObject) Instantiate(FLAG_PREFAB, target, Quaternion.identity);
			currentMoveFlag.renderer.enabled = false;
			queuedMoves.Add (currentMoveFlag);
		}
		
		position.z = 0;
		GameObject queuedMoveflag = (GameObject) Instantiate(FLAG_PREFAB, position, Quaternion.identity);
		queuedMoves.Add (queuedMoveflag);
	}
	
	void RemoveFromQueue(GameObject flag)
	{
		queuedMoves.Remove(flag);
		Destroy(flag);
	}
	
	void ClearQueuedMoves()
	{
		foreach(GameObject flag in queuedMoves)
		{
			Destroy (flag);
		}
		queuedMoves.Clear();
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		CollideWithFlag(collider);
	}
	
	void OnTriggerStay2D(Collider2D collider)
	{
		CollideWithFlag(collider);
	}
	
	void CollideWithFlag(Collider2D collider)
	{
		GameObject flag = collider.gameObject;
		if(queuedMoves.Count > 0 && flag.Equals(queuedMoves[0]))
		{
			RemoveFromQueue(collider.gameObject);
		}
	}
	
	void PlayWalkAnimation()
	{
		anim.SetBool("Walk", true);
		anim.SetBool("Stop", false);
	}
	
	void StopWalkAnimation()
	{
		anim.SetBool("Walk", false);
		anim.SetBool("Stop", true);
	}
}
