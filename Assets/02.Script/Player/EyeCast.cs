using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeCast : MonoBehaviour
{
    private Transform tr; //�ڱ� �ڽ� Ʈ������
    private Ray ray; // ���� 
    private RaycastHit hit; // �������� ����ü 
    private float dist = 20f;// 
    //RaycastHit �������� ����ü ������Ʈ�� ������ �¾Ҵ� �� �Ǻ���
    public CrossHair c_hair;
    void Start()
    {
      tr = GetComponent<Transform>();
      c_hair = GameObject.Find("PlayerUi").transform.GetChild(3).GetComponent<CrossHair>();
      
    }


    void Update()
    {                                          // ����� �Ÿ� :Velocity
        ray = new Ray(transform.position, tr.forward);
        //���� �Ҵ� ���ڸ��� ��ġ�� ����� �Ÿ��� ����
        // ��ġ     ����               ����
        Debug.DrawLine(ray.origin, ray.direction * dist);
        //��ȭ�鿡��  ������ ���̴� �� ������ �׽�Ʈ������ ����� �ϴ� ��

         // ����,���� ������Ʈ��ġ��, �Ÿ�, ���� ���� �Ǻ�
        if (Physics.Raycast(ray, out hit, dist, 1 << 6| 1<<7 | 1<<8))
        {
            // ������ ����� �� ���� �¾Ҵ� ��
            c_hair.is_Gaze = true;
            
        }
        else //������ �����ʾҴٸ� 
        {
            c_hair.is_Gaze= false;
        }
    }
}
