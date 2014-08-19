using UnityEngine;
using System.Collections;

public class UnityChan : MonoBehaviour
{
    Vector3 target;
    float speed = 5f;
    Animator animator;
    bool running;
    public FollowObject followCamera;
    public GameObject ballPrefab;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
        running = false;
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        var diff = target - transform.position;
        if (running && transform.position.x > -2f)
        {
            animator.SetTrigger("Slide");
            running = false;
            Invoke("Reset", 3f);
        }
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

    Vector3 force;
    public void Run(Vector3 force)
    {
        target = Vector3.right;
        running = true;
        this.force = force;
    }

    void Reset()
    {
        target = Vector3.zero;
        Instantiate(
            ballPrefab,
            new Vector3(1f, 3f),
            Quaternion.identity
        );
    }

    void OnTriggerEnter(Collider other)
    {
        Ball ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            other.rigidbody.AddForce(force * 1000);
            followCamera.Follow(other.gameObject);
        }
    }
}
