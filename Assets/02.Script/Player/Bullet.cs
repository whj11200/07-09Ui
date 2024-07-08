using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 500f;
    public Rigidbody rb;
    public int Deamge = 20;
    void Start()
    {
        // 로컬 좌표로 스피드 만큼 곱해서 앞으로 나가게 해준다.
        // Vector3 .forward 는 글로벌로 잡혀서 되도록 로컬좌표로 잡아야한다.
        rb.AddForce(transform.forward * Speed);
        Destroy(gameObject, 3f);
    }
    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
        
    }



}
