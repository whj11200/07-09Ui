using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
//�̱��� ���
//���ӸŴ����� ���� ��ü�� ��Ʈ�� �ؾ��ϹǷ� 
//������ ������Ѵ�.Static ������ ���� �� 
//�̺����� ��ǥ�ؼ� ���ӸŴ����� �����ϰ� �ؾ� �Ѵ�.
//���к��� ��ü������ ���� �ϳ��� �� �����ϰ� �ؾ��Ѵ�.

//Ŭ����  < ����� ���� 
  //       < Control Ŭ����
  //       < �ڷ��� Ŭ���� 
  // 1. �������� 2. �¾ ��ġ�� 3. �ð����� 5. ��� ��������
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
    [Header("KillText ���� ����")]
    public Text KillText;
    public Outline KillTextOutline;
    public int KillCount = 0;
    
   
    
    
    void Start()
    {
        Instance = this; // ��ü���� ���ӸŴ����� public �̶�� ����� ������ �ż���� �� ���ٰ����ϴ�.
        // ���̶�Ű���� sqawn points ��� ������Ʈ ���� ã�´�.
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
                // ���̶�Ű����  ZOMBIE �±׸� ���� ������Ʈ���� ������ ī��Ʈ�ؼ� �ѱ�
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
        KillCount += score;// ų���ھ 1�� �߰���
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

