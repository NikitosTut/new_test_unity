using UnityEngine;

public class WeaponRotation : MonoBehaviour {
    public Transform hero; // Перетащи сюда объект hero (спрайт персонажа)

    void Update()
    {
        // Позиция мышки
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Направление на мышь
        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Поворот оружия на мышь
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Всегда сбрасываем масштаб, чтобы оружие не флипалось вместе с героем
        transform.localScale = Vector3.one;

        // (опционально) Можно вручную отзеркалить по Y, если угол поворота выходит за 90°
        if (angle > 90 || angle < -90)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
    }
}
