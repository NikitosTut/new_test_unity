using UnityEngine;

public class WeaponRotation : MonoBehaviour {
    public Transform hero; // �������� ���� ������ hero (������ ���������)

    void Update()
    {
        // ������� �����
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // ����������� �� ����
        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // ������� ������ �� ����
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // ������ ���������� �������, ����� ������ �� ��������� ������ � ������
        transform.localScale = Vector3.one;

        // (�����������) ����� ������� ����������� �� Y, ���� ���� �������� ������� �� 90�
        if (angle > 90 || angle < -90)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
    }
}
