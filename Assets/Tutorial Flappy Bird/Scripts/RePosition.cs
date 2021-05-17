using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePosition : MonoBehaviour
{
    public float minX = -30f; // 이값 보다 위치X가 작아지면 오른쪽으로 보내자.

    void Update()
    {
        if(minX > transform.position.x )
        {
            // 오른쪽으로 가로 크기 * 2만큼 보내자.
            // 가로 크기 20.48
            transform.Translate(20.48f * 2, 0, 0);
        }
    }
}
