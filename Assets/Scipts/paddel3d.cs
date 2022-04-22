using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddel3d : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 m_Movement;
    public float speed;
    public float rightscreenEdge;
    public float leftscreenEdge;
    public float frontscreenEdge;
    public float backscreenEdge;
    public Touch touch;

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // float horizontal = Input.GetAxis("Horizontal");
        // float vertical = Input.GetAxis("Vertical");
        // float horizontal = Input.mousePosition.x;
        // float vertical = Input.mousePosition.z;
        //  m_Movement.Set(horizontal*Time.deltaTime*speed,5.109567f,transform.position.x*Time.deltaTime*speed); //storing x,y,z vertical movement
        // m_Movement.Normalize();
        // Vector3 mousePosition = new Vector3(Input.mousePosition.x, 5.109567f, Input.mousePosition.z);
        //  Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //  transform.position = mousePosition;
        // transform.Translate(Vector3.right * horizontal*Time.deltaTime*speed, Space.World);
        // transform.Translate(Vector3.forward*vertical*Time.deltaTime*speed,Space.World);

        if(Input.touchCount>0){

            touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Moved){
                transform.position = new Vector3(transform.position.x + touch.deltaPosition.x*speed, 5.109567f,transform.position.z + touch.deltaPosition.y*speed);

            }
        }



        






         if (transform.position.x>rightscreenEdge){
            transform.position = new Vector3(rightscreenEdge, transform.position.y,transform.position.z);

        }
        if (transform.position.x<leftscreenEdge){
            transform.position = new Vector3(leftscreenEdge, transform.position.y,transform.position.z);

        }
         if (transform.position.z>backscreenEdge){
            transform.position = new Vector3(transform.position.x, transform.position.y,backscreenEdge);

        }
        if (transform.position.z<frontscreenEdge){
            transform.position = new Vector3(transform.position.x, transform.position.y,frontscreenEdge);

        }
    }
}
