using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePhyBird : Bird
{
    new private void Start()
    {
        base.Start();

        // 인스펙터에서 했다면 아래 코드 적을 필요 없음.
        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        rigidbody2D.useFullKinematicContacts = true;
    }

    public float gravity = -9.8f;
    public float acceleration;
    void Update()
    {
        //중력에 의한 낙하 구현
        acceleration += gravity * Time.deltaTime;

        //y 값 변경.
        transform.Translate(0, acceleration, 0);


        // 터치 했을때 새에 위로 날아오르는 힘 주기

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (Time.time > 0.7f)
            {
                acceleration = forceY;

                //날개 펄럭이는 애니메이션 하자.
                animator.Play("Flap", 0, 0);
            }
        }
    }
}
