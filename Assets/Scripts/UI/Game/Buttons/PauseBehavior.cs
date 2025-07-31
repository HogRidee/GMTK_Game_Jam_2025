using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseBehavior : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject firstSelectedButton;
    [SerializeField] private Button pauseButton;
    
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        EventSystem.current.SetSelectedGameObject(firstSelectedButton);
        pauseButton.gameObject.SetActive(false);
    }
}
