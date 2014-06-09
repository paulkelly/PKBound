using UnityEngine;
using System.Collections;

public class StepByStepExplosionManager : MonoBehaviour
{
	public GameObject[] explodingFloor;
	
	private const int steps = 2;
	private float[] delay;
	private int[][] pattern;
	
	private int currentStep = 0;
	private float cooldown;
	
	void Awake ()
	{		
		delay = new float[steps] {1, 1};
		
		pattern = new int[steps][];
		
		pattern[0] = new int[4] {0, 2, 4, 6};
		pattern[1] = new int[3] {1, 3, 5};
		
	}
	
	void FixedUpdate()
	{
		if(cooldown < 0)
		{
			Explode(currentStep);
			
			currentStep = (currentStep+1) % (steps);
			cooldown = delay[currentStep];
		}
		else
		{
			cooldown -= Time.deltaTime;
		}
	}
	
	void Explode(int step)
	{
		for(int i=0; i<pattern[step].Length; i++)
		{
			explodingFloor[pattern[step][i]].GetComponent<ExplodingFloor>().Explode();
		}
	}
	
}
