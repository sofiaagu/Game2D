using UnityEngine;

public class CollectItem : MonoBehaviour
{
    [Header("Opciones de Item")]
    public string nameItem;   // Nombre del ítem (ej: Manzana, Banana)
    public int itemValue = 1; // Valor en puntos

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("El jugador recogió: " + nameItem + " (+" + itemValue + ")");

            if (nameItem == "Apple")
            {
                GameManager.Instance.TotalApple(itemValue);
            }
            else if (nameItem == "Banana")
            {
                GameManager.Instance.TotalBanana(itemValue);
            }

            Destroy(gameObject);
        }
    }
}
