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
    public float Attacking = 3.0f; //  공격범위
    public float Watching = 10.0f; // 감지범위

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

        //  자신 오브젝트와 플레이어 오브젝트 거리 저장
        float dicene = Vector3.Distance(Monst.position, Player.transform.position);
        if (dicene <= Attacking)
        {
            agent.isStopped = true;
            //Debug.Log("공격중");
            animator.SetBool("Attack", true);
            ////Vector3 playerPos = Player.transform.position - transform.position;
            ////playerPos = playerPos.normalized;
            ////Quaternion rot = Quaternion.LookRotation(playerPos);
            ////transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 3.0f);
            //Vector3 playerPos = (Player.position - transform.position).normalized;
            //Quaternion rot = Quaternion.LookRotation(playerPos);
            //transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * 3.0f);
            

         Vector3 playerPos = (Player.position - transform.position).normalized;

         //                                        ~~  에서               ~~까지
         Quaternion rot = Quaternion.FromToRotation(transform.forward, playerPos);
         transform.rotation = Quaternion.Slerp(transform.rotation, rot * transform.rotation, Time.deltaTime * 3.0f);
            

        }
        // 감지하면서 쫒아오게 설게
        else if (dicene <= Watching)
        {
            //Debug.Log("감지중");
            agent.isStopped = false;
            animator.SetBool("Walk", true);
            animator.SetBool("Attack", false);
            // 네비메쉬에 있는 destination은 자동으로 경로로 지정해서 player위치값을 찾아 같게 따라간다.
            agent.destination = Player.position;


        }
       
        else
        {
            ////Debug.Log("대기중");
            agent.isStopped = false;
            animator.SetBool("Walk", false);
            animator.SetBool("Attack", false);
        }
       
    }
   
}
