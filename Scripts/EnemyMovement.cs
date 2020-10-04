using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;
    Rigidbody2D myRigidbody;
    BoxCollider2D myBoxCollider;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myBoxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal();
    }

    private void moveHorizontal() {
        if(isFacingRight())
            myRigidbody.velocity = new Vector2(moveSpeed, 0);
        else
            myRigidbody.velocity = new Vector2(-moveSpeed, 0);
    }

    private bool isFacingRight() {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-Mathf.Sign(myRigidbody.velocity.x), transform.localScale.y);
    }

}
