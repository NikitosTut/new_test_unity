using UnityEngine;
using Steamworks;

public class LoginSt : MonoBehaviour {
    private void Start()
    {
        if (!SteamAPI.Init())
        {
            Debug.LogError("SteamAPI init failed!");
            return;
        }

        Debug.Log("Steam initialized!");
        string username = SteamFriends.GetPersonaName();
        string steamId = SteamUser.GetSteamID().ToString();

        Debug.Log("Username: " + username);
        Debug.Log("Steam ID: " + steamId);
    }

    private void OnDestroy()
    {
        SteamAPI.Shutdown();
    }

    private void Update()
    {
        SteamAPI.RunCallbacks();
    }
}
