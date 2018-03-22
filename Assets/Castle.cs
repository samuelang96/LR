using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : Establishment {
	// Use this for initialization
	void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	override protected void GenerateArchitecture(){
		for (int i = 0; i < building_num; i++) {
			GameObject side_tower = Instantiate (building, transform);
			float fatness = Random.Range (0.005f, 0.15f);
			float height = Random.Range (0.25f, 0.75f);
			side_tower.transform.localScale = new Vector3 (fatness, height, fatness);
			float offset_X = Random.Range (-.3f, .3f);
			float offset_Z = Random.Range (-.3f, .3f);
			side_tower.transform.localPosition = new Vector3 (offset_X, 0, offset_Z);
		}
	}
}
