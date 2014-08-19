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
            animator.SetFloat("Speed", 5f);
        }
    }

    public void SetPosition(float power)
    {
        power = Mathf.Clamp(power, 0.2f, 1.0f);
        target = Vector3.left * 10f * power;
    }

    public void Run()
    {
        target = Vector3.zero;
        animator.SetFloat("Speed", 5f);
    }
}
