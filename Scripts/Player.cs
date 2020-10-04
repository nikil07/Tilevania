using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    
    [SerializeField] float movementSpeed = 2f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    Rigidbody2D myRigidBody;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D feetCollider;
    float gravityScaleAtStart;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        feetCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        gravityScaleAtStart = myRigidBody.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        run();
        flipSprite();
        jump();
        climb();
    }

    private void climb() {

        if (feetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myRigidBody.gravityScale = 0;
            float yMovement = CrossPlatformInputManager.GetAxis("Vertical");
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, yMovement * climbSpeed);

            bool playerHasVerticalSpeed = Mathf.Abs(myRigidBody.velocity.y) > Mathf.Epsilon;
            if (playerHasVerticalSpeed)
            {
                animator.SetBool("isClimbing", true);
            }
            else
            {
                animator.SetBool("isClimbing", false);
            }
        }
        else {
            myRigidBody.gravityScale = gravityScaleAtStart;
            animator.SetBool("isClimbing", false);
        }
    }

    private void jump() {
        if (feetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                myRigidBody.velocity += new Vector2(0, jumpSpeed);
            }
        }
    }

    private void run() {
        float xMovement = CrossPlatformInputManager.GetAxis("Horizontal");
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
