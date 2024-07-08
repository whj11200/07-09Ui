using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeCast : MonoBehaviour
{
    private Transform tr; //자기 자신 트랜스폼
    private Ray ray; // 광선 
    private RaycastHit hit; // 광선관련 구조체 
    private float dist = 20f;// 
    //RaycastHit 광선관련 구조체 오브젝트가 광선에 맞았는 지 판별함
    public CrossHair c_hair;
    void Start()
    {
      tr = GetComponent<Transform>();
      c_hair = GameObject.Find("PlayerUi").transform.GetChild(3).GetComponent<CrossHair>();
      
    }


    void Update()
    {                                          // 방향과 거리 :Velocity
        ray = new Ray(transform.position, tr.forward);
        //동적 할당 하자마자 위치와 방향과 거리를 지정
        // 위치     광역               색깔
        Debug.DrawLine(ray.origin, ray.direction * dist);
        //씬화면에서  광선이 보이는 지 개발자 테스트용으로 디버깅 하는 것

         // 광선,맞은 오브젝트위치값, 거리, 맞은 적들 판별
        if (Physics.Raycast(ray, out hit, dist, 1 << 6| 1<<7 | 1<<8))
        {
            // 광선을 쏘았을 때 적이 맞았는 지
            c_hair.is_Gaze = true;
            
        }
        else //광선에 맞지않았다면 
        {
            c_hair.is_Gaze= false;
        }
    }
}
