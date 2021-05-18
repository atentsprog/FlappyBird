using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    new public Rigidbody2D rigidbody2D;
    public Animator animator;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public float forceY = 100;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Vector2 force;
            force.x = 0;
            force.y = forceY;
            //rigidbody2D // 낙하중 -> 멈추고 나서 -> 힘을 줘야지 force적용됨
            rigidbody2D.velocity = Vector2.zero;// new Vector2(0, 0);
            rigidbody2D.AddForce(force);

            //날개 펄럭이는 애니메이션 하자.
            animator.Play("Flap", 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 새죽음.
        //죽는 애니메이션 하자.

        //게임 오버 UI표시
        GameManager.instace.SetGameOver();

        // 스크롤 하는것들 다 멈추기
        animator.Play("Die", 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instace.AddScore();
    }
}
