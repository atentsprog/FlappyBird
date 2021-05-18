using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControll : MonoBehaviour
{
    public float delay;
    public float speed = 1;

    public Animator animator;
    IEnumerator Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        animator.speed = speed;

        if (delay > 0)
        {
            animator.enabled = false;
            yield return new WaitForSeconds(delay);
            animator.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
