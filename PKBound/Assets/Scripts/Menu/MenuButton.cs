using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour
{

	public Sprite unselected;
	public Sprite selected;
	public Sprite pressed;
		
	bool mouseOver = false;
	bool mouseDown = false;

	// Use this for initialization
	void Start ()
	{
		GetComponent<SpriteRenderer>().sprite = unselected;
	}
	
	void OnMouseEnter()
	{
		mouseOver = true;
		GetComponent<SpriteRenderer>().sprite = selected;
	}
	
	void OnMouseExit()
	{
		mouseOver = false;
		if(!mouseDown)
		{
			GetComponent<SpriteRenderer>().sprite = unselected;
		}
	}
	
	void OnMouseDown()
	{
		mouseDown = true;
		GetComponent<SpriteRenderer>().sprite = pressed;
	}
	
	void OnMouseUp()
	{
		mouseDown = false;
		if(mouseOver)
		{
			GetComponent<SpriteRenderer>().sprite = selected;
		}
		else
		{
			GetComponent<SpriteRenderer>().sprite = unselected;
		}
	}
}
