using UnityEngine;

public class StartBehavior : MonoBehaviour
{
    public void StartGame()
    {
        // Load the game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("MovementTest");
    }
}
