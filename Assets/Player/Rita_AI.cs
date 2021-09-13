using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rita_AI : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    public Transform homPosition;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;
    [SerializeField]
    private float stopRange;

    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer();
        }
        else if(Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            GoHome();
        }

    }

    public void FollowPlayer()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

    }

    public void Stop()
    {
        myAnim.SetBool("isMoving", false);
    }

    public void GoHome()
    {
        myAnim.SetFloat("moveX", (homPosition.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (homPosition.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homPosition.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, homPosition.position) == 0)
        {
            myAnim.SetBool("isMoving", false);
        }
    }

}

