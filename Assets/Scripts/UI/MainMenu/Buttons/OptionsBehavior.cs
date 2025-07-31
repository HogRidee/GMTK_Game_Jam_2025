using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OptionsBehavior : MonoBehaviour
{
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private Button returnButton;
    
    private void Awake()
    {
        optionsMenu.SetActive(false);
    }

    public void OpenOptions()
    {
        optionsMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(returnButton.gameObject);
    }

    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }
}
