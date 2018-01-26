using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButan : MonoBehaviour {
    public Transform condition;
    private ITriggerCondition triggerConditionRef;
    // Use this for initialization
    void Start () {
        triggerConditionRef = condition.GetComponent<ITriggerCondition>();

    }
	
	// Update is called once per frame
	void Update () {
        if (triggerConditionRef.GetTriggered())
        {
            transform.localPosition = new Vector3(0, -0.05f, 0);
        }
        else
        {
            transform.localPosition = new Vector3(0, 0, 0);
        }
    }
}
