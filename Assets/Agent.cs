using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

	float speed = .1f;
	public Rigidbody rb;
	Establishment home;


	// Use this for initialization
	protected void Start () {
		StartCoroutine (SpawnInRoutine ());
	}

	IEnumerator SpawnInRoutine(){
		transform.Translate (new Vector3 (0, -2f, 0));
		rb.velocity += new Vector3(0,1f,0);
		while (transform.position.y < 0) {
			yield return null;
		}
		rb.velocity -= new Vector3 (0, 1f, 0);
		transform.position = (new Vector3 (transform.position.x, 0, transform.position.z));
	}

	public IEnumerator DespawnRoutine(){
		rb.velocity += new Vector3(0,-1f,0);
		while (transform.position.y > -2) {
			yield return null;
		}
		Halt ();
	}

	// Update is called once per frame
	void Update () {
		
	}


	public void Journey(Establishment home, Establishment destination){
		StartCoroutine (JourneyRoutine(home, destination));
	}

	virtual protected IEnumerator JourneyRoutine(Establishment home, Establishment destination){
		yield return null;
	}

	public void Move(float x, float y){
		rb.velocity = new Vector3(x*speed, 0, y*speed);
	}

	public void MoveToward(Vector3 position){
		rb.velocity = (UBP(position, transform.position) * speed) + rb.velocity;
	}

	public void MoveAway(Vector3 position){
		rb.velocity = UBP(transform.position, position) * speed;
	}

	Vector3 UBP(Vector3 p1, Vector3 p2){
		return (1f / (p1 - p2).magnitude) * (p1 - p2);
	}
	public void Halt(){
		rb.velocity = new Vector3 (0, 0, 0);
	}

}
