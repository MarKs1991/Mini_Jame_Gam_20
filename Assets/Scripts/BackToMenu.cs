using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    public GameObject BackToMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMenuUI.SetActive(!BackToMenuUI.activeSelf);
        }
    }
    public void GoBackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
