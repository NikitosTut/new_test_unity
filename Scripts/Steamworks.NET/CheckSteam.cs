using UnityEngine;
using Steamworks;

public class SteamChecker : MonoBehaviour {
    void Awake()
    {
        Debug.Log("Awake() — скрипт SteamChecker загружен");
    }

    void Start()
    {
        Debug.Log("Start() — пробуем инициализировать Steam");

        bool success = SteamAPI.Init();

        if (!success)
        {
            Debug.LogError("❌ SteamAPI.Init() FAILED!");
            return;
        }

        Debug.Log("✅ SteamAPI успешно инициализирован");

        string username = SteamFriends.GetPersonaName();
        string steamId = SteamUser.GetSteamID().ToString();

        Debug.Log($"👤 Steam username: {username}");
        Debug.Log($"🆔 SteamID: {steamId}");
    }

    void Update()
    {
        SteamAPI.RunCallbacks();
    }

    void OnDestroy()
    {
        SteamAPI.Shutdown();
        Debug.Log("SteamAPI завершён");
    }
}
