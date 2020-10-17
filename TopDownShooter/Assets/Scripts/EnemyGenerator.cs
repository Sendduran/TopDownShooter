using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{

    public GameObject enemyPooler;
    public ObjectPooler objectPooler;

    //Enemy respawn time
    [SerializeField]
    private float nextSpawnTime;

    private float[] randomNums;

    // private Vector2 Position;
    private float[] positionX;
    private float[] positionY;
    

    // Start is called before the first frame update
    void Start()
    {
        objectPooler = enemyPooler.GetComponent<ObjectPooler>();

        //Random spawning time for enemy
        randomNums = new float[] { 3.0f, 4.0f, 5.0f, 6.0f, 4.0f, 5.0f, 6.0f };
        nextSpawnTime = randomNums[Random.Range(1, 7)];

        positionX = new float[] { -7.2f, -4.4f, 1.6f, 4.8f, 5.2f};
        positionY = new float[] { 3.2f, -0.9f, -3.7f, 2.0f, -2.8f};


        StartCoroutine("MyCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Enemy Generator
    private void EnemyGenerate()
    {   
        Vector2 position = new Vector2 ( positionX[Random.Range(0,5)], positionY[Random.Range(0,5)] );
        //Getting a Enemy object from ObjectPooler and assiging it to "newEnemy"
        GameObject newEnemy = (GameObject)objectPooler.GetPooledObject();
        if (newEnemy != null)
        {
            //Assiging the position of the enemy as same as the generator
            newEnemy.transform.position = position;
            newEnemy.transform.rotation = Quaternion.identity;

            //Enabling Gameobject
            newEnemy.SetActive(true);
        }
        

    }
    //Coroutine function for generating enemy
    IEnumerator MyCoroutine()
    {
        for (; ; )
        {
            EnemyGenerate();
            yield return new WaitForSeconds(nextSpawnTime);
        }
    }
}