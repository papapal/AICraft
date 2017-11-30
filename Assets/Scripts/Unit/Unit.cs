using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : Selectable {
    private NavMeshAgent navMeshAgent;
	// Use this for initialization
	void Start () {
        navMeshAgent = GetComponent<NavMeshAgent>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    override public void SetNewTarget(Vector3 aPosition)
    {
        navMeshAgent.SetDestination(aPosition);
    }
}
