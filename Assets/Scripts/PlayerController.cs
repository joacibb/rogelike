using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float diagonalSpeedMultiplier = 0.7f;
    [SerializeField] private float checkDelay = 5f;
    [SerializeField] private float scale = 0.4f;
    
    
    private Rigidbody2D rb2d;
    private Animator animator;
    private Vector2 movement;
    
    private bool reposicionado;
    private bool isCheckingPosition = false;
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
        gameObject.SetActive(false);
        this.reposicionado = false;
        CheckPosition();
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

    private void CheckPosition()
    {
        if (!this.reposicionado)
        {
            Debug.Log("Entre al check");
            // Check if the player is on top of a collider
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);
            bool isOnCollider = false;
            foreach (Collider2D collider in colliders)
            {
                if (collider != GetComponent<Collider2D>())
                {
                    isOnCollider = true;
                    break;
                }
            }

            // If the player is not on a collider, activate the gameObject
            if (!isOnCollider)
            {
                Debug.Log("Lo activo");
                gameObject.SetActive(true);
                reposicionado = true;
            }
            else
            {
                // Otherwise, reposition the player and check again after a delay
                transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
                Invoke("CheckPosition", checkDelay);
            }

            isCheckingPosition = false;
        }
    }

    private void OnEnable()
    {
        if (!isCheckingPosition)
        {
            Debug.Log("Check position");
            isCheckingPosition = true;
            Invoke("CheckPosition", checkDelay);
        }
        else
        {
            Debug.Log("No Check");
            gameObject.SetActive(true);
        }
    }
}

