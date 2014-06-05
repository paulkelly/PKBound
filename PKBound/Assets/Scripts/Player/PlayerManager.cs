using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerManager : MonoBehaviour
{

	public void Respawn(Vector2 position)
	{
		transform.position = new Vector3(position.x, position.y, transform.position.z);
		
		GetComponent<PlayerMovement>().Reset();
	}
	
	void KillPlayer()
	{		
		PlayerDeathEvent e = new PlayerDeathEvent(gameObject);
		GameEvents.GameEventManager.post(e);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		KillPlayer();
	}
}
