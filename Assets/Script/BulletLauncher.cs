using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLauncher : MonoBehaviour {

    public GameObject bullet;
    // private List<GameObject>[] bulletListArr = new List<GameObject>[3];
    //private int fireBulletNum = 3;
    private float fps = 15;
    public int fullSize = 90;


    List<GameObject> full0 = new List<GameObject>(); // 배열로 하는 게 더 성능이 좋긴 하지만, 리스트 구조를 사용하여 가변적인 총알 개수를 고려하도록 한다.
    List<GameObject> full1 = new List<GameObject>();
    List<GameObject> full2 = new List<GameObject>();

    GameObject clone;
    GameObject popClone;

	// Use this for initialization
	void Start () {
        
        for (int i = 0; i < fullSize; i++)
        {
            GenerateBulletToFull();
        }

        StartCoroutine(FireBullet());//코루틴이 시작되고, 유니티에서 코루틴의 실행을 관리해줌, bullet을 발사한다.
	}

    GameObject GenerateBulletToFull() {
       
        
        var clone = Instantiate(bullet);
        clone.SetActive(false);
        full0.Add(clone);

        
        var clone1 = Instantiate(bullet);
        clone1.SetActive(false);
        full1.Add(clone1);
        var clone2 = Instantiate(bullet);
        clone2.SetActive(false);
        full2.Add(clone2);
        
       

        return clone;
    }
    /*
    private void OnDestroy(List<GameObject> DestroyList)
    {
        foreach (var clone in DestroyList)
        {
            Destroy(clone);
        }
    }*/

    GameObject PopBulletFromFull(List<GameObject> bList) {
        GameObject result = null;
        if (bList.Exists(bclone => bclone.activeSelf == false))
        {  // => 연산자 : 람다 연산자라고 하며, 이 연산자는 람다식에서 왼쪽의 입력변수를 오른쪽의 람다 본문과 구분하는데 사용함.
            result = bList.Find(clone => clone.activeSelf == false); //full 리스트에 이미 생성한 bullet이 있다고 판별하였으므로 result 변수에 이 것을 저장한다.
        }
        else
        {      //full 리스트에  이미 생성한 bullet 을 다 사용하였으므로 새로운 bullet을 생성한다.
            result = GenerateBulletToFull();
        }

        return result;
    }

    IEnumerator FireBullet() {          //코루틴이 계속 돈다.
        while (true) {
            

           
            var clone = PopBulletFromFull(full0);
            clone.transform.position = new Vector3(transform.position.x, transform.position.y +5, transform.position.z);
            clone.SetActive(true);

            var clone1 = PopBulletFromFull(full1);
            clone1.transform.position = new Vector3(transform.position.x-3, transform.position.y +5, transform.position.z);
            clone1.SetActive(true);

            var clone2 = PopBulletFromFull(full2);
            clone2.transform.position = new Vector3(transform.position.x + 3, transform.position.y + 5, transform.position.z);
            clone2.SetActive(true);
           

            yield return new WaitForSeconds(1 / fps);   //여기서 지정한 시간만큼 대기하다가 다시 while루프를 돈다.
        }
    }
    

}
