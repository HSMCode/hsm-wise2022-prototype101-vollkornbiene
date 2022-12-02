using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float forwardInput;
    public float speed;
    public float turnSpeed;

    private Animator _playerAnim;

    private Rigidbody _playerRb;
    public float force;
    public float gravityModifier;

    public float forceDown;

    public GameObject Ground;

    public bool isGrounded;
    public bool isJumping;
    public bool isFalling;


    // Start is called before the first frame update
    void Start()
    {
        _playerAnim = GetComponent<Animator>();
        _playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
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
        _playerAnim.SetFloat("Run Float", forwardInput);

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

        // running
        if(forwardInput != 0 && Input.GetKey(KeyCode.LeftShift))
        {
            _playerAnim.SetBool("Run", true);
            //forwardInput * 2;
        }

        else
        {
            _playerAnim.SetBool("Run", false);
        }


        // press space to jump - player is jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true && isJumping == false)
        {
            isGrounded = false;
            isJumping = true;

            if (isJumping)
            {
                _playerAnim.SetTrigger("Jump");
            }
        }

        // release space to start falling - player is falling
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
            isFalling = true;

            if (isFalling)
            {
                _playerAnim.SetBool("Fall", true);
            }
        }

    }

    void FixedUpdate()
    {
        if (isJumping)
        {
            _playerRb.AddForce(Vector3.down * force, ForceMode.Force);
        }

        if (isFalling || isGrounded)
        {
            _playerRb.AddForce(Vector3.down * forceDown * _playerRb.mass);
        }
    }
    // hier funktioniert etwas nicht. Nach Landung bleibt isFalling true und isGrounded false
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            print("Player on the Ground");

            isGrounded = true;

            if (isFalling)
            {
                _playerAnim.SetBool("Fall", false);
                isFalling = false;
            }

            
        }
    }
}
