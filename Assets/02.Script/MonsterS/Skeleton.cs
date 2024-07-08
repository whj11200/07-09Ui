using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class Skeleton : MonoBehaviour
{
    [Header("컴포넌트")]
    public GameObject Blood;
    public Animator animator;
    public Transform Player;
    public Transform skeleton;
    public Rigidbody rb;
    public CapsuleCollider cap;
    public NavMeshAgent nav;
    public Bullet bullet;
    public Image Hpbar;
    public Text HpText;
    public Image background;
    public AudioSource attackSound;
    public AudioClip attackCilp;
    [Header("매개변수들")]
    public float HpCount = 0;
    public bool is_Stoping = false;
    private float attacking = 3.0f;
    public float finding = 15.0f;
    public string bullettag = "Bullet";
    public string Playertag = "Player";

    public bool is_Dead = false;
    public float Hp = 0;
    public float MaxHp = 100;
   
    void Start()
    {
        animator = GetComponent<Animator>();
        skeleton = GetComponent<Transform>();
        Player = GameObject.FindWithTag("Player").transform;
        cap = GetComponent<CapsuleCollider>();
        nav = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        bullet = GetComponent<Bullet>();
        rb.mass = 75;
        Hp = MaxHp;
        Hpbar.color = Color.grey;
        attackSound = GetComponent<AudioSource>();  
    
    }
   

    void Update()
    {
        if (is_Dead)
            return;
        var finow = Vector3.Distance(Player.transform.position,skeleton.transform.position);

        if (finow < attacking)
        {
            animator.SetBool("Attack", true);
            AttackSound();
            is_Stoping = false;
            Vector3 playerPos = (Player.position-transform.position  ).normalized;
            Quaternion rot = Quaternion.LookRotation(playerPos);
            transform.rotation = Quaternion.Slerp(transform.rotation,rot,Time.deltaTime * 3.0f);
      

        }
        else if(finow < finding)
        {
            nav.destination = Player.transform.position;
            animator.SetBool("Attack", false);
            animator.SetBool("Run", true);
            is_Stoping = true;
            

        }
        else
        {
            animator.SetBool("Attack", false);
            animator.SetBool("Run", false);
            is_Stoping = false;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Playertag))
        {
            rb.mass = 1000;
            rb.freezeRotation = true;

        }
        if (collision.gameObject.CompareTag(bullettag))
        {
           rb.freezeRotation = true;
            rb.mass = 1000;
            Hp -= collision.gameObject.GetComponent<Bullet>().Deamge;
            Hpbar.fillAmount = (float)Hp / (float)MaxHp;
            HpText.text = $"Hp:<color=#ff0000>{Hp.ToString()}</color>";
            if (Hpbar.fillAmount > 0.2f)
                Hpbar.color = Color.red;
            if(Hpbar.fillAmount <= 0.3f)
             Hpbar.color = Color.yellow;
            else if(Hpbar.fillAmount <= 0.7f)
            Hpbar.color = Color.green;
            var Ahoh = Instantiate(Blood, collision.transform.position, Quaternion.identity);
            Destroy(Ahoh, 1.0f);
            Destroy(collision.gameObject);
            animator.SetTrigger("Hit");




            if (Hp == 0)
            {
                Die();

            }
        }
    }

    private void Die()
    {
        animator.SetTrigger("Dead");
        cap.enabled = false;
        is_Dead = true;
        Destroy(rb);
        Destroy(this.Hpbar); Destroy(this.HpText);
        Destroy(this.background);
        rb.freezeRotation = false;

        Destroy(gameObject, 3.0f);
        GameManger.Instance.KillScore(1);
    }

    private void OnCollisionExit(Collision collision)
    {
        rb.mass = 75;
    }

    public void AttackSound()
    {
        attackSound.clip = attackCilp;
        attackSound.PlayDelayed(0.4f);
    }

    
}
