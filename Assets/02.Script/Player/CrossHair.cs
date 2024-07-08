using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHair : MonoBehaviour
{
    Transform tr;
    Image crosshair;
    float startTime; // ũ�ν� �� Ŀ���� ������ �ð��� ����
    float duration = 0.25f; //  ũ�ν� �� Ŀ���� �ӵ�
    float minSize = 0.7f; // ũ�ν� ��� �ּ� ũ��
    float maxSize = 1.2f; //  ũ�ν� ��� �ִ� ũ��
    Color originColor = new Color(1f, 1f, 1f, 0.8f);
    // crosshair�� �ʱ����
    // ���� �������϶� ����    
    Color gazeColor = Color.red;
    //�����ϴ��� �ǵ�
    public bool is_Gaze = false;
    
    void Start()
    {
        tr = transform;
        crosshair = GetComponent<Image>();
        startTime = Time.time;
        // x,y,z �����ϰ� ũ�⸦ ������ ����
        tr.localScale = Vector3.one * minSize;
        // ũ�ν������ ��â�� ũ��
    }

    
    void Update()
    {
        if (is_Gaze)
        { //ray�� ���� �������̶��
            float time = (Time.time - startTime)/duration;
                          // (����ð� -���� �ð�)�������� /0.25�� ���� ���
                                          // ���а��� ��� Lerp: interpolate(���� ����)
            tr.localScale = Vector3.one * Mathf.Lerp(minSize, maxSize, time);
            // minSize���� maxSize ���� �ε巴�� Ŀ���� ���ؼ�
            crosshair.color = gazeColor;
            
        }
        else
        {
            // �ݴ�� �������� ���� �� 
            //                      maxSize���� minSize�� ����
            tr.localScale = Vector3.one * minSize;
            crosshair.color = originColor;
            startTime = Time.time;
        }
    }
}
