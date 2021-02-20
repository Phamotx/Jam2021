using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementScript : MonoBehaviour
{
    [SerializeField]
    private GameObject smokeEffect;
    [SerializeField]
    private Transform smokePos;
    [SerializeField]
    private float _moveSpeed = 5f;
    [SerializeField]
    private float _gravity = 9.81f;
    [SerializeField]
    private float _jumpSpeed = 3.5f;
    [SerializeField]
    private float _doubleJumpMultiplier = 0.5f;

    [SerializeField]
    private Animator anime;

    private CharacterController _controller;

    private float _directionY;

    private bool _canDoubleJump = false;
    private bool _wallJump = false;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");

        if (_controller.isGrounded)
        {
            direction = new Vector3(0, 0, horizontalInput);
            if (direction.z != 0)
            {
                transform.right = Vector3.Slerp(transform.right, Vector3.right * direction.z, 10f);
                anime.SetBool("Run", true);
            }
            else
            {
                anime.SetBool("Run", false);
            }

            _canDoubleJump = true;

            if (Input.GetButtonDown("Jump"))
            {

                Smoke(smokePos.position);
                _directionY = _jumpSpeed;
                _directionY -= _gravity * Time.deltaTime;
            }
            else
            {
                anime.SetBool("Jump", false);
            }
        }
        else
        {
            anime.SetBool("Jump", true);
            if (Input.GetButtonDown("Jump") && _canDoubleJump && !_wallJump)
            {
                Smoke(smokePos.position);
                _directionY = _jumpSpeed * _doubleJumpMultiplier;
                _canDoubleJump = false;
            }
            _directionY -= _gravity * Time.deltaTime;
        }

        direction.y = _directionY;

        _controller.Move(direction * _moveSpeed * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!_controller.isGrounded && hit.normal.y < 0.1f && hit.collider.tag == "Wall")
        {
            _wallJump = true;
            if (Input.GetButtonDown("Jump") && _wallJump)
            {
                _wallJump = false;
                Smoke(hit.point);
                // anime.SetBool("Jump", true);
                _directionY = _jumpSpeed;                
                direction = hit.normal;
                transform.right = Vector3.Slerp(transform.right, Vector3.right * direction.z, 10f);

            }
        }
    }

    void Smoke(Vector3 pos)
    {
        Instantiate(smokeEffect, pos, Quaternion.identity);
    }

}
