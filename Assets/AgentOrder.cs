using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentOrder  {
	public string name;
	public string description;

	// Use this for initialization
	public AgentOrder(){

	}

	public virtual void Execute(Agent agent, int number){

	}
}
