using UnityEngine;
using Mirror;

public class GoToMapTrigger : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (GameData.SelectedCharacter == null)
        {
            Debug.LogError("GameData.SelectedCharacter is null!");
            return;
        }

        Debug.Log("▶ Запуск Mirror с выбранным персонажем: " + GameData.SelectedCharacter.characterName);
        Debug.Log("Prefab: " + GameData.SelectedCharacter.prefab.name);

        // Запуск как хост
        NetworkManager.singleton.StartHost(); // или StartClient()
    }
}
