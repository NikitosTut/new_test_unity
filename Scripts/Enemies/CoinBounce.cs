using UnityEngine;

public class CoinBounce : MonoBehaviour {
    public float bounceHeight = 0.3f;   // Насколько подскакивает
    public float bounceSpeed = 3f;      // Скорость колебания

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.position = startPos + new Vector3(0, yOffset, 0);
    }
}
