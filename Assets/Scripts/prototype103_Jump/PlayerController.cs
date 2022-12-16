using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float forwardInput;
    [SerializeField] float turnSpeed;
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;

    private Animator _playerAnim;

    private Rigidbody _playerRb;
    public float force;
    // public float forceDown;
    public float gravityModifier = 1f;

    public bool isGrounded;
    public bool isJumping;
    public bool isFalling;
    public bool isLanding;

    public bool jumpCancelled;
    public float jumpTimer;
    public float jumpButtonPressedTime = 1f;



    // Start is called before the first frame update
    void Start()
    {
        _playerAnim = GetComponent<Animator>();
        _playerRb = GetComponent<Rigidbody>();

        // Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // thriller
        if (Input.GetKeyDown("t"))
        {
            _playerAnim.SetTrigger("Thriller");
        }

        // walking and running
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * walkSpeed);
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * turnSpeed);

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
            transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * runSpeed);
        }

        else
        {
            _playerAnim.SetBool("Run", false);
        }


        // press space to jump - player is jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isJumping)
        {
            isGrounded = false;
            isJumping = true;

            if (isJumping)
            {
                _playerAnim.SetTrigger("Jump");
            }
        }

        // release space to start falling - player is falling
        if (isJumping)
        {
            jumpTimer += Time.deltaTime;

            if (Input.GetKeyUp(KeyCode.Space))
            {
                isJumping = false;
                isFalling = true;

                if (isFalling)
                {
                    _playerAnim.SetBool("Fall", true);
                }
            }

            if (jumpTimer > jumpButtonPressedTime)
            {
                isJumping = false;
                jumpCancelled = true;
            }
        }

        if(_playerRb.velocity.y < 0 && isFalling)
        {
            isFalling = false;
            isLanding = true;
            _playerAnim.SetBool("Fall", false);
        }
    }


    void FixedUpdate()
    {
        if (isJumping)
        {
            gravityModifier = 1f;
            _playerRb.AddForce(Vector3.up * force, ForceMode.Force);
        }

        if (isFalling || isGrounded || isLanding || jumpCancelled)
        {
            gravityModifier = 25f;
            // _playerRb.AddForce(Vector3.down * forceDown * _playerRb.mass);
        }

        _playerRb.AddForce(Physics.gravity * (gravityModifier - 1) * _playerRb.mass);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            print("Player Collision");

            isGrounded = true;
            jumpTimer = 0f;
            jumpCancelled = false;

            if (isLanding)
            {
                _playerAnim.SetBool("Land", false);
                isLanding = false;
            }
        }
    }
}
