using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void StartGame()
    {
        SceneManager.LoadScene("lobby"); // �������� ����� ������� �����
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("���� ���������"); // �������� ������ � �����
    }
}
