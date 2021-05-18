using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollX : MonoBehaviour
{
    public float speedX = -1;

    void Update()
    {
        // 방법1
        transform.Translate(speedX * GameManager.instace.scrollSpeedXMultiply
            * Time.deltaTime, 0, 0);

        //// 방법2
        //var pos = transform.position;
        //pos.x += speedX * Time.deltaTime;
        //transform.position = pos;
    }
}
