using UnityEngine;

public class PauseLogic : MonoBehaviour
{
    public GameObject pausaMenuUI;
    private bool estaPausado = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (estaPausado)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }
        }
    }

    void Pausar()
    {
        estaPausado = true;
        pausaMenuUI.SetActive(true);
        Time.timeScale = 0f; // pausa el tiempo en el juego
    }

    void Continuar()
    {
        estaPausado = false;
        pausaMenuUI.SetActive(false);
        Time.timeScale = 1f; // reanuda el tiempo en el juego
    }
}