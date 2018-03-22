using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	public GameObject castle, village;
	int villages = 2;
	float zero_pos = -4.5f;
	List<Establishment> establishments;
	List<Vector2> cords;
	public Castle player_castle;

	// Use this for initialization
	void Start () {
		
		GenerateLevel ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void GenerateLevel(){
		//generate coords
		cords = new List<Vector2>();
		for (int y = 0; y < 10; y++) {
			for (int x = 0; x < 10; x++) {
				cords.Add (new Vector2 (x, y));
			}
		}

		ShuffleCords (cords);



		player_castle = Instantiate(castle, new Vector3(zero_pos + cords[0].x * 1f, 0, zero_pos + cords[0].y * 1f), Quaternion.identity).GetComponent<Castle>();
		for (int i = 1; i < villages; i++) {
			GameObject new_village = Instantiate(village, new Vector3(zero_pos + cords[i].x * 1f, 0, zero_pos + cords[i].y * 1f), Quaternion.identity);
		}
	}



	List<Vector2> ShuffleCords(List<Vector2> a)
	{
		// Loops through array
		for (int i = a.Count-1; i > 0; i--)
		{
			// Randomize a number between 0 and i (so that the range decreases each time)
			int rnd = Random.Range(0,i);

			// Save the value of the current i, otherwise it'll overright when we swap the values
			Vector2 temp = a[i];

			// Swap the new and old values
			a[i] = a[rnd];
			a[rnd] = temp;
		}
		return a;
	}

}
