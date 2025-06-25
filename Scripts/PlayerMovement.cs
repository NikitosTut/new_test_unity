using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour {
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    private float initialScaleX; // Сохраняем начальный масштаб по X

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initialScaleX = Mathf.Abs(transform.localScale.x); // Запоминаем модуль начального масштаба
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;
        Debug.Log($"[Player] isLocalPlayer: {isLocalPlayer}, isServer: {isServer}");
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Обновляем параметры анимации
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // Поворот спрайта влево/вправо
        if (movement.x > 0) // Движение вправо
            transform.localScale = new Vector3(initialScaleX, transform.localScale.y, transform.localScale.z);
        else if (movement.x < 0) // Движение влево
            transform.localScale = new Vector3(-initialScaleX, transform.localScale.y, transform.localScale.z);

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}