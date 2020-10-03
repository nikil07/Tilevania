using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    float xMovement, yMovement;
    [SerializeField] float movementSpeed = 2f;
    [SerializeField] float jumpSpeed = 5f;
    Rigidbody2D myRigidBody;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        run();
        flipSprite();
        jump();
    }

    private void jump() {
        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            myRigidBody.velocity += new Vector2(0, jumpSpeed);
        }
    }

    private void run() {
        xMovement = CrossPlatformInputManager.GetAxis("Horizontal");
        myRigidBody.velocity = new Vector2(xMovement * movementSpeed, myRigidBody.velocity.y);
        
    }

    private void flipSprite() {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            animator.SetBool("isRunning", true);
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody.velocity.x), transform.localScale.y);
        }
        else {
            animator.SetBool("isRunning", false);
        }
    }
}
