using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    private Rigidbody _enemyRb;
    private GameObject _player;

    private GameObject _enemy;

    [SerializeField] float speed;

    // for Update Score Timer
    public int score = 1;

    private UpdateScoreTimer updateScore;

    void Start()
    {
        _enemyRb = GetComponent<Rigidbody>();

        _enemy = GameObject.FindWithTag("Enemy");

        // make sure to set the tag "Player" on your player character for this to work
        _player = GameObject.FindWithTag("Player");

        updateScore = GameObject.Find("UpdateScore").GetComponent<UpdateScoreTimer>();
    }

    void FixedUpdate()
    {
        // move the enemy to the vector position of the player
        _enemyRb.AddForce((_player.transform.position - transform.position).normalized * speed);
        // Debug.Log("Player: " + _player.transform.position + "Enemy: " + transform.position);
    }


    // For debugging we can add gizmos to help visualise depth and distance a bit better
    void OnDrawGizmosSelected()
    {
        if (_player != null)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, _player.transform.position);
        }
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);

            updateScore.UpdateScore(score);
        }
    }
}