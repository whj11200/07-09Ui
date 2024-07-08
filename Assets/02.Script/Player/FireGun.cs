using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FireGun : MonoBehaviour
{

    public GameObject bullet; //  총알 오브젝트
    public Transform firepos; //  총알 나가는 위치값
    public HandCtrl boolng; // 핸드 컨트롤 스크립트
    public AudioSource source; //  오디오 소스
    public AudioClip bang; // 오디오 칩
    public Animation Animation; // 애니메이션 컨트롤
    public ParticleSystem muzle; // 파티클 muzle
    public int BulletCount = 8; // 총알 카운터
    public int MaxBullet = 8; // 최대총알
    private float timer; // 현재 시간 타이머
    private float elaapsedTime = 0f; // 재장전 타이밍
    bool DontShot = false; // 총알 발싸 분류값
    public Text BulletText;


    void Start()
    {
        // 핸드컨트롤 스크립트 가져오고
        boolng = this.gameObject.GetComponent<HandCtrl>();
        // 타이머를 현재 시간으로 할당
        timer = Time.time;
        // 머즐 은 처음부터 비활성화
        muzle.Stop();
        BulletText = GameObject.Find("BulletText").GetComponent<Text>();


    }


    void Update()
    {
        
        //만약 마우스를 계속 누를 시
        if (Input.GetMouseButton(0) )
        {
            // 현재 시간 타이머에서 과거 시간을 뺀 값이 0.2f초보다 작을때 결론 0.2초 될때까지
            if (Time.time - timer > 0.2f)
            {
                // 만약 달리는걸 멈추거나 쏴야하는 판정일때
                if (boolng.is_runing == false && !DontShot)
                {
                    // 현재 시간값으로 시작
                    timer = Time.time;
                  
                    // 발싸 함수 
                    fire();
                    // 총알 카운터는 줄어들고
                    
                    
                    // muzle 파티클은 재생
                    muzle.Play();
                    // 원하는 시간간격 만큼 메서드를 호출
                    //          메서드 명    시간
                    
                }
                


            }
            
        }
       
        
    }


    private void fire()
    {
        Instantiate(bullet, firepos.position, firepos.rotation);
        source.PlayOneShot(bang);
        Animation.Play("fire");

        --BulletCount;
        BulletText.text = $"{BulletCount}/{MaxBullet}";

        muzle.Play();
        Invoke("MuzzflashDisable", 0.2f);

        if (BulletCount == 0)
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        DontShot = true;
        Animation.Play("reloadStart");
        Animation.Stop("reloadStart");
        Animation.Play("reloadCycle");
        while (BulletCount < MaxBullet)
        {
            yield return new WaitForSeconds(1f);
            BulletCount++;
            BulletText.text = $"{BulletCount}/{MaxBullet}";
        }
        
        Animation.Play("reloadStop");
        BulletText.text = $"{BulletCount}/{MaxBullet}";
        DontShot = false;
        
        

    }
    void MuzzflashDisable()
    {
        muzle.Stop();
    }
}
