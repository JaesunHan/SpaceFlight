using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthToBoom : MonoBehaviour {     //Calculate Object's health, and print the Effect Particle
    EnemyGenerator EnemyGeneratorScript;

    public GameObject e;

    [SerializeField]
    private int health = 1;

    private int fullSize = 3;
    public List<GameObject> full = new List<GameObject>();

    
    // Use this for initialization
    public void Start () {
        //Contact to another C# script.
        EnemyGeneratorScript = GameObject.Find("GameLogic").GetComponent<EnemyGenerator>();
        ////
        for (int i =0; i< fullSize; i++) {
            GenerateEffectToFull();
        }

        SetHealth();
        /*
        if (gameObject.tag == "Enemy") {
            health = EnemyGeneratorScript.EnemyHealth;
            
            Debug.Log("Enemy health : " + health);
        } else if (gameObject.tag == "PlayerBullet") {
            health = 1;
        }*/
        
	}

    
    public void SetHealth() {
        EnemyGeneratorScript = GameObject.Find("GameLogic").GetComponent<EnemyGenerator>();
        if (gameObject.tag == "Enemy")
        {
            health = EnemyGeneratorScript.EnemyHealth;

            Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!    Enemy health : " + health);
        }
        else if (gameObject.tag == "PlayerBullet")
        {
            health = 1;
        }
        //health = EnemyGeneratorScript.EnemyHealth;

            
        
    }

    GameObject GenerateEffectToFull() {
        var clone = Instantiate(e);
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

    GameObject PopEffectFromFull() {
        GameObject result = null;

        if (full.Exists(clone => clone.activeSelf == false))
        {
            result = full.Find(clone => clone.activeSelf == false);
        }
        else {
            //result = GenerateEffectToFull();
            result = full.Find(clone => clone.activeSelf == true);
            
        }

        return result;
    }

    private void OnTriggerEnter(Collider other){        //여기서 other는 HealthToBoom 클래스가 적용된 객체와 충돌한 대상을 뜻한다.
        
        --health;

        if (health <= 0)
        {
            
            var clone = PopEffectFromFull();
            clone.transform.position = transform.position;
            clone.SetActive(false);
            clone.SetActive(true);

            gameObject.SetActive(false);
            SetHealth();
            
        }
        

        
    }
    
}
