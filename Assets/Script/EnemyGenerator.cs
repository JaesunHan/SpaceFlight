using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    
    /** This variable is Stage number and timer and health */
    //private float timeSpan = 0.0f;
   // private float checkTime = 10.0f;
    public int stageNum = 1;
    public int EnemySet = 5;
    public int EnemyHealth = 10;
    private int defaultHealth = 10;
         
    public GameObject enemy;
    public Transform[] position;

    private float interval = 3;

    private int fullSize = 10;
    List<GameObject> full = new List<GameObject>();

    //HealthToBoom HealthToBoomScript;
    
	// Use this for initialization
	void Start () {
        

        for (int j=0; j<position.Length; j++) {
            position[j].position = new Vector3 (Screen.width /10/ position.Length * (position.Length / 2 - j), Screen.height/10, 100);
        }

        for (int i =0; i<fullSize; i++) {
            GenerateEnemyToFull();
        }
        
        StartCoroutine(Spawn());
      //  HealthToBoomScript = GameObject.Find("Enemy").GetComponent<HealthToBoom>();

    }

    GameObject GenerateEnemyToFull() {
        var clone = Instantiate(enemy);
        clone.SetActive(false);
        full.Add(clone);

        return clone;
    }

    private void OnDestroy()
    {
        foreach (var clone in full) {
            Destroy(clone);
        }
    }

    GameObject PopEnemyFromFull() {
        GameObject result = null;
        if (full.Exists(clone => clone.activeSelf == false))
        {
            result = full.Find(clone => clone.activeSelf == false);
        }
        else {
            result = GenerateEnemyToFull();
        }

        return result;
    }

    IEnumerator Spawn() {
        int i = 0;
        while (true) {
            //yield return new WaitForSeconds(interval);
            
            foreach (var t in position) {
                var clone = PopEnemyFromFull();   
                clone.transform.position = t.position;
                clone.SetActive(true);
                
            }
            
            
            if (i >= EnemySet) {        // Improve The Enemy Health
                stageNum++;
                //Debug.Log("Stage Number : " + stageNum);
                EnemyHealth = stageNum * defaultHealth;
                //   Debug.Log("EnemyHealth : " + EnemyHealth);

                
                i = 0;
            }
            i++;
            yield return new WaitForSeconds(interval);
        }
    }

    

}
