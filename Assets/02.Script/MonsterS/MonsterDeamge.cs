using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterDeamge : MonoBehaviour
{
    public GameObject blood;
    public Animator  monsterani;
    public Rigidbody rb;
    public Bullet bullet;
    public CapsuleCollider cap;
    public string Bullettag = "Bullet";
    public float Hit = 0;
    public bool is_die = false;
    public int inHp = 0;
    public int MaxHp = 100;
    public Image HPBA;
    public Text text;
    public Canvas canvas;
    void Start()
    {
        monsterani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        cap = GetComponent<CapsuleCollider>();
        bullet = GetComponent<Bullet>();
        inHp = MaxHp;
        HPBA.color = Color.red;
    }

    
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag(Bullettag))
        {
            inHp -= other.gameObject.GetComponent<Bullet>().Deamge;
            HPBA.fillAmount = (float)inHp/(float)MaxHp;
            text.text = $"<color=#83FF96>hp:{inHp.ToString()}</color>";
            if (HPBA.fillAmount < 0.2f)
                HPBA.color = Color.black;
            else if(HPBA.fillAmount < 0.7f)
                HPBA.color = Color.blue;
            ++Hit;
            rb.mass = 500f;
            rb.freezeRotation = true;
            monsterani.SetTrigger("HIT");
            var blood2 = Instantiate(blood, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(blood2, Random.Range(0.13f, 0.5f));
            if (inHp <= 0)
            {
                Die();

            }


        }
    }

    private void Die()
    {
        rb.useGravity = false;
        cap.enabled = false;
        is_die = true;
        rb.isKinematic = true;
        Destroy(canvas.gameObject);
        monsterani.SetTrigger("Dead");
        GameManger.Instance.KillScore(1);
    }
}
