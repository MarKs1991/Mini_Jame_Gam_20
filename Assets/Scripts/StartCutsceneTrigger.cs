using cherrydev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCutsceneTrigger : MonoBehaviour
{
    public DialogBehaviour dialogBehaviour = null;
    public DialogNodeGraph dialogNodeGraph = null;

    // Start is called before the first frame update
    void Start()
    {
        dialogBehaviour.StartDialog(dialogNodeGraph);
    }

    public void changeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
