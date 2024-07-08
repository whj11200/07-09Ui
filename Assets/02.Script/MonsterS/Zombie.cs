using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    // Attribute 어튜리 뷰트 : 개발자가 쓰면 유니티가 읽어서 실행함
    [Header("애니메이터")]
    public Animator ZombieAni;
    [Header("네비메쉬")]
    public NavMeshAgent Agent;  // 추적할 대상 네비 컴퍼넌트

    public ZombieDemge demage;
    

    public Transform Player; //  플레이어의 위치값
    public Transform thisZombie; //  좀비의 위치값

    public float Hp = 5.0f;
    public float attackDist = 3.0f;//공격범위
    public float traceDist = 20.0f;//추적범위
    void Start()
    {  // 자기자신 게임오브젝트 안에 있는 NavMeshAgent 컴퍼넌트를 대입
        Agent = this.gameObject.GetComponent<NavMeshAgent>();
        //C# 비주얼 스튜디오 에서 Agent = new NavMeshAgent();
        thisZombie = this.gameObject.GetComponent<Transform>();
        ZombieAni = this.gameObject.GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player").transform;// 하이라키안에 있는 게임 오브젝트의 태그를 읽어서 가져온다.
        demage = GetComponent<ZombieDemge>();
    }

    void Update()
    {
        if (demage.is_die)
            return;
        //거리를 잰다
        float distance = Vector3.Distance(thisZombie.position,Player.transform.position);
        if (distance <= attackDist)
        {
            Agent.isStopped = true; // 추적금지
            //Debug.Log("공격 범위 들어옴");
            ZombieAni.SetBool("IsAttack", true);
            
        }
        else if (distance <= traceDist)
        {
           
            //Debug.Log("추적");
            ZombieAni.SetBool("IsTrace",true);
            ZombieAni.SetBool("IsAttack", false);
            Agent.destination = Player.position;
            Agent.isStopped = false; // 추적시작
            Quaternion rot = Quaternion.LookRotation(Player.position - this.transform.position);
            thisZombie.rotation = Quaternion.Slerp(thisZombie.rotation, rot, Time.deltaTime * 3.0f);
            // 부드럽게 곡면 보관하는 함수         ( 자기자신 로테이션에서 플레이어 방향으로 , 주어진시간만큼)
        }
        else
        {
            //Debug.Log("추적 범위 이탈함");
            ZombieAni.SetBool("IsTrace", false);
            ZombieAni.SetBool("IsAttack",false);
            Agent.isStopped = false; // 추적금지
        }

    }
 
}
