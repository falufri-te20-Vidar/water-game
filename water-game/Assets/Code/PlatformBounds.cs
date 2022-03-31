using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class PlatformBounds : MonoBehaviour
{
    [SerializeField] private BoxCollider2D groundBox;
    [SerializeField] private BoxCollider2D platformBox;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private float offset;

    void Update()
    {
        platformBox.size = spriteRenderer.bounds.size;

        float platformX = spriteRenderer.size.x;
        float xSize = platformX - 2 * offset;
        float ySize = groundBox.size.y;
        groundBox.size = new Vector2(xSize, ySize);
    }
}
