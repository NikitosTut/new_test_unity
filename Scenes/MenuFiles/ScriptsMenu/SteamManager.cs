using UnityEngine;
using Steamworks;

public class MySteamAuth : MonoBehaviour {
    void Awake()
    {
        Debug.Log("[SteamAuth] Awake");
    }

    void Start()
    {
        Debug.Log("[SteamAuth] Start");

        if (!SteamAPI.Init())
        {
            Debug.LogError("SteamAPI init failed!");
            return;
        }

        Debug.Log("[SteamAuth] Steam initialized!");

        string username = SteamFriends.GetPersonaName();
        string steamId = SteamUser.GetSteamID().ToString();

        Debug.Log("[SteamAuth] Username: " + username);
        Debug.Log("[SteamAuth] Steam ID: " + steamId);
    }


    private void Update()
    {
        SteamAPI.RunCallbacks();
    }

    private void OnDestroy()
    {
        SteamAPI.Shutdown();
    }
}
