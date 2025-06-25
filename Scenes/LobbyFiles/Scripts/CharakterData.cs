using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Character/Create New")]
public class CharacterData : ScriptableObject {
    public string characterName;
    public Sprite fullAvatar;
    public Sprite miniAvatar;
    public GameObject prefab; // Игровой префаб
}
