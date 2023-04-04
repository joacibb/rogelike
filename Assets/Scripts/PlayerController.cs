using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float diagonalSpeedMultiplier = 0.7f;
    [SerializeField] private float scale = 0.4f;

    private Rigidbody2D rb2d;
    private Animator animator;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        // Make player invisible
       // gameObject.SetActive(false);
    }
    
    private void Update()
    {
        
        // Obtener la referencia del componente Sprite Renderer

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = new Vector2(movement.x,movement.y).normalized;
        
        // Set animator parameters
        if (movement.x < 0)
        {
            // Cambiar el valor de la propiedad flipX a true para voltear el sprite
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("speed", movement.magnitude);

    }

    private void FixedUpdate()
    {
       rb2d.MovePosition(rb2d.position + movement * (speed * Time.fixedDeltaTime));
    }

}

