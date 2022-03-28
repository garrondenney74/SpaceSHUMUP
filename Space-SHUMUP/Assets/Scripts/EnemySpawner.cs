/**** 
 * Created by: Garron Denney
 * Date Created: March 28, 2022
 * 
 * Last Edited by: NA
 * Last Edited: March 28, 2022
 * 
 * Description: Spawn Enemies
****/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    /*** VARIABLES ***/
    [Header("Enemy settings")]
    public GameObject[] prefabEnemies; //array of all enemy prefabs
    public float enemySpawnPerSecond; //enemy count to spawn per second
    public float enemyDefaultPadding; //padding position of each enemy

    private BoundsCheck bndCheck; //reference to the bounds check component



    // Start is called before the first frame update
    void Start()
    {
        bndCheck = GetComponent<BoundsCheck>();
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);

    }//end Start

    void SpawnEnemy()
    {
        //pick a random enemy to instantiate
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);


        //position the enemy above the screen with a random x position
        float enemyPadding = enemyDefaultPadding;
        if(go.GetComponent<BoundsCheck>() != null)
        {
            enemyPadding = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        //Set the initial position
        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyPadding;
        float xMax = bndCheck.camWidth - enemyPadding;
        pos.x = Random.Range(xMin, xMax);
        pos.y = bndCheck.camHeight + enemyPadding;
        go.transform.position = pos;
        //Invoke SpawnEnemy() again
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
        





    }//end SpawnEnemy
}
