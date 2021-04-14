using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class plAnimation : MonoBehaviour
{
    private Animator myAnimator;
    private Rigidbody2D myRigidbody;
    private string currentState;

    [Header ("set max speed player")]
    public float maxSpeed;


    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();       
    }

    // Update is called once per frame
    void Update()
    {

        // player speed check horizontal 

        myAnimator.SetFloat("pl_Velocity_x", Mathf.Abs( myRigidbody.velocity.x / maxSpeed) );


        // player check speed vertical

        if (myRigidbody.velocity.y > 0.1)
        { // start jumping
            ChangeAnimationState("pl_JumpUp");
        }


        if (myRigidbody.velocity.y < -0.1)
        { // start jump down
            ChangeAnimationState("pl_JumpDown");
        }

        if (myRigidbody.velocity.y ==0)
        {
            ChangeAnimationState("pl_Idle");
        }
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        // play newState
        myAnimator.Play(newState);

        // reassing state

        currentState = newState;
    }

}
