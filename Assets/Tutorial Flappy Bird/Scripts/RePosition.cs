using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePosition : MonoBehaviour
{
    public float minX;
    public float width;

    private void Start()
    {
        var spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        width = spriteRenderer.sprite.bounds.size.x * transform.lossyScale.x;
        //minX = -width;
    }

    // Update is called once per frame
    void Update()
    {
        // 최저 위치보다 뒤로 갔다면 앞으로 이동시키기
        if (transform.position.x < minX)
        {
            transform.Translate(width * 2, 0, 0);
        }
    }
}
