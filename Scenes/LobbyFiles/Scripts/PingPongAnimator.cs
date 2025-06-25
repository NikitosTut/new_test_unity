using UnityEngine;

public class PingPongAnimator : MonoBehaviour {
    private Animator animator;
    private float direction = 1f;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("Speed", direction);
    }

    void Update()
    {
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);

        // Когда дошёл до конца, идем в обратную сторону
        if (info.normalizedTime >= 1f && direction > 0)
        {
            direction = -1f;
            animator.SetFloat("Speed", direction);
        }
        // Когда дошли до начала, снова вперед
        else if (info.normalizedTime <= 0f && direction < 0)
        {
            direction = 1f;
            animator.SetFloat("Speed", direction);
        }
    }
}
