using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelChanger : MonoBehaviour {
    
    public GameObject fish_swimming;
    public GameObject fish_legs;
    public GameObject fish_legs_horns;
    public GameObject fish_legs_hand;
    public GameObject fish_legs_horns_hand;
    public GameObject fish_legs_horns_hand_spikes;

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
        if (legs && horns && hands && spikes)
        {
            activeModel.SetActive(false);
            fish_legs_horns_hand_spikes.SetActive(true);
            activeModel = fish_legs_horns_hand_spikes;
        }
        else if (legs && horns && hands)
        {
            activeModel.SetActive(false);
            fish_legs_horns_hand.SetActive(true);
            activeModel = fish_legs_horns_hand;
        }
        if (legs && horns)
        {
            activeModel.SetActive(false);
            fish_legs_horns.SetActive(true);
            activeModel = fish_legs_horns;
        }
        if (legs && hands)
        {
            activeModel.SetActive(false);
            fish_legs_hand.SetActive(true);
            activeModel = fish_legs_hand;
        }
        else if (legs)
        {
            activeModel.SetActive(false);
            fish_legs.SetActive(true);
            activeModel = fish_legs;
        }

    }
}
