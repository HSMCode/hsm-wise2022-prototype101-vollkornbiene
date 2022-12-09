using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;

    private float horizontalInput;
    private float forwardInput;
    [SerializeField] float turnSpeed;
    [SerializeField] float speed;

    private Animator _playerAnim;

    private Rigidbody _playerRb;
    public float force;

    public float maxDist = 10f;
    public float minDist = 5f;

    void Start()
    {
        _playerAnim = GetComponent<Animator>();
        _playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //// walking and running
        //horizontalInput = Input.GetAxis("Horizontal");
        //forwardInput = Input.GetAxis("Vertical");

        //transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * speed);
        //transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * turnSpeed);

        //// walking
        //if (forwardInput != 0 || horizontalInput != 0)
        //{
        //    _playerAnim.SetBool("Walk", true);
        //}

        //else
        //{
        //    _playerAnim.SetBool("Walk", false);
        //}

        //// running
        //if (forwardInput != 0 && Input.GetKey(KeyCode.LeftShift))
        //{
        //    _playerAnim.SetBool("Run", true);
        //}

        //else
        //{
        //    _playerAnim.SetBool("Run", false);
        //}

        // following

        transform.LookAt(target);

        if (Vector3.Distance(transform.position, target.position) >= minDist)
        {
            transform.position += transform.forward * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, target.position) <= maxDist)
            {
                // Attack!
            }
        }

    }
}
