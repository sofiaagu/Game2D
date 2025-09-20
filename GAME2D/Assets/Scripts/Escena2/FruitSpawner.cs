using UnityEngine;
using System.Collections.Generic;

public class FruitSpawner : MonoBehaviour
{
    public GameObject manzanaPrefab;
    public GameObject bananaPrefab;

    public int maxManzanas = 5;
    public int maxBananas = 7;


    public List<GameObject> puntosDisponibles = new List<GameObject>();

    void Start()
    {

        // Generar manzanas
        int cantidadManzanas = Random.Range(1, maxManzanas + 1);
        for (int i = 0; i < cantidadManzanas; i++)
        {
            GenerarFruta(manzanaPrefab);
        }

        // Generar bananas
        int cantidadBananas = Random.Range(1, maxBananas + 1);
        for (int i = 0; i < cantidadBananas; i++)
        {
            GenerarFruta(bananaPrefab);
        }
    }

    void GenerarFruta(GameObject frutaPrefab)
    {
        if (puntosDisponibles.Count == 0) return;

        int index = Random.Range(0, puntosDisponibles.Count);
        GameObject punto = puntosDisponibles[index];

        Instantiate(frutaPrefab, punto.transform.position, Quaternion.identity);

        puntosDisponibles.RemoveAt(index);
    }
}
