using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public Transform target;

    [SerializeField] float speed;

    private Animator _playerAnim;

    private Rigidbody _playerRb;

    public float maxDist = 8f;
    public float minDist = 5f;

    void Start()
    {
        _playerAnim = GetComponent<Animator>();
        _playerRb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        // following

        //float dist = Vector3.Distance(target.position, transform.position);

        //check if it is within the range
        //if (dist <= minDist)
        //{
        //    transform.LookAt(target);
        //    transform.position = target.transform.position;
        //}

        transform.position = target.transform.position;
    }
}
