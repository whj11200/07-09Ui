using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 씬 관련 기능 사용
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManger : MonoBehaviour
{
    public Text KillScroer;

    private void Start()
    {
        KillScroer = GameObject.Find("KillScroeee").GetComponent<Text>();
        KillScroer.text = $"Kill:{GameManger.Instance.KillCount.ToString()}";
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void QuitGame()
    {
#if UNITY_EDITOR //  전처리기 : 컴파일전 미리 기능이 정해져 있다.
    UnityEditor.EditorApplication.isPlaying = false;
        // 유니티에서 편집중 인 상 태에 종료
#else //  빌드에서종료
        Application.Quit();
#endif
    }

}
