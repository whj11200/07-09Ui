using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightOnOff : MonoBehaviour
{
    public Light StairLgiht;
    public AudioSource source;
    public AudioClip clip;
    public AudioClip Exitclip;

    void Start()
    {
        
    }
    // is_Trigger 했을 시 충돌감지하는 함수
    // 콜벡함수라고 스스로 함
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // 충돌시 
            StairLgiht.enabled = true;

            source.PlayOneShot(clip,1.5f);
        }
    }
    // 충돌에서 벗어날시 나오는 함수
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // 충돌에서 벗어날 시 
            StairLgiht.enabled = false;
            source.PlayOneShot(clip,1.0f);
        }
    }
    void Update()
    {
        
    }
}
