    using UnityEngine;

    public class GameController1 : MonoBehaviour
    {
        public Timer tiempoEscena;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    
        public void addTime()
        {
            tiempoEscena.TimerStop();
            float getTimeScene= tiempoEscena.StopTime;

            GameManager.Instance.TotalTime(getTimeScene);

            Debug.Log("Tiempo Escena 1 " + GameManager.Instance.GlobalTime);
        }
    }
