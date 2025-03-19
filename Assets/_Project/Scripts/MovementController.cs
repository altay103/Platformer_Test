using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MovementController : MonoBehaviour
{
    CharacterController characterController;
    Animator animator;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private int maxJumpCount = 2;
    private Vector3 velocity;
    private Vector3 move;
    private bool isGrounded;
    private int remainingJumps;


    enum State
    {
        Idle,
        Running,
        Falling,
    }
    void OnEnable()
    {
        velocity = Vector3.zero;
    }
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        remainingJumps = maxJumpCount;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        if (characterController.isGrounded)
        {
            velocity.y = 0f;
            remainingJumps = maxJumpCount;
            if (Mathf.Abs(x) < 0.1f)
            {
                animator.SetInteger("State", (int)State.Idle);
            }
            else
            {
                animator.SetInteger("State", (int)State.Running);
            }

            Debug.Log("Grounded");
        }
        else
        {
            Debug.Log("Not Grounded");

            if (!Physics.Raycast(transform.position, Vector3.down, 0.5f))
            {
                animator.SetInteger("State", (int)State.Falling);
            }
        }
        if (x >= 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (x < 0)
        {
            transform.localScale = new Vector3(1, 1, -1);
        }
        if ((Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
               && remainingJumps > 0)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            remainingJumps--;
            animator.SetTrigger("Jump");
        }


        move = transform.forward * moveSpeed * x;


        velocity.y += gravity * Time.deltaTime;
        move.y = velocity.y;


        characterController.Move(move * Time.deltaTime);
    }
}
