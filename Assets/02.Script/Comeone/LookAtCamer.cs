using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LookAtCamer : MonoBehaviour
{
    //캔버스 ui가 카메라를 쳐다본다.
    public Transform mainCam;
    public Transform Tr;
    void Start()
    {
        mainCam = Camera.main.transform;
        Tr = GetComponent<Transform>();
    }

    
    void Update()
    {
        //캔버스가 메인카메라를 쳐다본다.
        Tr.LookAt(mainCam);
    }
}
