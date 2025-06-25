using UnityEngine;

public class WeaponFollow : MonoBehaviour {
    public Transform hero; // ���� �������� hero (������ ���������)
    public Vector3 offset = new Vector3(10.0f, 0.0f, 0f); // ����� ������ �� �����

    void LateUpdate()
    {
        if (hero != null)
        {
            transform.position = hero.position + offset;
        }
    }
}
