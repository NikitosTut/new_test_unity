using UnityEngine;

public class SpawnPlayerOnLoad : MonoBehaviour {
    public Transform spawnPoint;

    void Start()
    {
        if (GameData.SelectedCharacter != null)
        {
            Instantiate(GameData.SelectedCharacter.prefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Selected prefab is null!");
        }
    }
}
