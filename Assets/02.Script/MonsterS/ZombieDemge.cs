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

            rb.mass = 5000f; //  �÷��̾�� �浹�ɶ� ���� ���� �ø�
            rb.isKinematic = false; // ������ �ְ�
            rb.freezeRotation = true; //ȸ���� ���ϵ���

        }
        else if (collision.gameObject.CompareTag(bulletTag))
        {
            
            hpInit -= collision.gameObject.GetComponent<Bullet>().Deamge;
            // ������ float���� �������� ���̴� ���� �����ֱ����� float�� ����ȯ�Ѱ��̴�.
            HpBa.fillAmount = (float)hpInit / (float)MaxHp;
            hpTxt.text = $"Hp:<color=#ff0000>{hpInit.ToString()}</color>";
            Hitpo(collision);
            // hp�ٰ� 30%���ϸ� ������
            if (HpBa.fillAmount <= 0.3f)
                HpBa.color = Color.red;
            // hp�ٰ� 50% ���ϸ� �����
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
        // ���� ��ġ�� �浹����� ��ġ���� �Ҵ���
        Vector3 hipos = collision.transform.position;
        // ���� ��ġ - ���� ��ġ�� ���� �Ÿ��� ���´�.
        Vector3 hitnomal = hipos - firectrl.firepos.position;
        // �������� �Ҵ�
        hitnomal = hitnomal.normalized;
        // ȸ���� �� �浹 ��� ȸ������ �Ҵ�
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
