
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseHover : MonoBehaviour {
    Renderer rendererReference;
	// Use this for initialization
	void Start () {
        rendererReference = GetComponent<Renderer>();

        rendererReference.material.color = Color.yellow;
	}
	
	// Update is called once per frame
	void OnMouseEnter() {
        rendererReference.material.color = Color.cyan;

    }

    void OnMouseExit()
    {
        rendererReference.material.color = Color.yellow;
    }
}
