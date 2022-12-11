using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _endGameMenu;
    [SerializeField] private GameObject _winText;
    [SerializeField] private GameObject _loseText;
    [SerializeField] private GameObject _joystick;

    public void WinMenu()
    {
        _endGameMenu.SetActive(true);

        _winText.SetActive(true);

        _joystick.SetActive(false);
    }

    public void LoseMenu()
    {
        _endGameMenu.SetActive(true);

        _loseText.SetActive(true);

        _joystick.SetActive(false);
    }
}
