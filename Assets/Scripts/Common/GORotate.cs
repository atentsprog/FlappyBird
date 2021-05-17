using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GORotate : MonoBehaviour
{
    public float rotateZ = 50f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 1), rotateZ * Time.deltaTime);
    }
}
