using cherrydev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutsceneTrigger : MonoBehaviour
{
    public DialogBehaviour dialogBehaviour = null;
    public DialogNodeGraph dialogNodeGraph = null;

    // Start is called before the first frame update
    void Start()
    {
        dialogBehaviour.StartDialog(dialogNodeGraph);
    }
}
