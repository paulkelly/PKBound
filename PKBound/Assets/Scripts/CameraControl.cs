using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour, GameEvents.GameEventListener
{

	public float SPEED;
	
	public float mouseScrollPercent;
	
	public GameObject initalCameraBounds;
	Bounds screenBounds;
	
	float verticalCameraSize;
	float horizontalCameraSize;
	
	void Start()
	{
		GameEvents.GameEventManager.registerListener(this);
		screenBounds = initalCameraBounds.renderer.bounds;
	}
	
	void OnDisable()
	{
		GameEvents.GameEventManager.unregisterListener(this);
	}
	
	void Update ()
	{
		verticalCameraSize = camera.orthographicSize;
		horizontalCameraSize = verticalCameraSize * camera.aspect;
		
		if(Input.GetButton ("CenterCamera"))
		{
			CenterCamera();
		}
		else
		{
			if(Input.GetButton("CameraMovementRight") || mouseScrollRight())
			{
				if((transform.position.x + SPEED) + horizontalCameraSize < screenBounds.max.x)
				{
					transform.position = new Vector3(transform.position.x + SPEED, transform.position.y, transform.position.z);
				}
			}
			else if(Input.GetButton("CameraMovementLeft") || mouseScrollLeft())
			{
				if((transform.position.x - SPEED) - horizontalCameraSize > screenBounds.min.x)
				{
					transform.position = new Vector3(transform.position.x - SPEED, transform.position.y, transform.position.z);
				}
			}
			
			if(Input.GetButton("CameraMovementUp") || mouseScrollUp())
			{
				if((transform.position.y + SPEED) + verticalCameraSize < screenBounds.max.y)
				{
					transform.position = new Vector3(transform.position.x, transform.position.y + SPEED, transform.position.z);
				}
			}
			else if(Input.GetButton("CameraMovementDown") || mouseScrollDown())
			{
				if((transform.position.y - SPEED) - verticalCameraSize > screenBounds.min.y)
				{
					transform.position = new Vector3(transform.position.x, transform.position.y - SPEED, transform.position.z);
				}
			}
		}
	}
	
	bool mouseScrollLeft()
	{
		bool result = false;
		
		Vector3 target = GetMousePosition();
		
		float scrollSize = (horizontalCameraSize / 100f) * mouseScrollPercent;
		
		if(target.x < (transform.position.x - horizontalCameraSize) + scrollSize)
		{
			result = true;
		}
		
		return result;
	}
	
	bool mouseScrollRight()
	{
		bool result = false;
		
		Vector3 target = GetMousePosition();
		
		float scrollSize = (horizontalCameraSize / 100f) * mouseScrollPercent;
		
		if(target.x > (transform.position.x + horizontalCameraSize) - scrollSize)
		{
			result = true;
		}
		
		return result;
	}
	
	bool mouseScrollUp()
	{
		bool result = false;
		
		Vector3 target = GetMousePosition();
		
		float scrollSize = (verticalCameraSize / 100f) * mouseScrollPercent;
		
		if(target.y > (transform.position.y + verticalCameraSize) - scrollSize)
		{
			result = true;
		}
		
		return result;
	}
	
	bool mouseScrollDown()
	{
		bool result = false;
		
		Vector3 target = GetMousePosition();
		
		float scrollSize = (verticalCameraSize / 100f) * mouseScrollPercent;
		
		if(target.y < (transform.position.y - verticalCameraSize) + scrollSize)
		{
			result = true;
		}
		
		return result;
	}
	
	Vector3 GetMousePosition()
	{
		Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		return mouseRay.origin;
	}
	
	public void CenterCamera()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
	}
	
	public void receiveEvent(GameEvents.GameEvent e)
	{
		if(e.GetType().Name.Equals("CenterCameraEvent"))
		{
			CenterCamera();
		}
	}
	
}
