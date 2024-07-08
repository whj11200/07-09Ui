using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// �� ���� ��� ���
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
#if UNITY_EDITOR //  ��ó���� : �������� �̸� ����� ������ �ִ�.
    UnityEditor.EditorApplication.isPlaying = false;
        // ����Ƽ���� ������ �� �� �¿� ����
#else //  ���忡������
        Application.Quit();
#endif
    }

}
