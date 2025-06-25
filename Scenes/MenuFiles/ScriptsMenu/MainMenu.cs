using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    public void StartGame()
    {
        SceneManager.LoadScene("lobby"); // название твоей игровой сцены
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Игра завершена"); // Работает только в билде
    }
}
