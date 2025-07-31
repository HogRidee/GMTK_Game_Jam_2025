using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReturnBehavior : MonoBehaviour
{
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private Button startButton;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Button pauseButton;
    
    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(startButton.gameObject);
    }

    public void ClosePause()
    {
        pauseMenu.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        Time.timeScale = 1f;
    }
}
