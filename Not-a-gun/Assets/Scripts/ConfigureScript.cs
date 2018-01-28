using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ConfigureScript : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   private void OnTriggerEnter(Collider other)
   {
      if (other.tag != "Player")
      {
         return;
      }
      
      if (other.GetComponent<Selector>().cam != null)
         return; //don't try to configure twice.
      //other.GetComponentInChildren<Selector>().storagePoint = other.transform.Find("ObjectStoragePoint");
      other.GetComponentInChildren<Selector>().cam = Camera.main;
   }
}
