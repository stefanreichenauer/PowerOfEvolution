using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelChanger : MonoBehaviour {
    
    public GameObject fish_swimming;
    public GameObject fish_legs;
    public GameObject fish_legs_horns;

    GameObject activeModel;

    // Use this for initialization
    void Start () {
        activeModel = fish_swimming;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeModel(bool legs, bool horns, bool hands, bool spikes)
    {
        if(legs && horns)
        {
            activeModel.SetActive(false);
            fish_legs_horns.SetActive(true);
            activeModel = fish_legs_horns;
        }
        else if (legs)
        {
            activeModel.SetActive(false);
            fish_legs.SetActive(true);
            activeModel = fish_legs;
        }

    }
}
