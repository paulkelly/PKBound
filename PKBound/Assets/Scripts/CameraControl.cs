using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{

	public float SPEED;

	void Update ()
	{
		if(Input.GetButton("CameraMovementRight"))
		{
			transform.position = new Vector3(transform.position.x + SPEED, transform.position.y, transform.position.z);
		}
		
		if(Input.GetButton("CameraMovementLeft"))
		{
			transform.position = new Vector3(transform.position.x - SPEED, transform.position.y, transform.position.z);
		}
		
		if(Input.GetButton("CameraMovementUp"))
		{
			transform.position = new Vector3(transform.position.x, transform.position.y + SPEED, transform.position.z);
		}
		
		if(Input.GetButton("CameraMovementDown"))
		{
			transform.position = new Vector3(transform.position.x, transform.position.y - SPEED, transform.position.z);
		}
	}
}
