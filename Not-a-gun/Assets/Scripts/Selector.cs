using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Selector : NetworkBehaviour {
   public Transform cameraObject;
   public Camera cam;
   //[SyncVar]
   public Transform storagePoint;
   //[SyncVar(hook = "storageHook")]
   private GameObject storage = null;
   private Collider[] disabledColliders;
   // Use this for initialization
   void Start () {

      if (cameraObject != null)
         cam = cameraObject.GetComponent<Camera>();
   }

   
	
	// Update is called once per frame
	void Update () {
      if (cam == null)
         return;
      if (storage != null)
      {
         storage.transform.Rotate(new Vector3(0.3f, 0.2f, 0.1f), 100 * Time.deltaTime);
      }
      if (!isLocalPlayer || !Input.GetMouseButton(0))
         return;

      RaycastHit hit;
      if (!Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition), out hit, LayerMask.GetMask("Selectable", "Wall")))
         return;
      Transform hitTransform = null;
      if (hit.transform.GetComponentInChildren<EmptyScript>())
      {
         Debug.Log(string.Format("can find: {0}", hit.transform.GetComponentInChildren<EmptyScript>().name));//
         hitTransform = hit.transform.GetComponentInChildren<EmptyScript>().transform;
      }
      if (hitTransform == null) { return; }
      Renderer rend = hitTransform.GetComponent<Renderer>();
      //MeshCollider meshCollider = hit.collider as MeshCollider;

      
      GameObject obj;
      if (rend == null || rend.sharedMaterial == null || hitTransform.tag != "Selectable") {
            return;
      }
      obj = hitTransform.gameObject;
      //Destroy(hit.transform.gameObject);

      bool result = Physics.Raycast(obj.transform.position, Vector3.Normalize(storagePoint.position - obj.transform.position), out hit, Vector3.Distance(storagePoint.position, obj.transform.position));
      hitTransform = null;
      if (result)
      {
         if (hit.transform.GetComponentInChildren<EmptyScript>() != null)
         {
            Debug.Log(string.Format("can find: {0}", hit.transform.GetComponentInChildren<EmptyScript>().name));//
            hitTransform = hit.transform.GetComponentInChildren<EmptyScript>().transform;
         }
      
         if (hitTransform.tag != "Selectable")
         {
            return;
         }
         obj = hitTransform.gameObject;
      }
      

      //obj.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

      CmdStorage(obj);
      //obj.transform.position = storagePoint.position;



      ////Collider[] results = obj.GetComponentsInChildren<Collider>();

      ////foreach (var collider in results)
      ////{
      ////   collider.isTrigger = true;
      ////}
      ////disabledColliders = results;
      //obj.transform.SetParent(storagePoint);
      //obj.transform.localScale = new Vector3(1, 1, 1);
      //storage = obj;
   }


   private void transmit(GameObject obj)
   {
      if (obj.transform.parent != null)
      {
         obj.transform.parent.GetComponentInParent<Selector>().storage = null;
      }
      obj.transform.SetParent(storagePoint);
      obj.transform.position = storagePoint.position;
      obj.transform.localScale = new Vector3(1, 1, 1);
      Debug.Log("Transfered");
   }

   [Command]
   public void CmdStorage(GameObject obj)
   {
      transmit(obj);
      RpcStorage(obj);
   }

   [ClientRpc]
   void RpcStorage(GameObject obj)
   {
      transmit(obj);
   }

   //void storageHook(GameObject obj)
   //{
   //   if (obj == null)
   //   {
   //      Debug.Log("Didn't transfer");
   //      return;
   //   }

   //   transmit(obj);
   //}
}
