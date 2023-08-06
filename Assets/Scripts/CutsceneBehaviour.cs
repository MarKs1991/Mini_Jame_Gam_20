using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneBehaviour : MonoBehaviour
{
    private UIMAnager uiManager = null;
    public bool isInteractable = true;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("CharacterDisplayCanvas").GetComponent<UIMAnager>();
        uiManager.AddListener(this);
    }

    public void SetInteractivity(bool set)
    {
        isInteractable = set;
    }

    public bool GetInteractableState()
    {
        return isInteractable;
    }

    public void RemoveListener()
    {
        uiManager.RemoveListener(this);
    }
}
