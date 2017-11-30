using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelector : MonoBehaviour {
    public float rayCastDistance = 100f;
    public GameObject unitGroundFX;

    private List<Selectable> listSelection = new List<Selectable>();
    private List<GameObject> listSelectionGroundFX = new List<GameObject>();

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //TODO compare existing list before flush
            listSelection.Clear();
            ReleaseUnitGroundSelector();

            //TODO Create multiselection effect

            if(Physics.Raycast(ray, out hit, rayCastDistance))
            {
                Selectable selectable = hit.transform.gameObject.GetComponent<Selectable>();
                if(selectable != null)
                {
                    listSelection.Add(selectable);
                    AttachUnitGroundSelector();
                }
            }
        }
        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, rayCastDistance))
            {
                //TODO Handle other unit or building
                SendSelectionTo(hit.point);

            }
        }
    }

    //TODO Use a pooling system to optimize
    private void ReleaseUnitGroundSelector()
    {
        for(int i = 0; i < listSelectionGroundFX.Count; i++)
        {
            Destroy(listSelectionGroundFX[i]);
        }
        listSelectionGroundFX.Clear();
    }

    private void AttachUnitGroundSelector()
    {
        for(int i = 0; i < listSelection.Count; i++)
        {
            GameObject fx = Instantiate(unitGroundFX, listSelection[i].transform, false);
            listSelectionGroundFX.Add(fx);
        }
    }

    private void SendSelectionTo(Vector3 aPosition)
    {
        for(int i = 0; i < listSelection.Count; i++)
        {
            listSelection[i].SetNewTarget(aPosition);
        }
    }

}

