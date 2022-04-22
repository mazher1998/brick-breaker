using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rb;
    public Transform paddle;
    public float speed;
    private float trim;
    Scene currentScene = SceneManager.GetActiveScene ();
            Vector3 tempVelocity = new Vector3();
void Awake()
    {
         if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("SampleScene")) 
         {
             Debug.Log("first Scene");
            rb.velocity= (Vector3.forward*speed);
            
            tempVelocity.z = rb.velocity.z *-1;
            tempVelocity.x = rb.velocity.x;  
         }
         else if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("SampleScene2"))
         {
             rb.AddForce(Vector3.up*2000);
         }
    }
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        int buildIndex = currentScene.buildIndex;
        Debug.Log(buildIndex);
 
        

            Debug.Log("orginal velocity = " + rb.velocity);
            Debug.Log("altered velocity = " + tempVelocity);
       // 
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(rb.velocity.magnitude> speed){
            rb.velocity = rb.velocity*( 1-((rb.velocity.magnitude - speed)/100));  
        }
        if(rb.velocity.magnitude< speed){
            rb.velocity = rb.velocity*( 1+( (speed - rb.velocity.magnitude)/100));
        }
        Debug.Log(rb.velocity.x);
        // if(rb.velocity.x>28 ){
        //     rb.velocity= (Vector3.forward*speed);

        // }

           
        
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("BottomWall")){
            transform.position = paddle.position;
         //   transform.rotation = Quaternion.Euler(0, 0, 0);
            rb.velocity = Vector3.zero;
            rb.velocity= (Vector3.forward*speed);
            Debug.Log(rb.velocity);
            Debug.Log("rb.velocity"+rb.velocity);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        
        if(other.transform.CompareTag("RightWall") || other.transform.CompareTag("LeftWall")){
            tempVelocity.x = tempVelocity.x * -1;
             tempVelocity.y = rb.velocity.y;
              tempVelocity.z = rb.velocity.z;
            
        }
        if(other.transform.CompareTag("Paddle") || other.transform.CompareTag("TopWall")){
            tempVelocity.x = rb.velocity.x;
            tempVelocity.y = rb.velocity.y;
             tempVelocity.z = tempVelocity.z * -1; 
            // tempVelocity = tempVelocity*-1;
        }
        
        if(other.transform.CompareTag("Brick")){
             tempVelocity.x = rb.velocity.x;
            tempVelocity.y = rb.velocity.y;
             tempVelocity.z = tempVelocity.z * -1; 

            Destroy (other.gameObject);


        }
            Debug.Log("orginal velocity = " + rb.velocity);
            Debug.Log("altered velocity = " + tempVelocity);
        //    rb.velocity = Vector3.zero;
           
                    rb.velocity= tempVelocity;
        // if(other.transform.CompareTag("Paddle")){
        // //     Vector3 pos = other.transform.position;
        // //     rb.velocity = Vector3.zero;
            
        // //     rb.AddForce(Vector3.forward*2000);
            
        // //    transform.position = pos;


        // }
    }
 
}
