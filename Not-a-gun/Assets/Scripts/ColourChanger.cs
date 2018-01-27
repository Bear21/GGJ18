using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChanger : MonoBehaviour {
   public Transform State;
   public Material materialOn;
   public Material materialOff;
   private bool currentState;
   // Use this for initialization
   void Start () {
      currentState = State.GetComponent<ComboSwitch>().State();
      GetComponent<Renderer>().material = currentState ? materialOn : materialOff;
   }
	
	// Update is called once per frame
	void Update () {
      if (State.GetComponent<ComboSwitch>().State() != currentState)
      {
         currentState = State.GetComponent<ComboSwitch>().State();
         GetComponent<Renderer>().material = currentState ? materialOn : materialOff;
      }

   }
}
