using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(PolygonCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class DynamicPolygonCollider : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider;
    private List<Vector2> path = new List<Vector2>();

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        UpdateCollider();
    }

    void LateUpdate()
    {
        UpdateCollider();
    }

    void UpdateCollider()
    {
        if (spriteRenderer.sprite == null) return;

        polygonCollider.pathCount = 0;
        path.Clear();

        if (spriteRenderer.sprite.GetPhysicsShapeCount() > 0)
        {
            spriteRenderer.sprite.GetPhysicsShape(0, path);
            polygonCollider.pathCount = 1;
            polygonCollider.SetPath(0, path);
        }
    }
}
