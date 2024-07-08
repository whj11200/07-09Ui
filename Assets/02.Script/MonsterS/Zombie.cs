using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    // Attribute ��Ʃ�� ��Ʈ : �����ڰ� ���� ����Ƽ�� �о ������
    [Header("�ִϸ�����")]
    public Animator ZombieAni;
    [Header("�׺�޽�")]
    public NavMeshAgent Agent;  // ������ ��� �׺� ���۳�Ʈ

    public ZombieDemge demage;
    

    public Transform Player; //  �÷��̾��� ��ġ��
    public Transform thisZombie; //  ������ ��ġ��

    public float Hp = 5.0f;
    public float attackDist = 3.0f;//���ݹ���
    public float traceDist = 20.0f;//��������
    void Start()
    {  // �ڱ��ڽ� ���ӿ�����Ʈ �ȿ� �ִ� NavMeshAgent ���۳�Ʈ�� ����
        Agent = this.gameObject.GetComponent<NavMeshAgent>();
        //C# ���־� ��Ʃ��� ���� Agent = new NavMeshAgent();
        thisZombie = this.gameObject.GetComponent<Transform>();
        ZombieAni = this.gameObject.GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player").transform;// ���̶�Ű�ȿ� �ִ� ���� ������Ʈ�� �±׸� �о �����´�.
        demage = GetComponent<ZombieDemge>();
    }

    void Update()
    {
        if (demage.is_die)
            return;
        //�Ÿ��� ���
        float distance = Vector3.Distance(thisZombie.position,Player.transform.position);
        if (distance <= attackDist)
        {
            Agent.isStopped = true; // ��������
            //Debug.Log("���� ���� ����");
            ZombieAni.SetBool("IsAttack", true);
            
        }
        else if (distance <= traceDist)
        {
           
            //Debug.Log("����");
            ZombieAni.SetBool("IsTrace",true);
            ZombieAni.SetBool("IsAttack", false);
            Agent.destination = Player.position;
            Agent.isStopped = false; // ��������
            Quaternion rot = Quaternion.LookRotation(Player.position - this.transform.position);
            thisZombie.rotation = Quaternion.Slerp(thisZombie.rotation, rot, Time.deltaTime * 3.0f);
            // �ε巴�� ��� �����ϴ� �Լ�         ( �ڱ��ڽ� �����̼ǿ��� �÷��̾� �������� , �־����ð���ŭ)
        }
        else
        {
            //Debug.Log("���� ���� ��Ż��");
            ZombieAni.SetBool("IsTrace", false);
            ZombieAni.SetBool("IsAttack",false);
            Agent.isStopped = false; // ��������
        }

    }
 
}
