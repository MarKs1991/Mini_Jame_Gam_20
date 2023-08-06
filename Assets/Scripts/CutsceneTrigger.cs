using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    private bool hasEntered = false;
    public UIMAnager.DialogTitle triggerDialog = new UIMAnager.DialogTitle();
    private UIMAnager uiManager = null;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("CharacterDisplayCanvas").GetComponent<UIMAnager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasEntered == false)
        {
            hasEntered = true;
            uiManager.ActivateDialog(triggerDialog);
        }
    }
}
