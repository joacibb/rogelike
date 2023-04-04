using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerPositionChecker : MonoBehaviour
{
    [SerializeField] private float checkDelay = 1.5f;
    [SerializeField] private Vector2 checkAreaSize = new Vector2(1f, 1f);
    
    [SerializeField] private Transform parentTransform;
    private bool isCheckingPosition = false;
    private bool reposicionado;

    private void Awake()
    {
        Debug.Log("Awake");
        this.reposicionado = false;
    }

    private void Start()
    {
        // Obtén la referencia al transform del objeto padre
        parentTransform = transform.parent;
        CheckPosition();
    }

    private void CheckPosition()
    {
        if (!reposicionado)
        {
            Debug.Log("Entre al check");
            // Check if the player is on top of a collider
            Collider2D[] colliders = Physics2D.OverlapCircleAll(parentTransform.position, 0.2f);
            bool isOnCollider = false;
            foreach (Collider2D collider in colliders)
            {
                Debug.Log("Parent transform es "+parentTransform+" y el componente collider es "+parentTransform.GetComponent<Collider2D>()+" y collider es "+collider);


                if (collider != parentTransform.GetComponent<Collider2D>())
                {
                    isOnCollider = true;
                    break;
                }
            }

            // If the player is not on a collider, activate the gameObject
            if (!isOnCollider)
            {
                Debug.Log("Lo activo");
                parentTransform.gameObject.SetActive(true);
                reposicionado = true;
            }
            else
            {
                // Otherwise, reposition the player and check again after a delay
                parentTransform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
                Invoke("CheckPosition", checkDelay);
            }

            isCheckingPosition = false;
        }
    }


}