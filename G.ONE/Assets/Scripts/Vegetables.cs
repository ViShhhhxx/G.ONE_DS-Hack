using UnityEngine;

public class Vegetables : MonoBehaviour
{
    public int scoreValue = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();

            if (gameManager != null)
            {
                gameManager.CollectVegetable(scoreValue);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("GameManager not found in the scene.");
            }
        }
    }
}
