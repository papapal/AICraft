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
                Selectable selectable =  hit.transform.gameObject.GetComponent<Selectable>();
                if(selectable != null)
                {
                    listSelection.Add(selectable);
                    AttachUnitGroundSelector();
                }

            }
        }
    }

    //TODO Use a pooling system to optimize
    void ReleaseUnitGroundSelector()
    {
        for(int i = 0; i < listSelectionGroundFX.Count; i++)
        {
            Destroy(listSelectionGroundFX[i]);
        }
        listSelectionGroundFX.Clear();
    }

    void AttachUnitGroundSelector()
    {
        for(int i = 0; i < listSelection.Count; i++)
        {
            GameObject fx = Instantiate(unitGroundFX, listSelection[i].transform, false);
            listSelectionGroundFX.Add(fx);
        }
    }
}
