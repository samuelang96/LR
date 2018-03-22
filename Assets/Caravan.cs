using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caravan : Agent {
	public int food;
	// Use this for initialization
	void Start () {
		base.Start ();
	}

	override protected IEnumerator JourneyRoutine(Establishment home, Establishment destination){
		MoveToward (destination.transform.position);
		while ((transform.position - destination.transform.position).magnitude > .1f) {
			yield return null;
		}
		Halt ();
		destination.food += food;
		food = 0;
		MoveToward (home.transform.position);
		while ((transform.position - home.transform.position).magnitude > .1f) {
			yield return null;
		}
		Halt ();
		StartCoroutine(DespawnRoutine ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
