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
        // ��Ÿ�ӿ��� enemy �±׵��� ���� ������Ʈ���� enemies��� ���ӿ�����Ʈ �迭��
        // ���� �Ѵ�.
        for (int i = 0; i < enemise.Length; i++)
        {
            enemise[i].gameObject.SendMessage("PlayerDeath", SendMessageOptions.DontRequireReceiver);
            // �ٸ� ���ӿ�����Ʈ �ִ� �޼��� ȣ�� �ϴ� ����� ���� �޼���

           
        }
    }
    void GameOver()
    {
        SceneManager.LoadScene("EndingScene");
    }

}
