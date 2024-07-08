using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieDemge : MonoBehaviour
{
    
    public GameObject BooldEffect;
    public Rigidbody rb;
    public CapsuleCollider CC;
    public string playerTag = "Player";
    public string bulletTag = "Bullet";
    public Animator animator;
    public string diestr = "IsDie";
    public Canvas canvas;
    public FireGun fireGun;
    public bool is_die = false;
    public Image HpBa;
    public int MaxHp =100;
    public int hpInit=0;
    public int Hp = 0;
    public Text hpTxt;
    FireGun firectrl;

    void Start()
    {
       firectrl = GameObject.FindWithTag("Player").GetComponent<FireGun>();
       rb = this.gameObject.GetComponent<Rigidbody>(); 
       CC = this.gameObject.GetComponent<CapsuleCollider>();
       animator = GetComponent<Animator>();
       hpInit = MaxHp;
       HpBa.color = Color.green;
       
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag(playerTag))
        {

            rb.mass = 5000f; //  플레이어와 충돌될때 좀비 무게 올림
            rb.isKinematic = false; // 물리력 있게
            rb.freezeRotation = true; //회전을 못하도록

        }
        else if (collision.gameObject.CompareTag(bulletTag))
        {
            
            hpInit -= collision.gameObject.GetComponent<Bullet>().Deamge;
            // 원래는 float지만 유저에겐 깍이는 것을 보여주기위해 float로 형변환한것이다.
            HpBa.fillAmount = (float)hpInit / (float)MaxHp;
            hpTxt.text = $"Hp:<color=#ff0000>{hpInit.ToString()}</color>";
            Hitpo(collision);
            // hp바가 30%이하면 빨강색
            if (HpBa.fillAmount <= 0.3f)
                HpBa.color = Color.red;
            // hp바가 50% 이하면 노란색
            else if(HpBa.fillAmount <= 0.5f)
                HpBa.color = Color.yellow;
            if (++Hp == 5)
            {

                ZombieDie();
            }

        }

    }

    private void Hitpo(Collision collision)
    {
        // 맞은 위치를 충돌대상의 위치값을 할당함
        Vector3 hipos = collision.transform.position;
        // 맞은 위치 - 맞은 위치를 뺴면 거리가 나온다.
        Vector3 hitnomal = hipos - firectrl.firepos.position;
        // 방향지정 할당
        hitnomal = hitnomal.normalized;
        // 회전값 에 충돌 대상 회전값을 할당
        Quaternion rot = collision.transform.rotation;
                   
        var Blood = Instantiate(BooldEffect, hipos, rot);
        Destroy(collision.gameObject);
        Destroy(Blood, Random.Range(0.9f, 1.3f));
        animator.SetTrigger("IsHit");
    }

    private void OnCollisionExit(Collision collision)
    {
        rb.mass = 75f;
        
        
    }
    void ZombieDie()
    {
        animator.SetTrigger(diestr);
        CC.enabled = false;
        is_die = true;
        rb.isKinematic = true;
        rb.useGravity = false;
        Destroy(gameObject, 5.0f);
        Destroy(canvas.gameObject);
        GameManger.Instance.KillScore(1);
    }

}
