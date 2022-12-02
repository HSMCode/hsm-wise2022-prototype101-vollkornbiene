using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float forwardInput;
    public float speed;
    public float turnSpeed;
    public Vector3 force;

    private Animator _playerAnim;
    private Rigidbody _playerRb;

    public GameObject Ground;

    private bool isGrounded;
    private bool isJumping;


    // Start is called before the first frame update
    void Start()
    {
        _playerAnim = GetComponent<Animator>();
        _playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // forward motion
        transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * speed);

        // turning motion
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * turnSpeed);

        // transition float walking to running
        _playerAnim.SetFloat("Run", forwardInput);

        //transition float standing to standing straight???
        _playerAnim.SetFloat("Stand", forwardInput);

        // walking
        if(forwardInput != 0 || horizontalInput != 0)
        {
            _playerAnim.SetBool("Walk", true);
        }

        else
        {
            _playerAnim.SetBool("Walk", false);
        }


        // jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && isJumping == false)
        {
            _playerRb.AddForce(force, ForceMode.Impulse);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == Ground.name)
        {
            _playerAnim.SetBool("is Grounded", true);

            isGrounded = true;

            _playerAnim.SetBool("is Jumping", false);

            isJumping = false;

            print("Player on the Ground");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == Ground.name)
        {
            _playerAnim.SetBool("is Grounded", false);

            isGrounded = false;

            _playerAnim.SetBool("is Jumping", true);

            isJumping = true;

            print("Player not on the Ground");
        }
    }
}
