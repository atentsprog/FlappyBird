using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// FPS가 다를때 같은 거리를 이동하는지 확인.
/// </summary>
public class FixedUpdateTest : MonoBehaviour
{
    private IEnumerator Start()
    {
        Move.Items.ForEach(x => x.enabled = false);

        yield return new WaitForSeconds(1);
        Debug.LogWarning("30프레임 테스트 시작");
        // FPS가 10일때 테스트.
        Application.targetFrameRate = 30;
        ResetTest();
        //활성화중인 공이 있을때까지 대기
        while (Move.Items.Where( x=> x.enabled).Count() > 0)
            yield return null;

        // FPS가 60일때 테스트.
        Debug.LogWarning("60프레임 테스트 시작");
        Application.targetFrameRate = 60;
        ResetTest();
        //활성화중인 공이 있을때까지 대기
        while (Move.Items.Where(x => x.enabled).Count() > 0)
            yield return null;


        // 같은 거리 이동했는지 로그로 확인.
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetTest();
            StartCoroutine(Start());
        }
    }

    /// <summary>
    /// 테스트 처음 부터 시작.
    /// </summary>
    private void ResetTest()
    {
        Move.Items.ForEach(x => x.Reset());
    }
}
