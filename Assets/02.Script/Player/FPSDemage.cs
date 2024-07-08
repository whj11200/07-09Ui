using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;


public class FPSDemage : MonoBehaviour
{

    public FirstPersonController MouseLuck;
    public FireGun fireGun;
    public Image HpBar;
    public Text HpTxt;
    public int Hp = 0;
    public int MaxHp = 100;
    public string attackTag = "Attack";
    public string zombieattacktag = "Zattack";
    public string Mosterattacktag = "Mattack";
    public GameObject youdie;
    public bool isPlayerDie = false;
    

    void Start()
    {
        Hp = MaxHp;
        HpBar.color = Color.yellow;
        Hpinpo();
        youdie = GameObject.Find("PlayerUi").transform.GetChild(5).gameObject;
        
    }
   

    private void Hpinpo()
    {
        HpTxt.text = $"HP: <color=#ff0000>{Hp.ToString()}</color>";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(attackTag))
        {
            Deamge();
        }
        if(other.gameObject .CompareTag(zombieattacktag))
        {
            Deamge();
        }
        if (other.gameObject.CompareTag(Mosterattacktag))
        {
            Deamge();
        }
        if (Hp <= 0)
        {
            Invoke("GameOver", 3.0f);
            youdie.SetActive(true);
            
        }
        

    }

    void Deamge()
    {
        Hp -= 15;
        Hp = Mathf.Clamp(Hp, 0, 100);
        HpBar.fillAmount = (float)Hp / (float)MaxHp;
        HpTxt.text = $"<color=#83FF96>hp:{Hp.ToString()}</color>";
       
    }
    void PlayerDie()
    {
        isPlayerDie = true;
        GameObject[] enemise = GameObject.FindGameObjectsWithTag("enemy");
        // 런타임에서 enemy 태그들을 가진 오브젝트들을 enemies라는 게임오브젝트 배열에
        // 저장 한다.
        for (int i = 0; i < enemise.Length; i++)
        {
            enemise[i].gameObject.SendMessage("PlayerDeath", SendMessageOptions.DontRequireReceiver);
            // 다른 게임오브젝트 있는 메서드 호출 하는 기능을 가진 메서드

           
        }
    }
    void GameOver()
    {
        SceneManager.LoadScene("EndingScene");
    }

}
