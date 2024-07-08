using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FireGun : MonoBehaviour
{

    public GameObject bullet; //  �Ѿ� ������Ʈ
    public Transform firepos; //  �Ѿ� ������ ��ġ��
    public HandCtrl boolng; // �ڵ� ��Ʈ�� ��ũ��Ʈ
    public AudioSource source; //  ����� �ҽ�
    public AudioClip bang; // ����� Ĩ
    public Animation Animation; // �ִϸ��̼� ��Ʈ��
    public ParticleSystem muzle; // ��ƼŬ muzle
    public int BulletCount = 8; // �Ѿ� ī����
    public int MaxBullet = 8; // �ִ��Ѿ�
    private float timer; // ���� �ð� Ÿ�̸�
    private float elaapsedTime = 0f; // ������ Ÿ�̹�
    bool DontShot = false; // �Ѿ� �߽� �з���
    public Text BulletText;


    void Start()
    {
        // �ڵ���Ʈ�� ��ũ��Ʈ ��������
        boolng = this.gameObject.GetComponent<HandCtrl>();
        // Ÿ�̸Ӹ� ���� �ð����� �Ҵ�
        timer = Time.time;
        // ���� �� ó������ ��Ȱ��ȭ
        muzle.Stop();
        BulletText = GameObject.Find("BulletText").GetComponent<Text>();


    }


    void Update()
    {
        
        //���� ���콺�� ��� ���� ��
        if (Input.GetMouseButton(0) )
        {
            // ���� �ð� Ÿ�̸ӿ��� ���� �ð��� �� ���� 0.2f�ʺ��� ������ ��� 0.2�� �ɶ�����
            if (Time.time - timer > 0.2f)
            {
                // ���� �޸��°� ���߰ų� �����ϴ� �����϶�
                if (boolng.is_runing == false && !DontShot)
                {
                    // ���� �ð������� ����
                    timer = Time.time;
                  
                    // �߽� �Լ� 
                    fire();
                    // �Ѿ� ī���ʹ� �پ���
                    
                    
                    // muzle ��ƼŬ�� ���
                    muzle.Play();
                    // ���ϴ� �ð����� ��ŭ �޼��带 ȣ��
                    //          �޼��� ��    �ð�
                    
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
