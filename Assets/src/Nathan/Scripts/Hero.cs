/*
 * Filename: Hero.cs
 * Developer: Nathan
 * Purpose: Defines the Hero class including the hero's behaviors.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public float jumpForce;
    public float movementSpeed;

    private Rigidbody2D rb;
    //private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField]
    private float stepJump;
    [SerializeField]
    private float stepTimer;
    [SerializeField]
    private float jumpTimer;
    [SerializeField]
    private float limHighY;
    [SerializeField]
    private float limLowY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        gameObject.tag = "Hero";
    }

    // Update is called once per frame
    void Update()
    {
        //nothing
    }

    //FixedUpdate should be used for physics based calls, since it is independent of framerate and scaled by time effects.
    void FixedUpdate() 
    {
        if((Time.fixedTime%jumpTimer==0) && (Time.fixedTime!=0)){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y+jumpForce);
        }
        if((Time.fixedTime%stepTimer==0) && (Time.fixedTime!=0)){
            rb.velocity = new Vector2(movementSpeed, rb.velocity.y+stepJump);
        }
        if((rb.position.y < limLowY) || (rb.position.y > limHighY)){
            rb.simulated = false;
            Debug.Log("(NN) Hero frozen, out of bounds");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("(NN) Collision with enemy");
            //other.GetComponent<Enemy>().hitenemy; -- tell enemy i hit him.
        }
        /*if(other.tag == "Item")
        {
            Debug.Log("Collision with item");
            other.GetComponent<Item>(); --need to find a way to tell Logan I hit him.
        }
         */
    }

    public Vector2 getPosition(){
        return rb.position;
    }
}