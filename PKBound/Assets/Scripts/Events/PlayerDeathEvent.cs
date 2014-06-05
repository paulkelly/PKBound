using UnityEngine;
using System.Collections;

public class PlayerDeathEvent : GameEvents.GameEvent
{
	GameObject player;
	
	public PlayerDeathEvent(GameObject player)
	{
		this.player = player;
	}
	
	public GameObject GetPlayer()
	{
		return player;
	}
}
