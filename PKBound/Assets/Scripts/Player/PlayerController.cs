using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{

	void Update ()
	{
//		Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
//				
//		RaycastHit hit = new RaycastHit();
//		if(Physics.Raycast(mouseRay, out hit))
//		{
//			Vector3 target = hit.point;
//			
//			GetComponent<PlayerMovement>().MoveTo(target);
//		}

		if(Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
		{
			Ray mouseRay = Camera.main.ScreenPointToRay (Input.mousePosition);
			
			Vector3 target = mouseRay.origin;
			
			if(Input.GetButton("QueuedMovement"))
			{
				GetComponent<PlayerMovement>().QueuedMoveTo(target);
			}
			else
			{
				GetComponent<PlayerMovement>().MoveTo(target);
			}

		}
	}
}
