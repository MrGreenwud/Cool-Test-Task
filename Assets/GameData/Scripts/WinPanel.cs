using UnityEngine;

public class WinPanel : MonoBehaviour
{
    [SerializeField] private GameObject _panel;

    public void Show()
    {
        _panel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
