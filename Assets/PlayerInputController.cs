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
	public Text order_text;
	public Text order_description_text;
	List<AgentOrder> agent_orders;
	int agent_orders_index = -1;

	// Use this for initialization
	void Start () {
		reticle = GameObject.Find ("Reticle").GetComponent<Reticle> ();
		name_text.text = "";
		population_text.text = "";
		agent_orders = new List<AgentOrder> ();
		agent_orders.Add (new Capture ());
		agent_orders.Add (new Burn ());
	}
	
	// Update is called once per frame
	void Update () {
		ScanInput ();
	}

	void ChangeOrder(){
		agent_orders_index += 1;
		if (agent_orders_index < 0 || agent_orders_index >= agent_orders.Count) {
			agent_orders_index = 0;
		}
		order_text.text = agent_orders [agent_orders_index].name;
		order_description_text.text = agent_orders [agent_orders_index].description;
	}

	bool can_change_order = false;
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
		if (Input.GetAxisRaw ("ChangeOrder") != 0 && can_change_order) {
			ChangeOrder ();
			can_change_order = false;
		} else if(Input.GetAxisRaw ("ChangeOrder") == 0){
			can_change_order = true;
		}

	}

	float textTypeDelay = 0.001f;


	public void ClearText(){
		name_text.text = "";
		population_text.text = "";
		order_text.text = "";
		order_description_text.text = "";
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
