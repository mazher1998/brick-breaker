using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10f;
    public float rightscreenEdge;
    public float leftscreenEdge;
    Vector3 m_Movement;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
         m_Movement.Set(horizontal*Time.deltaTime*speed,1.45f,transform.position.x*Time.deltaTime); //storing x,y,z vertical movement
        m_Movement.Normalize();
        transform.Translate(Vector3.right * horizontal*Time.deltaTime*speed, Space.World);

        if (transform.position.x>rightscreenEdge){
            transform.position = new Vector3(rightscreenEdge, transform.position.y,transform.position.z);

        }
        if (transform.position.x<leftscreenEdge){
            transform.position = new Vector3(leftscreenEdge, transform.position.y,transform.position.z);

        }
        //right 29.8
        //left 1.1 
       
    }
}
