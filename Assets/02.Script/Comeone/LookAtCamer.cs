using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LookAtCamer : MonoBehaviour
{
    //ĵ���� ui�� ī�޶� �Ĵٺ���.
    public Transform mainCam;
    public Transform Tr;
    void Start()
    {
        mainCam = Camera.main.transform;
        Tr = GetComponent<Transform>();
    }

    
    void Update()
    {
        //ĵ������ ����ī�޶� �Ĵٺ���.
        Tr.LookAt(mainCam);
    }
}
