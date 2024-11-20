using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float speed;
    Vector3 targetPos;
    public GameObject myTarget;
    Vector3 vel;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = myTarget.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = myTarget.transform.position;
        //transform.position = Vector3.Lerp(transform.position, targetPos, speed);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref vel, speed);
    }
}
