using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCtrl : MonoBehaviour
{
    public Animation ComBatAim; //  애니메이션
    public Light GunLight; // 총 후레쉬
    public AudioClip flash; // mp4
    public AudioSource A_source; // 오디오 소스
    public bool is_runing =false;
    //충돌감지
    
    void Start() //  게임 시작후 바로 실행함수
    {

    }


    void Update() //  게임 시작 후 계속 호출하는 함수
    {
        Gun();
        FlashLight();
    }

    private void Gun()
    {
        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W)))
        {
            ComBatAim.Play("running");// 애니메이션 실행
            is_runing = true;

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ComBatAim.Play("runStop");
            is_runing = false;
        }
       

    }

    private void FlashLight()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            GunLight.enabled = !GunLight.enabled;
            // 소리 파일 소리볼륨과 함께 한번만 재생
            A_source.PlayOneShot(flash, 1.0f);

        }
    }   
}
