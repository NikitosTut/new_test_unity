using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkManagerLobbyCustom : NetworkManager {
    public List<CharacterData> availableCharacters;

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        // Выбранный персонаж
        var selected = GameData.SelectedCharacter;

        if (selected == null || selected.prefab == null)
        {
            Debug.LogError("❌ Не выбран персонаж или отсутствует префаб.");
            return;
        }

        GameObject player = Instantiate(selected.prefab, Vector3.zero, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player);
    }
}
