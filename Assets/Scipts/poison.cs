using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poison : MonoBehaviour
{
    
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
            rb = this.GetComponent<Rigidbody>();
           // lRight();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // void lRight(){
    //     rb.velocity = Vector3.zero;
    //         rb.AddForce(Vector3.forward*2000);
    // }

    void OnTriggerEnter(Collision other)
    {
        Debug.Log("1");
       
        }
        void OnCollisionEnter(Collision other)
    {
        Debug.Log("2");
         if(other.transform.CompareTag("Brick")){
           
       Debug.Log("poison");
           
           Destroy (other.gameObject);
        Destroy (this.gameObject);
    
        }
        if(other.transform.CompareTag("TopWall") 
        || other.transform.CompareTag("RightWall") 
        || other.transform.CompareTag("LeftWall")  ){
           
       
           
           Destroy (this.gameObject);

        }

    }
}
