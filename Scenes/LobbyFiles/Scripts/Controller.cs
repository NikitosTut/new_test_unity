using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class WindowManager : MonoBehaviour {
    [Header("UI Elements")]
    public GameObject infoWindow;
    public GameObject clickCatcher;
    public GameObject playerHUD;
    public GameObject juddyPanel;
    public Image fullAvatarImage;
    public Image miniAvatarImage;
    public TMP_Text nameText;

    [Header("Spawn")]
    public Transform lobbySpawnPoint;

    private CharacterData selectedCharacter;
    private GameObject currentPlayableCharacter;
    private GameObject currentSittingCharacter;
    private GameObject previousSittingCharacter;

    void Start()
    {
        infoWindow?.SetActive(false);
        clickCatcher?.SetActive(false);
        playerHUD?.SetActive(false);
        juddyPanel?.SetActive(false);
    }

    public void OpenWindow(CharacterData data, GameObject sittingObj)
    {
        Debug.Log("�������� ���� ����");
        selectedCharacter = data;
        currentSittingCharacter = sittingObj;

        if (nameText != null) nameText.text = data.characterName;
        if (fullAvatarImage != null) fullAvatarImage.sprite = data.fullAvatar;
        if (miniAvatarImage != null) miniAvatarImage.sprite = data.miniAvatar;

        if (!infoWindow.activeSelf)
        {
            infoWindow.SetActive(true);
            juddyPanel.SetActive(true);
            StartCoroutine(EnableClickCatcherDelayed());
        }
    }

    private IEnumerator EnableClickCatcherDelayed()
    {
        yield return new WaitForSeconds(0.05f);
        clickCatcher?.SetActive(true);
    }

    public void CloseWindow()
    {
        Debug.Log("�������� ���� ����");
        infoWindow?.SetActive(false);
        clickCatcher?.SetActive(false);
        juddyPanel?.SetActive(false);
    }

    public void UseSelectedCharacter()
    {
        if (selectedCharacter == null || selectedCharacter.prefab == null)
            return;

        Debug.Log("������������ ���������� ���������");

        // ������� ����������� ��������, ���� �� ����
        if (previousSittingCharacter != null)
        {
            previousSittingCharacter.SetActive(true);
        }

        // ������� �������� �������� ���������, ���� ����
        if (currentPlayableCharacter != null)
        {
            Destroy(currentPlayableCharacter);
        }

        // �������� �������� �������� (������ ����������)
        if (currentSittingCharacter != null)
        {
            currentSittingCharacter.SetActive(false);
        }

        // ������� ������
        currentPlayableCharacter = Instantiate(selectedCharacter.prefab, lobbySpawnPoint.position, Quaternion.identity);
        GameData.SelectedCharacter = selectedCharacter;

        // HUD ��������
        if (playerHUD != null)
            playerHUD.SetActive(true);

        // ��������� ������ �� ����������� ��������
        previousSittingCharacter = currentSittingCharacter;

        // ��������� ����
        CloseWindow();
    }
}
