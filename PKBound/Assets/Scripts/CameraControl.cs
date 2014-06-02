using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{

	public float SPEED;
	
	public GameObject initalCameraBounds;
	Bounds screenBounds;
	
	void Start()
	{
		screenBounds = initalCameraBounds.renderer.bounds;
	}

	void Update ()
	{
		float verticalCameraSize = camera.orthographicSize;
		float horizontalCameraSize = verticalCameraSize * camera.aspect;
	
		if(Input.GetButton("CameraMovementRight"))
		{
			if((transform.position.x + SPEED) + horizontalCameraSize < screenBounds.max.x)
			{
				transform.position = new Vector3(transform.position.x + SPEED, transform.position.y, transform.position.z);
			}
		}
		else if(Input.GetButton("CameraMovementLeft"))
		{
			if((transform.position.x - SPEED) - horizontalCameraSize > screenBounds.min.x)
			{
				transform.position = new Vector3(transform.position.x - SPEED, transform.position.y, transform.position.z);
			}
		}
		
		if(Input.GetButton("CameraMovementUp"))
		{
			if((transform.position.y + SPEED) + verticalCameraSize < screenBounds.max.y)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y + SPEED, transform.position.z);
			}
		}
		else if(Input.GetButton("CameraMovementDown"))
		{
			if((transform.position.y - SPEED) - verticalCameraSize > screenBounds.min.y)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y - SPEED, transform.position.z);
			}
		}
	}
	
}
