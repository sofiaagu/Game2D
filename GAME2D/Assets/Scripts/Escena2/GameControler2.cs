using UnityEngine;

public class GameController2 : MonoBehaviour
{
    [Header("Referencia al Timer de la escena")]
    public Timer tiempoEscena;  // arrastrar el objeto Timer desde el Inspector

    // Si necesitas inicializar cosas al inicio
    void Start()
    {
        if (tiempoEscena == null)
        {
            Debug.LogWarning("⏱️ No se asignó el Timer en GameController2.");
        }
    }

    void Update()
    {
        // Aquí podrías manejar lógica adicional de la escena si lo requieres
    }

    /// <summary>
    /// Detiene el tiempo de la escena, lo suma al global
    /// y activa el Panel de Game Over.
    /// </summary>
    public void addTime()
    {
        if (tiempoEscena != null)
        {
            // Detener el temporizador de la escena
            tiempoEscena.TimerStop();
            float getTimeScene = tiempoEscena.StopTime;

            // Sumar el tiempo al global
            GameManager.Instance.TotalTime(getTimeScene);

            Debug.Log("Tiempo Escena 2 agregado: " + getTimeScene);
            Debug.Log("Tiempo Global acumulado: " + GameManager.Instance.GlobalTime);
        }
        else
        {
            Debug.LogWarning("No hay referencia a Timer en GameController2.");
        }

    }
}
