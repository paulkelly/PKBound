using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerManager : MonoBehaviour
{

	public void Respawn(Vector2 position)
	{
		transform.position = new Vector3(position.x, position.y, transform.position.z);
		
		GetComponent<PlayerMovement>().Reset();
		
		CenterCameraEvent e = new CenterCameraEvent();
		GameEvents.GameEventManager.post(e);
	}
	
	void KillPlayer()
	{		
		PlayerDeathEvent e = new PlayerDeathEvent(gameObject);
		GameEvents.GameEventManager.post(e);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag.Equals("Enemy"))
		{
			KillPlayer();
		}
	}
}
