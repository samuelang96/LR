using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInputController : MonoBehaviour {
	Reticle reticle;
	Coroutine name_routine;
	Coroutine population_routine;

	public Text name_text;
	public Text population_text;

	// Use this for initialization
	void Start () {
		reticle = GameObject.Find ("Reticle").GetComponent<Reticle> ();
	}
	
	// Update is called once per frame
	void Update () {
		ScanInput ();
	}

	void ScanInput(){
		if (Input.GetAxisRaw ("Vertical") > 0) {
			reticle.MoveNorth ();
		} 
		if (Input.GetAxisRaw ("Vertical") < 0) {
			reticle.MoveSouth ();
		}
		if (Input.GetAxisRaw ("Vertical") == 0) {
			reticle.StopZ ();
		}

		if (Input.GetAxisRaw ("Horizontal") > 0) {
			reticle.MoveEast ();
		} 
		if (Input.GetAxisRaw ("Horizontal") < 0) {
			reticle.MoveWest ();
		}
		if (Input.GetAxisRaw ("Horizontal") == 0) {
			reticle.StopX ();
		}

	}

	float textTypeDelay = 0.001f;


	public void ClearText(){
		name_text.text = "";
		population_text.text = "";

	}

	public void StopTypingRoutines(){
		if (name_routine != null) {
			StopCoroutine (name_routine);
		}
		if (population_routine != null) {
			StopCoroutine (population_routine);
		}
		ClearText ();

	}

	public void TypeName(string m){
		if (name_routine != null) {
			StopCoroutine (name_routine);
		}

		name_routine = StartCoroutine (TypeText (m,name_text));
	}

	public void TypePopulation(string m){
		if (population_routine != null) {
			StopCoroutine (population_routine);
		}

		population_routine = StartCoroutine (TypeText (m,population_text));
	}

	public void WritePopulation(string m){
		population_text.text = m;
	}

	IEnumerator TypeText(string m, Text t){
		ClearText ();
		yield return new WaitForSeconds (textTypeDelay);

		for (int i = 0; i < m.Length; i++) {
			t.text += m [i];
			yield return new WaitForSeconds (textTypeDelay);
		}
	}





}
