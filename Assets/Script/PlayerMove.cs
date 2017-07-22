using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour{
    private int lifetime = 3;

    //public void GameUpdate(){
    public void Update()
    {

        int touchNum = 0;
        if (Input.mousePresent)
        {

            var mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100));
            transform.position = mousePos;

            //    Debug.Log(transform.position);
        }

        touchNum = Input.touchCount;
        for (int i = 0; i < touchNum; i++)
        {
            Touch touch = Input.GetTouch(i);
            // var touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            var touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 100));
            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(touchPos.x, touchPos.y + 7, transform.position.z);
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger other's Tag : " + other.gameObject.tag);

        switch (other.gameObject.tag)
        {
            case "Enemy":
                --lifetime;
                Debug.Log("Life Time : " + lifetime);
                break;
        }

        if (lifetime <= 0) {
            Destroy(gameObject);
        }
    }

}
