using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerProximity : MonoBehaviour, ITriggerCondition
{
    public string detectTag;

    private int state = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    bool ITriggerCondition.GetTriggered() 
    {
        return state > 0;
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == detectTag)
        {
            state++;
        }
    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == detectTag)
        {
            state--;
        }
    }
}
