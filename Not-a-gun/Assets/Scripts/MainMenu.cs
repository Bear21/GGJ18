using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;





public class MainMenu : MonoBehaviour {
    
public bool isPlay;
public bool isSettings;
public bool isQuit;
    Renderer rendererReference;


    // Use this for initialization
    void Start () {
        rendererReference = GetComponent<Renderer>();
        rendererReference.material.color = Color.yellow;
    }

    // Update is called once per frame

      

    void OnMouseUp()  {
		if(isPlay){
            rendererReference.material.color = Color.grey;
            SceneManager.LoadScene(1);
        
        }
        if (isSettings)
        {
            rendererReference.material.color = Color.grey;
        }
        if (isQuit)
        {
            rendererReference.material.color = Color.grey;
            Application.Quit();
        }
    }
}

