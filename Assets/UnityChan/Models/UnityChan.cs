using UnityEngine;
using System.Collections;

public class UnityChan : MonoBehaviour
{
    Vector3 target;
    float speed = 5f;
    Animator animator;

    // Use this for initialization
    void Start ()
    {
        target = new Vector3(0f, 0f, -5f);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        var diff = target - transform.position;
        if (diff.magnitude < 0.1f)
        {
            rigidbody.velocity = Vector3.zero;
            transform.position = target;
            animator.SetFloat("Speed", 0.0f);
        }
        else
        {
            rigidbody.velocity = diff.normalized * speed;
            animator.SetFloat("Speed", 0.2f);
        }
    }
}
