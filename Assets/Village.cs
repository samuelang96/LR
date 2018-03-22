using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : Establishment {
	public Castle master;
	public GameObject caravan;
	// Use this for initialization
	void Start () {
		base.Start ();
		master = GameObject.Find ("LevelController").GetComponent<LevelController> ().player_castle;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	override protected void Produce(){
		Debug.Log ("HOLY HELL");

		Caravan new_caravan = Instantiate (caravan, transform.position, Quaternion.identity).GetComponent<Caravan>();
		new_caravan.food = (int)population * 2;
		//Debug.Log(master.transform.position);

		new_caravan.Journey (this, master);
	}


	override protected void GenerateArchitecture(){
		for (int i = 0; i < building_num; i++) {
			GameObject house = Instantiate (building, transform);
			float fatness = Random.Range (0.05f, 0.1f);
			float height = Random.Range (0.1f, 0.12f);
			house.transform.localScale = new Vector3 (fatness, height, fatness);
			float offset_X = Random.Range (-.35f, .35f);
			float offset_Z = Random.Range (-.35f, .35f);
			house.transform.localPosition = new Vector3 (offset_X, 0, offset_Z);
		}
	}
}
