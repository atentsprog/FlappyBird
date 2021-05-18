using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePhyBird : Bird
{
    new void Start()
    {
        // 부모함수의 Start호출
        base.Start();

        // 코드로 해주거나 인스펙터를 수정하거나
        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        rigidbody2D.useFullKinematicContacts = true;
    }

    public float acceleration;
    public float addForce = 1f;
    
    void Update()
    {
        if (Time.timeScale == 0)
            return;

        //가속도 acceleration
        acceleration += gravity * Time.deltaTime;
        transform.Translate(0, acceleration, 0);
        

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time > 0.7f) // 게임 시작하고 0.7초 안의 클릭은 무시, 시작 직전에 눌렀던 클릭이벤트가 실행되는것을 방지
            {
                acceleration = addForce;
                animator.Play("Flap", 0, 0);
            }
        }
    }
}
