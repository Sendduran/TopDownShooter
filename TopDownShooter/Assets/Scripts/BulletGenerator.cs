using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{

    private ObjectPooler objectPooler;


    // Start is called before the first frame update
    void Start()
    {
        objectPooler = this.GetComponent<ObjectPooler>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Bullet Generator
    public void BulletGenerate()
    {   
        //Getting a Bullet object from ObjectPooler and assiging it to "newBullet"
        GameObject newBullet = (GameObject)objectPooler.GetPooledObject();
        if (newBullet != null)
        {
            //Assiging the position of the bullet as same as the generator
            newBullet.transform.position = this.transform.position;
            newBullet.transform.rotation = Quaternion.identity;

            //Enabling Gameobject
            newBullet.SetActive(true);
        }
    }
}
