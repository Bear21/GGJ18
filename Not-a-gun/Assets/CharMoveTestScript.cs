using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
   [RequireComponent(typeof(ThirdPersonCharacter))]
   public class CharMoveTestScript : MonoBehaviour
   {
      private ThirdPersonCharacter m_Character; // A reference to the ThirdPersonCharacter on the object
      private Transform m_Cam;                  // A reference to the main camera in the scenes transform
      private Vector3 m_CamForward;             // The current forward direction of the camera
      private Vector3 m_Move;
      private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.

      private Vector3 m_target;
      bool fireonce = false;
      private void Start()
      {
         // get the third person character ( this should never be null due to require component )
         m_Character = GetComponent<ThirdPersonCharacter>();
         m_target = transform.position - new Vector3(10, 0, 0);
      }

      private void FixedUpdate()
      {
         if (Time.time > 2)
         {
            fireonce = true;
            Vector3 target = transform.position - m_target;
            m_Character.Move(target, false, false);
         }
      }
   }
}