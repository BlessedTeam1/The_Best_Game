using UnityEngine;

public class CoinPickup : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Добавить монету игроку
            Debug.Log("Монета подобрана!");

            Destroy(gameObject); // Удаляем монетку
            Expirience.EXP++;
        }
        
    }
}
