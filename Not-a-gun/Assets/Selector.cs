using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {
   private Camera cam;
   public Transform storagePoint;
   private GameObject storage = null;
   private Collider[] disabledColliders;
   // Use this for initialization
   void Start () {
      cam = GetComponent<Camera>();
   }
	
	// Update is called once per frame
	void Update () {

      if (storage != null)
      {
         storage.transform.Rotate(new Vector3(0.3f, 0.2f, 0.1f), 100 * Time.deltaTime);
      }
      if (!Input.GetMouseButton(0))
         return;

      RaycastHit hit;
      if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit))
         return;

      Renderer rend = hit.transform.GetComponent<Renderer>();
      MeshCollider meshCollider = hit.collider as MeshCollider;

      if (rend == null || rend.sharedMaterial == null || hit.transform.tag != "Selectable")
         return;
      GameObject obj = hit.transform.gameObject;
      //Destroy(hit.transform.gameObject);

      bool result = Physics.Raycast(obj.transform.position, Vector3.Normalize(storagePoint.position - obj.transform.position), out hit, Vector3.Distance(storagePoint.position, obj.transform.position));

      if (result) {
         if (hit.transform.tag != "Selectable")
         {
            return;
         }

      }


      obj.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

      obj.transform.position = storagePoint.position;

      Collider[] results = obj.GetComponentsInChildren<Collider>();

      foreach (var collider in results)
      {
         collider.enabled = false;
      }
      disabledColliders = results;
      obj.transform.SetParent(storagePoint);
      storage = obj;
   }
}
