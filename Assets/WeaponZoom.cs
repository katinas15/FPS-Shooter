using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera camera;

    bool zoomed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1)){
            
            if(!zoomed){ 
                zoomed = true;
                camera.fieldOfView = 20f;
            } else {
                zoomed = false;
                camera.fieldOfView = 60f;
            }  
        } 
    }
}
