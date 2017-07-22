using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveForward : MonoBehaviour{
    HealthToBoom HealthToBoomScript;
    
    public float speed = 1;

    private void Start()
    {
        //HealthToBoomScript = GetComponent<HealthToBoom>();  
        HealthToBoomScript = gameObject.GetComponent<HealthToBoom>();
    }
   
    // Update is called once per frame
    public void Update () {
        transform.position += transform.rotation * Vector3.forward * Time.deltaTime * speed;
        
        if (transform.position.y > Screen.height/10 || transform.position.y < -Screen.height/10) {
            
            gameObject.SetActive(false);
            HealthToBoomScript.SetHealth();
        }
	}
    
}
