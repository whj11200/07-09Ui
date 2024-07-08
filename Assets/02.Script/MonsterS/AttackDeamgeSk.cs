using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDeamgeSk : MonoBehaviour
{
    public BoxCollider boxcol;
    public MeshRenderer meshRenderer;



    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
    void BoxColEndable()
    {
        boxcol.enabled = true;
        meshRenderer.enabled = true;
    }

    public void BoxColDisble()
    {
        boxcol.enabled = false;
        meshRenderer.enabled = false;
    }

}
