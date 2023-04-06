using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2 : MonoBehaviour
{
    public float jumpforce = 150.0f;
    public float speed = 1.0f;
    public float movedirection;

    private bool jump;
    private bool grounded = true;
    private bool moving;
    private Rigidbody2D _rigidbody2d;
    private SpriteRenderer _spriterenderer;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>(); //caching anim
    }

    private void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _spriterenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (_rigidbody2d.velocity != Vector2.zero)
        {
            moving= true;
        }
        else
        {
            moving= false;
        }

        _rigidbody2d.velocity = new Vector2 (speed * movedirection, _rigidbody2d.velocity.y);
        if (jump == true)
        {
            _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, jumpforce);
            jump= false;
        }
    }

    private void Update()
    {
        if (grounded == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                movedirection = -1.0f;
                _spriterenderer.flipX= true;
                anim.SetFloat("speed", speed);
            }else if (Input.GetKey(KeyCode.D))
            {
                movedirection= 1.0f;
                _spriterenderer.flipX = false;
                anim.SetFloat("speed", speed);
            }
        }else if (grounded == true)
        {
            movedirection = 0.0f;
            anim.SetFloat("speed", 0.0f);
        }

        if (grounded == true && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded= false;
            anim.SetTrigger("jump");
            anim.SetBool("grounded", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            anim.SetBool("grounded", true);
            grounded = true;
        }
        
    }
}
