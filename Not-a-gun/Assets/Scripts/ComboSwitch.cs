using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSwitch : MonoBehaviour, ITriggerCondition
{

   public Transform condition1;
   public Transform condition2;
   private bool state = false;

   // Use this for initialization
   void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      if (!state && condition1.GetComponentInChildren<ITriggerCondition>().GetTriggered() && condition2.GetComponentInChildren<ITriggerCondition>().GetTriggered())
      {
         state = true;

      }

   }

   public bool State()
   {
      return state;
   }

   public bool GetTriggered()
   {
      return state;
   }
}
