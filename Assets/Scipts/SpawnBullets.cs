using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//15 52.2 -36.6    45.065
public class SpawnBullets : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject firepoint;
    public List<GameObject> vfs = new List<GameObject>();
    private GameObject effectToSpawn;
    public RotateToMouse rotateToMouse;
    private float timeToFire =  0;

    void Start()
    {
        effectToSpawn = vfs[0];
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && Time.time >= timeToFire){
            timeToFire = Time.time + 1/effectToSpawn.GetComponent<MoveBullet>().firerate;
            
            SpawnVFS();
        }
    }
    void SpawnVFS(){
        GameObject vfs;
        if(firepoint != null){
            vfs = Instantiate(effectToSpawn, firepoint.transform.position, Quaternion.identity);
            if(rotateToMouse != null){
                vfs.transform.localRotation = rotateToMouse.GetRoation();
            }
        }else{
            Debug.Log("No Fire Point");
        }
    }
}
