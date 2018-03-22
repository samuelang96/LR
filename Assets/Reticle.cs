using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour {
	Rigidbody rb;
	GameObject highlight;
	public int speed = 2;
	PlayerInputController pic;
	Establishment currentEstablishment;

	// Use this for initialization
	void Start () {
		highlight = GameObject.Find ("Highlight");
		rb = GetComponent<Rigidbody> ();
		pic = GameObject.Find ("PlayerInputController").GetComponent<PlayerInputController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Stop(){
		rb.velocity = new Vector3(0,0,0);
	}
	public void MoveNorth(){
		rb.velocity = new Vector3 (rb.velocity.x, 0, speed);
	}
	public void StopZ(){
		rb.velocity = new Vector3 (rb.velocity.x, 0, 0);
	}
	public void MoveSouth(){
		rb.velocity = new Vector3 (rb.velocity.x, 0, -speed);
	}

	public void MoveWest(){
		rb.velocity = new Vector3 (-speed, 0, rb.velocity.z);
	}

	public void StopX(){
		rb.velocity = new Vector3 (0, 0, rb.velocity.z);
	}

	public void MoveEast(){
		rb.velocity = new Vector3 (speed, 0, rb.velocity.z);
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Establishment") {
			highlight.transform.position = other.transform.position;
			currentEstablishment = other.GetComponent<Establishment> ();
			pic.TypeName (currentEstablishment.name);
			pic.TypePopulation ("population " + (int)(currentEstablishment.population));
			updatePopulation = StartCoroutine (UpdatePopulation ());
		}
	}
	Coroutine updatePopulation;
	IEnumerator UpdatePopulation(){
		yield return new WaitForSeconds (1);
		while (true) {
			pic.WritePopulation ("population " + (int)(currentEstablishment.population));
			yield return new WaitForSeconds (.1f);
		}

	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Establishment") {
			if (updatePopulation != null) {
				StopCoroutine (updatePopulation);
			}
			pic.StopTypingRoutines ();
			highlight.transform.position = new Vector3 (1000, 1000, 1000);
		}
	}
		
}
