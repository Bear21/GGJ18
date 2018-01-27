using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateOpen : MonoBehaviour {
   public Transform State;
   public Transform Gate;
   Vector3 closedPosition;
   private bool localState;
   // Use this for initialization
   void Start () {
      localState = State.GetComponent<ComboSwitch>().State();
      closedPosition = Gate.localPosition;
   }
	
	// Update is called once per frame
	void Update () {
      if (State.GetComponent<ComboSwitch>().State() != localState)
      {
         localState = !localState;

         if (localState) // Open
         {
            Gate.localPosition = closedPosition + new Vector3(0, -2, 0);
         }
         else // Close
         {
            Gate.localPosition = closedPosition;
         }
      }

   }
}
