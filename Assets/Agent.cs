using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {

	float speed = 1;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void Move(float x, float y){
		rb.velocity = new Vector3(x*speed, 0, y*speed);
	}

	public void MoveToward(Vector3 position){
		rb.velocity = UBP(position, transform.position) * speed;
	}

	public void MoveAway(Vector3 position){
		rb.velocity = UBP(transform.position, position) * speed;
	}

	Vector3 UBP(Vector3 p1, Vector3 p2){
		return (1f / (p1 - p2).magnitude) * (p1 - p2);
	}

}
