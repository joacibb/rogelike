using Photon.Pun;
using UnityEngine;

public class CameraFollow : MonoBehaviourPunCallbacks
{
    private void LateUpdate()
    {
        // Encontrar el objeto del jugador local por etiqueta
        GameObject player = GameObject.FindWithTag("Player");

        // Verificar que el jugador local no sea nulo
        if (player == null) return;

        // Obtener la posición actual de la cámara
        Vector3 posicionActual = transform.position;

        // Obtener la posición actual del objeto del jugador local
        Vector3 posicionObjetoJugador = player.transform.position;

        // Calcular la nueva posición de la cámara
        Vector3 nuevaPosicion = new Vector3(posicionObjetoJugador.x, posicionObjetoJugador.y, posicionActual.z);

        // Asignar la nueva posición a la cámara
        transform.position = nuevaPosicion;
    }
}