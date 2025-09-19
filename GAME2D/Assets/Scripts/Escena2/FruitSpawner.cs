using UnityEngine;
using UnityEngine.Tilemaps;

public class FruitSpawner : MonoBehaviour
{
    public GameObject manzanaPrefab;
    public GameObject bananaPrefab;
    
    public int maxManzanas = 5;
    public int maxBananas = 7;
    
    public Tilemap tilemap; // Arrastra tu Tilemap aquí en el Inspector
    
    public float offsetX = 0f; // Ajuste horizontal
    public float offsetY = 0.5f; // Ajuste vertical

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
        // Obtener los límites del tilemap
        BoundsInt bounds = tilemap.cellBounds;
        
        // Buscar una posición aleatoria que tenga tile
        Vector3Int celda;
        int intentos = 0;
        
        do
        {
            celda = new Vector3Int(
                Random.Range(bounds.xMin, bounds.xMax),
                Random.Range(bounds.yMin, bounds.yMax),
                0
            );
            
            intentos++;
            
            // Prevenir bucle infinito por si no hay tiles
            if (intentos > 100) 
            {
                Debug.LogError("No se encontró un tile válido después de 100 intentos");
                return;
            }
        }
        while (!tilemap.HasTile(celda)); // Repetir hasta encontrar un tile
        
        // Obtener la posición central de la celda y aplicar offsets
        Vector3 posicion = tilemap.GetCellCenterWorld(celda);
        posicion.x += offsetX; // Ajuste en X
        posicion.y += offsetY; // Ajuste en Y
        
        // Crear la fruta
        Instantiate(frutaPrefab, posicion, Quaternion.identity);
    }
}