using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHair : MonoBehaviour
{
    Transform tr;
    Image crosshair;
    float startTime; // 크로스 헤어가 커지기 시작한 시간을 저장
    float duration = 0.25f; //  크로스 헤어가 커지는 속도
    float minSize = 0.7f; // 크로스 헤어 최소 크기
    float maxSize = 1.2f; //  크로스 헤어 최대 크기
    Color originColor = new Color(1f, 1f, 1f, 0.8f);
    // crosshair의 초기색상
    // 적을 응시중일때 색상    
    Color gazeColor = Color.red;
    //응시하는지 판독
    public bool is_Gaze = false;
    
    void Start()
    {
        tr = transform;
        crosshair = GetComponent<Image>();
        startTime = Time.time;
        // x,y,z 동일하게 크기를 가지기 위해
        tr.localScale = Vector3.one * minSize;
        // 크로스헤어의 초창기 크기
    }

    
    void Update()
    {
        if (is_Gaze)
        { //ray가 적을 응시중이라면
            float time = (Time.time - startTime)/duration;
                          // (현재시간 -지난 시간)에서에서 /0.25를 나눈 결과
                                          // 수학관련 기능 Lerp: interpolate(선형 보관)
            tr.localScale = Vector3.one * Mathf.Lerp(minSize, maxSize, time);
            // minSize에서 maxSize 까지 부드럽게 커지기 위해서
            crosshair.color = gazeColor;
            
        }
        else
        {
            // 반대로 응시하지 않을 시 
            //                      maxSize에서 minSize로 변경
            tr.localScale = Vector3.one * minSize;
            crosshair.color = originColor;
            startTime = Time.time;
        }
    }
}
