using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour, GameEvents.GameEventListener
{
	public int livesRemaining = 5;

	public GameObject startRegion;
	public GameObject endRegion;

public	List<GameObject> players = new List<GameObject>();
public	List<GameObject> livingPlayers = new List<GameObject>();
	List<GameObject> deadPlayers = new List<GameObject>();

	// Use this for initialization
	void Start ()
	{
		GameEvents.GameEventManager.registerListener(this);
		
		FindAllPlayers();
		
		foreach(GameObject player in players)
		{			
			livingPlayers.Add(player);
		}
	}
	
	void FindAllPlayers()
	{
		players.Clear();
		GameObject findPlayers = GameObject.Find("GreenPlayer");
		
		players.Add(findPlayers);
	}
	
	void OnDisable()
	{
		GameEvents.GameEventManager.unregisterListener(this);
	}
	
	void PlayerDied(GameObject playerObject)
	{		
		livingPlayers.Remove(playerObject);
		deadPlayers.Add(playerObject);
		
		if(livingPlayers.Count < 1)
		{
			Respawn();
		}
	}
	
	void RevivePlayer(GameObject player)
	{
		livingPlayers.Add (player);
		
		Bounds startRegionBounds = startRegion.renderer.bounds;
		float respawnX = Random.Range(startRegionBounds.min.x, startRegionBounds.max.x);
		float respawnY = Random.Range(startRegionBounds.min.y, startRegionBounds.max.y);
		
		player.GetComponent<PlayerManager>().Respawn(new Vector2(respawnX, respawnY));
	}
	
	void Respawn()
	{
		if(livesRemaining < 1)
		{
			LoseGame ();
		}
		else
		{
			livesRemaining--;
			
			foreach(GameObject player in deadPlayers)
			{
				RevivePlayer(player);
			}
			deadPlayers.Clear();
		}
	}
	
	void LoseGame()
	{
		Application.LoadLevel(0);
	}
	
	public void receiveEvent(GameEvents.GameEvent e)
	{	
		if(e.GetType().Name.Equals("PlayerDeathEvent"))
		{
			PlayerDied(((PlayerDeathEvent)e).GetPlayer());
		}
	}
	
	
}
