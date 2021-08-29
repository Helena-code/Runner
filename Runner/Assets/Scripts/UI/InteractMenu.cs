using UnityEngine;
using UnityEngine.UI;

public class InteractMenu : MonoBehaviour
{
    public GameObject InteractWindow;
    public Button PayButton;
    public Button AttackButton;

    PlayerInteraction _playerInteractionScript;

    void Awake()
    {
        _playerInteractionScript = GetComponent<PlayerInteraction>();
        PayButton.onClick.AddListener(_playerInteractionScript.PayEnemy);
        AttackButton.onClick.AddListener(_playerInteractionScript.AttackEnemy);
    }

    public void ShowInteractMenu()
    {
        InteractWindow.SetActive(true);
    }

    public void HideInteractMenu()
    {
        InteractWindow.SetActive(false);
    }
}
