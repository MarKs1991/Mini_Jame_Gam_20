using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    private AudioSource audioSource = null;
    public List<AudioClip> clipList = new List<AudioClip>();
    public GameObject canvas = null;
    private enum StartUISounds { Hover, Select, None}

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void changeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    public void PlayHoverSound()
    {
        audioSource.clip = clipList[(int)StartUISounds.Hover];
        audioSource.Play();
    }

    public void PlayerSelectionSound()
    {
        audioSource.clip = clipList[(int)StartUISounds.Select];
        audioSource.Play();
    }

    public void GetToTitleScreen()
    {
        canvas.transform.GetChild(0).gameObject.SetActive(true);
        canvas.transform.GetChild(1).gameObject.SetActive(false);
        canvas.transform.GetChild(2).gameObject.SetActive(false);
    }

    public void GetToCreditsScene()
    {
        canvas.transform.GetChild(0).gameObject.SetActive(false);
        canvas.transform.GetChild(1).gameObject.SetActive(true);
        canvas.transform.GetChild(2).gameObject.SetActive(false);
    }

    public void GetToControlsScreen()
    {
        canvas.transform.GetChild(0).gameObject.SetActive(false);
        canvas.transform.GetChild(1).gameObject.SetActive(false);
        canvas.transform.GetChild(2).gameObject.SetActive(true);
    }
}
