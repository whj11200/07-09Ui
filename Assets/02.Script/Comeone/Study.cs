using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Study : MonoBehaviour
{
   
    void Start()
    {
        
    }


    void Update()
    {
        transform.position = new Vector3(0, 10f, 0);
        transform.rotation = new Quaternion(0f, 2f, 0f,0f);
                                            // 4차원 복소수
    }
}
