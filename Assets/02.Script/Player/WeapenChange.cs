using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeapenChange : MonoBehaviour
{
    public SkinnedMeshRenderer spas12;
    public MeshRenderer[] Ak47;
    public MeshRenderer[] M4A1;
    public Animation CombatSg;
    public FireGun BulletReset;
    void Start()
    {
        BulletReset = this.gameObject.GetComponent<FireGun>();
    }


    void Update()
    {
        // Alpjha1 ���� 1
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeapenChange1();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WeapenChange2();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            WeapenChange3();
        }
    }

    private void WeapenChange3()
    {
        CombatSg.Play("draw");
        for (int i = 0; i < M4A1.Length; i++)
        {
           
            M4A1[i].enabled = false; //  �޽������� Ȱ��ȭ


            spas12.enabled = true; //  ��Ű�� �޽������� ��Ȱ��ȭ

        }
        // M4A1�� ��Ȱ��ȭ
        for (int i = 0; i < Ak47.Length; i++)
        {

            Ak47[i].enabled = false;
        }
        foreach (MeshRenderer mesh in M4A1)
        {
            mesh.enabled = false;
        }
        foreach (MeshRenderer mesh in Ak47)
        {
            mesh.enabled = false;
        }
    }

    private void WeapenChange2()
    {
        CombatSg.Play("draw");
        for (int i = 0; i < M4A1.Length; i++)
        {
            
            M4A1[i].enabled = true; //  �޽������� Ȱ��ȭ


            spas12.enabled = false; //  ��Ű�� �޽������� ��Ȱ��ȭ

        }
        // M4A1�� ��Ȱ��ȭ
        for (int i = 0; i < Ak47.Length; i++)
        {

            Ak47[i].enabled = false;
        }
        foreach (MeshRenderer mesh in M4A1)
        {
            mesh.enabled = true;
        }
        foreach (MeshRenderer mesh in Ak47)
        {
            mesh.enabled = false;
        }
    }

    private void WeapenChange1()
    {
        CombatSg.Play("draw");
        for (int i = 0; i < Ak47.Length; i++)
        {
           
            Ak47[i].enabled = true; //  �޽������� Ȱ��ȭ


            spas12.enabled = false; //  ��Ű�� �޽������� ��Ȱ��ȭ

        }
        // M4A1�� ��Ȱ��ȭ
        for (int i = 0; i < M4A1.Length; i++)
        {

            M4A1[i].enabled = false;
        }
        foreach (MeshRenderer mesh in Ak47)
        {
            mesh.enabled = true;
        }
        foreach (MeshRenderer mesh in M4A1)
        {
            mesh.enabled = false;
        }
    }
}
