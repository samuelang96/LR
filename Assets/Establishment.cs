using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Establishment : MonoBehaviour {
	public GameObject building;
	protected NameWizard nw;
	public int building_num = 0;
	public float population;
	protected float growth_rate = 1.011f;
	public string name = "NAME";
	public int food = 0;


	// Use this for initialization
	protected void Start () {
		
		nw = GameObject.Find ("NameWizard").GetComponent<NameWizard> ();
		name = nw.RandomName ();
		GenerateArchitecture ();
		StartCoroutine (PopulationGrowthRoutine ());
		StartCoroutine (ProduceRoutine ());
	}
	
	// Update is called once per frame
	protected void Update () {
		
	}

	bool growing = true;
	IEnumerator PopulationGrowthRoutine(){
		while (growing) {
			yield return new WaitForSeconds (1);
			int new_population = (int)(population * growth_rate);
			population += (population * (growth_rate/60));
		}
	}
	bool producing = true;
	public float production_time_max = 10;
	public float production_time = 0;
	IEnumerator ProduceRoutine(){
		while (producing) {
			yield return null;
			production_time += Time.deltaTime;
			if (production_time >= production_time_max) {
				Produce ();
				production_time = 0;
			}

		}
		yield return null;
	}

	protected virtual void Produce(){

	}

	protected virtual void GenerateArchitecture(){

	}
}
