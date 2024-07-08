using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : MonoBehaviour
{

    public BoxCollider boxcol;
    public MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
