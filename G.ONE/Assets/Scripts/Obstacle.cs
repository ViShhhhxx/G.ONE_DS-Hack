using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GenerateLevel generateLevel;

    void Start()
    {
        // Find the GenerateLevel script in the scene
        generateLevel = FindObjectOfType<GenerateLevel>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player triggered an obstacle, trigger game over
            generateLevel.GameOver();
            Destroy(other.gameObject); // Destroy the player
        }
    }
}
