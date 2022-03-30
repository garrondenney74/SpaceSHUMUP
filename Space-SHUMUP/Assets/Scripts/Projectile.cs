/**** 
 * Created by: Garron Denney
 * Date Created: March 30, 2022
 * 
 * Last Edited by: NA
 * Last Edited: March 30, 2022
 * 
 * Description: Projectile Behavior
****/









using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    /***VARIABLES***/

    private BoundsCheck bndCheck; //reference to the bounds check


    void Awake()
    {
        bndCheck = GetComponent<BoundsCheck>();
    }//end Awake()




    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //is off screen up
        if(bndCheck.offUp)
        {
            Destroy(gameObject);
        }
    }//end update
}
