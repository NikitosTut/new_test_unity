using UnityEngine;

public class CharacterClick : MonoBehaviour {
    public CharacterData characterData;
    public GameObject sittingVersion; // ← этот объект и есть сидячий

    private WindowManager windowManager;

    void Start()
    {
        windowManager = FindAnyObjectByType<WindowManager>();
    }

    void OnMouseDown()
    {
        if (windowManager != null)
        {
            windowManager.OpenWindow(characterData, sittingVersion);
        }
    }
}
