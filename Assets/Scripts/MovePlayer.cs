using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [Header("Movement Variabels")]
    public float movementSpeed;
    public float maxSpeed;
    [Header("Jumping Variabels")]
    public float jumpForce;
    public LayerMask layerMask;
    [SerializeField]
    private bool isGrounded;
    [SerializeField]
    private bool isJumping;
    [SerializeField]
    private bool canDoubleJump;

    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Horizontal Movement
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        rb2d.AddForce(new Vector2(horizontalAxis * movementSpeed, 0));

        //Velocity Clamping
        if (rb2d.velocity.x > maxSpeed)
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        if (rb2d.velocity.x < -maxSpeed)
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);

        //Debugging purposes
        Debug.DrawLine(transform.position, transform.position + Vector3.down*0.6f);
        
        //Grounded Check
        RaycastHit2D hit = Physics2D.Linecast(transform.position, transform.position + Vector3.down*0.6f, layerMask);
        if(hit)
        {
            if (rb2d.velocity.y < 0)
            {
                isGrounded = true;
                isJumping = false;
                canDoubleJump = true;
            }
            //Debug.Log(hit.collider.name);
        }
        else
        {
            isGrounded = false;
        }    
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            //Jump
            if (!isJumping)
            {
                rb2d.AddForce(new Vector2(0, jumpForce));
                isJumping = true;
            }
            //Double Jump
            else if (isJumping && canDoubleJump)
            {
                rb2d.AddForce(new Vector2(0, jumpForce));
                canDoubleJump = false;
            }
        }
    }
}
