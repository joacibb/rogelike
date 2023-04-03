using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float diagonalSpeedMultiplier = 0.7f;
    [SerializeField] private float checkDelay = 5f;

    private Rigidbody2D rb2d;
    private Animator animator;
    private bool reposicionado;

    private Vector2 movement;
    private bool isCheckingPosition = false;

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
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Limit diagonal movement speed
        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        // Set animator parameters
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);

        // Flip sprite based on horizontal movement direction
        if (movement.x > 0f)
        {
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        }
        else if (movement.x < 0f)
        {
            transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
        }
    }

    private void FixedUpdate()
    {
        if (movement != Vector2.zero)
        {
            // Calculate movement speed based on diagonal or straight movement
            float currentSpeed = speed;
            if (movement.x != 0f && movement.y != 0f)
            {
                currentSpeed *= diagonalSpeedMultiplier;
            }

            // Move the rigidbody
            rb2d.MovePosition(rb2d.position + this.movement.normalized * (currentSpeed * Time.fixedDeltaTime));
        }
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

