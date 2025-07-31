using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReturnBehavior : MonoBehaviour
{
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private Button startButton;
    
    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(startButton.gameObject);
    }
}
