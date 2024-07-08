using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieCol : MonoBehaviour
{
    public BoxCollider boxcol;
    



    void Start()
    {

    }


    void Update()
    {

    }
    void BoxColEndable()
    {
        boxcol.enabled = true;
        
    }

    public void BoxColDisble()
    {
        boxcol.enabled = false;
        
    }
}
