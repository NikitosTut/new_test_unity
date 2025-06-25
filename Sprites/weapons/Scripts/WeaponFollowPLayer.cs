using UnityEngine;

public class WeaponFollow : MonoBehaviour {
    public Transform hero; // сюда перетащи hero (спрайт персонажа)
    public Vector3 offset = new Vector3(10.0f, 0.0f, 0f); // сдвиг оружия от героя

    void LateUpdate()
    {
        if (hero != null)
        {
            transform.position = hero.position + offset;
        }
    }
}
