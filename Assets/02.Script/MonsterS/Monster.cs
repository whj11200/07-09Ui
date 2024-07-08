using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent agent;
    public Transform Player;
    public Transform Monst;
    public Rigidbody rb;
    public CapsuleCollider cap;
    public MonsterDeamge mostercsfile;
    
    public float Hit = 0;
    public string Bullettag = "Bullet";
    public float Attacking = 3.0f; //  ���ݹ���
    public float Watching = 10.0f; // ��������

    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        Player = GameObject.FindWithTag("Player").transform;
        Monst = this.gameObject.GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody>();
        cap = gameObject.GetComponent<CapsuleCollider>();
        mostercsfile = GetComponent<MonsterDeamge>();
        
    }


    void Update()
    {
        if (mostercsfile.is_die)
            return;

        //  �ڽ� ������Ʈ�� �÷��̾� ������Ʈ �Ÿ� ����
        float dicene = Vector3.Distance(Monst.position, Player.transform.position);
        if (dicene <= Attacking)
        {
            agent.isStopped = true;
            //Debug.Log("������");
            animator.SetBool("Attack", true);
            ////Vector3 playerPos = Player.transform.position - transform.position;
            ////playerPos = playerPos.normalized;
            ////Quaternion rot = Quaternion.LookRotation(playerPos);
            ////transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 3.0f);
            //Vector3 playerPos = (Player.position - transform.position).normalized;
            //Quaternion rot = Quaternion.LookRotation(playerPos);
            //transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 3.0f);
            

         Vector3 playerPos = (Player.position - transform.position).normalized;

         //                                        ~~  ����               ~~����
         Quaternion rot = Quaternion.FromToRotation(transform.forward, playerPos);
         transform.rotation = Quaternion.Slerp(transform.rotation, rot * transform.rotation, Time.deltaTime * 3.0f);
            

        }
        // �����ϸ鼭 �i�ƿ��� ����
        else if (dicene <= Watching)
        {
            //Debug.Log("������");
            agent.isStopped = false;
            animator.SetBool("Walk", true);
            animator.SetBool("Attack", false);
            // �׺�޽��� �ִ� destination�� �ڵ����� ��η� �����ؼ� player��ġ���� ã�� ���� ���󰣴�.
            agent.destination = Player.position;


        }
       
        else
        {
            ////Debug.Log("�����");
            agent.isStopped = false;
            animator.SetBool("Walk", false);
            animator.SetBool("Attack", false);
        }
       
    }
   
}
