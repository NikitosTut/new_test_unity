using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
    public float moveSpeed = 2f;
    public float detectionRange = 6f;
    public float stopDistance = 2f;

    private Transform player;
    private Rigidbody2D rb;
    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartCoroutine(FindPlayerWhenReady());
    }

    void Update()
    {
        if (player == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
            else
                return;
        }

        float distance = Vector2.Distance(transform.position, player.position);
        float speed = 0f;

        if (distance <= detectionRange && distance > stopDistance)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
            speed = 1f;

            Vector3 scale = transform.localScale;
            if (player.position.x < transform.position.x)
                scale.x = -Mathf.Abs(scale.x);
            else
                scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;
        }

        if (anim != null)
            anim.SetFloat("Speed", speed);
    }
    IEnumerator FindPlayerWhenReady()
    {
        while (player == null)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Player");
            if (obj != null)
                player = obj.transform;

            yield return null; // ждем 1 кадр
        }
    }
}
