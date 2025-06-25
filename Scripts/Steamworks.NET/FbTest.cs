using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using Steamworks;

public class SteamFirebaseManager : MonoBehaviour {
    private DatabaseReference dbRef;
    private FirebaseApp app; // сохраняем ссылку на созданный инстанс

    void Start()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            if (task.Result == DependencyStatus.Available)
            {
                AppOptions options = new AppOptions()
                {
                    ProjectId = "unitygametest-bba31",
                    AppId = "1:163043904633:android:abcdef123456",
                    ApiKey = "AIzaSyDkVDMkmKNO0t-MCXqN90gmchRLM0AGx0Y",
                    DatabaseUrl = new System.Uri("https://unitygametest-bba31-default-rtdb.europe-west1.firebasedatabase.app/")
                };

                app = FirebaseApp.Create(options, "SteamGameApp");

                dbRef = FirebaseDatabase.GetInstance(app).RootReference;

                Debug.Log("✅ Firebase готов к работе с явными настройками");

                TryLoginOrRegister(); // <--- теперь работает корректно
            }
            else
            {
                Debug.LogError("❌ Firebase не доступен: " + task.Result);
            }
        });
    }

    void TryLoginOrRegister()
    {
        if (!SteamManager.Initialized)
        {
            Debug.LogError("Steam не инициализирован");
            return;
        }

        string steamId = SteamUser.GetSteamID().ToString();
        string username = SteamFriends.GetPersonaName();

        string playerPath = "players/" + steamId;

        FirebaseDatabase.GetInstance(app).GetReference(playerPath).GetValueAsync().ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted)
            {
                Debug.LogError("❌ Ошибка при чтении из Firebase: " + task.Exception);
                return;
            }

            if (task.IsCanceled)
            {
                Debug.LogError("⛔ Запрос к Firebase отменён");
                return;
            }

            if (task.IsCompleted)
            {
                Debug.Log("📥 Ответ от Firebase получен");

                if (task.Result.Exists)
                {
                    Debug.Log("🔓 Авторизация: Игрок уже существует");
                    Debug.Log("👤 Ник: " + task.Result.Child("username").Value);
                    Debug.Log("🪙 Монеты: " + task.Result.Child("coins").Value);
                }
                else
                {
                    Debug.Log("🆕 Регистрация: Новый игрок");

                    PlayerData newPlayer = new PlayerData
                    {
                        steamId = steamId,
                        username = username,
                        coins = 0
                    };

                    string json = JsonUtility.ToJson(newPlayer);

                    FirebaseDatabase.GetInstance(app).GetReference("players").Child(steamId)
                        .SetRawJsonValueAsync(json).ContinueWithOnMainThread(saveTask =>
                        {
                            if (saveTask.IsCompleted)
                            {
                                Debug.Log("🎉 Игрок зарегистрирован: " + username);
                            }
                            else
                            {
                                Debug.LogError("❌ Ошибка сохранения игрока в Firebase: " + saveTask.Exception);
                            }
                        });
                }
            }
        });
    }
}

[System.Serializable]
public class PlayerData {
    public string steamId;
    public string username;
    public int coins;
}
