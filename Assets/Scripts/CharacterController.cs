using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody2D r2d;
    private Animator _animator;
    private Vector3 CharPos;
    private SpriteRenderer _spriterenderer;
    [SerializeField] private GameObject _camera;
    private int say�;

    private void Start()
    {
        _spriterenderer = GetComponent<SpriteRenderer>(); //caching _spriterenderer
        r2d= GetComponent<Rigidbody2D>(); //caching r2d
        _animator = GetComponent<Animator>(); //caching _animator
        CharPos = transform.position;
        say� = 1;
    }

    private void FixedUpdate()
    {
        Debug.Log("Fixed" + say�);        
        //r2d.velocity = new Vector2(speed, 0.0f);
        say� = 2;
    }

    private void Update()
    {
        CharPos = new Vector3(CharPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), CharPos.y);
        transform.position = CharPos; //Hesaplad���m pozisyon karakterime i�lensin
        if (Input.GetAxis("Horizontal") == 0.0f) 
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", speed);
        }

        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            _spriterenderer.flipX = false;
        } else if (Input.GetAxis("Horizontal") < -0.01f)
        {
            _spriterenderer.flipX = true;
        }
        say� = 3;
    }

    private void LateUpdate()
    {
        _camera.transform.position = new Vector3(CharPos.x,CharPos.y, CharPos.z - 1.0f);
        say� = 4;
    }


}
