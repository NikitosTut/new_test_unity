using UnityEngine;
using Mirror;

public class PlayerMovement : NetworkBehaviour {
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;
    private float initialScaleX; // ��������� ��������� ������� �� X

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initialScaleX = Mathf.Abs(transform.localScale.x); // ���������� ������ ���������� ��������
    }

    void Update()
    {
        if (!isLocalPlayer)
            return;
        Debug.Log($"[Player] isLocalPlayer: {isLocalPlayer}, isServer: {isServer}");
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // ��������� ��������� ��������
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // ������� ������� �����/������
        if (movement.x > 0) // �������� ������
            transform.localScale = new Vector3(initialScaleX, transform.localScale.y, transform.localScale.z);
        else if (movement.x < 0) // �������� �����
            transform.localScale = new Vector3(-initialScaleX, transform.localScale.y, transform.localScale.z);

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}