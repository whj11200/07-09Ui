using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//싱글톤 기법
//게임매니저는 게임 전체를 컨트롤 해야하므로 
//접근이 쉬어야한다.Static 변수를 만든 후 
//이변수를 대표해서 게임매니저에 접근하게 해야 한다.
//무분별한 객체생성을 막고 하나만 딱 생성하게 해야한다.

//클래스  < 기능적 성격 
  //       < Control 클래스
  //       < 자료적 클래스 
  // 1. 적프리팹 2. 태어날 위치들 3. 시간간격 5. 몇마리 생성할지
public class GameManger : MonoBehaviour
{
    public static GameManger Instance;
    public GameObject[] monsters;
   
    public Transform[] spawnPoints;
    private float timer = 3.0f;
    private float timer2;
    private float timer3;
    private int MaxCount = 10;
    private int MaxCount2 = 10; 
    private float timePrev = 0;
    private int maxCount = 10;
    string enemyTag = "enemy";
    [Header("KillText 관련 변수")]
    public Text KillText;
    public Outline KillTextOutline;
    public int KillCount = 0;
    
   
    
    
    void Start()
    {
        Instance = this; // 객체생성 게임매니저에 public 이라고 선언된 변수나 매서드는 다 접근가능하다.
        // 하이라키에서 sqawn points 라는 오브젝트 명을 찾는다.
        spawnPoints = GameObject.Find("Spean").GetComponentsInChildren<Transform>();
        timer = Time.time;
      //timePrev = Time.time;
        KillText = GameObject.Find("KillText").GetComponent<Text>();
        KillTextOutline = GameObject.Find("KillText").GetComponent<Outline>();


    }

    
    void Update()
    {
        timePrev += Time.deltaTime;
        int enemyCount = GameObject.FindGameObjectsWithTag(enemyTag).Length;
        SpweanMonster(enemyCount);

    }

    private void SpweanMonster(int enemyCount)
    {
        if (timePrev >= 3f)
        {
            if (enemyCount < maxCount)
            {
                // 하이라키에서  ZOMBIE 태그를 가진 오브젝트들의 갯수를 카운트해서 넘김
                ZombieSpwean();
                timePrev = 0f;
            }


        }
    }

    private void ZombieSpwean()
    {
        int ZombieCount = GameObject.FindGameObjectsWithTag(enemyTag).Length;

        if (ZombieCount < MaxCount)
        {

            int randomSpawnPointIndex = Random.Range(1, spawnPoints.Length);
            int randomMonsterIndex = Random.Range(0, monsters.Length);
            Instantiate(monsters[randomMonsterIndex], spawnPoints[randomSpawnPointIndex].position, spawnPoints[randomSpawnPointIndex].rotation);
            timer = Time.time;
        }
    }
    public void KillScore(int score)
    {
        KillCount += score;// 킬스코어에 1개 추가요
        KillText.text = $"Kill: <color=#ff0000>{KillCount.ToString()}</color>";
        KillTextOutline.effectColor = new Color32(255, 0, 0, 120);
        KillTextOutline.effectDistance = new Vector2 { x = 1f, y = 1f };
        StartCoroutine(ReCounting());


    }
    IEnumerator ReCounting()
    {
        
        KillTextOutline.effectDistance = new Vector2 { x = 1, y = 1 };
        KillTextOutline.effectColor = new Color32(0, 0, 0, 255);
        yield return new WaitForSeconds(0.1f);
        KillTextOutline.effectDistance = new Vector2 { x = 7, y = 7 };
        yield return new WaitForSeconds(0.2f);
        KillTextOutline.effectDistance = new Vector2 { x = 1, y = 1 };

    }
   
}

