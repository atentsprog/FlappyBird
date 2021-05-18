using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float gravity = -0.02f;
    public float force = 1f;
    private Vector3 originalPos;
    public Animator animator;
    new public Rigidbody2D rigidbody2D;

    protected void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        originalPos = transform.position;

        GameManager.instance.ShowGameOver(false);
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Physics.gravity = new Vector3(0, gravity, 0);


        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2D.velocity = Vector3.zero;
            rigidbody2D.AddForce(new Vector2(0, force));

            animator.Play("Flap", 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("충돌 " + collision.transform.name);
        enabled = false; // Update 함수 반복을 멈춤.
        animator.Play("Die", 0, 0);

        GameManager.instance.ShowGameOver(true);

        ScrollPosition.Items.ForEach(x => x.enabled = false);

        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
    }
}
