using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject personaje;

    private void LateUpdate()
    {
        // Obtener la posición actual de la cámara
        Vector3 posicionActual = transform.position;

        // Obtener la posición actual del personaje
        Vector3 posicionPersonaje = personaje.transform.position;

        // Calcular la nueva posición de la cámara
        Vector3 nuevaPosicion = new Vector3(posicionPersonaje.x, posicionPersonaje.y, posicionActual.z);

        // Asignar la nueva posición a la cámara
        transform.position = nuevaPosicion;
    }
}