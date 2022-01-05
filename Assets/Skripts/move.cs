using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public Rigidbody2D Obj;
    public Vector2 moveVector;
    public float Speed = 2f;
    public Animator anim;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        Obj = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        CRadius = GroundCheck.GetComponent<CircleCollider2D>().radius;
        TopCheckRadius = TopCheck.GetComponent<CircleCollider2D>().radius;

    }

    // Update is called once per frame
    void Update()
    {
        walk();
        CGround(); 
        Jump();
        Flip();
        SquatCheck();
    }
    void walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        Obj.velocity = new Vector2(moveVector.x * Speed, Obj.velocity.y);
    }

    public float JForce = 210f;
    private bool JControl;
    private int JIteration = 0;
    public int JValueIteration = 60;
    void Jump()
    {
        if (Input.GetKey(KeyCode.W) && !jumpLock)
        {
            if (onGround) { JControl = true; }
        }
        else { JControl = false; }
        if (JControl)
        {
            if (JIteration++ < JValueIteration)
            {
                Obj.AddForce(Vector2.up * JForce / JIteration);
            }
        }
        else { JIteration = 0; }
    }
    public bool onGround;
    public LayerMask Ground;
    public Transform GroundCheck;
    public float CRadius = 0.5f;
    void CGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, CRadius, Ground);
        anim.SetBool("onGround", onGround);
    }

    void Flip()
    {
        sr.flipX = moveVector.x < 0;
    }

    public bool onRoof;
    public Transform TopCheck;
    private float TopCheckRadius;
    public LayerMask Roof;
    public Collider2D poseStand;
    public Collider2D poseSquat;
    private bool jumpLock = false;
    

    void SquatCheck()
    {
        onRoof = Physics2D.OverlapCircle(TopCheck.position, TopCheckRadius, Roof);
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("Crouch", true);
            poseStand.enabled = false;
            poseSquat.enabled = true;
            jumpLock = true;
        }
        else if (!Physics2D.OverlapCircle(TopCheck.position, TopCheckRadius, Roof))
        {
            anim.SetBool("Crouch", false);
            poseStand.enabled = true;
            poseSquat.enabled = false;
            jumpLock = false;
        }
    }
    
}
