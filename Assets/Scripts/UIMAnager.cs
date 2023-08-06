using cherrydev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMAnager : MonoBehaviour
{
    public int MaxPlayerHealth = 3;
    public int PlayerHealthCount = 3;

    public int MaxOrganPipeCount = 5;
    public int OrganPipeCount = 0;

    private AudioSource uiAudioSource = null;
    public List<AudioClip> audioClipList = new List<AudioClip>();
    private enum UISounds { HealthGain, PipeGain, None}

    private DialogBehaviour dialogBehaviour = null;
    public List<DialogNodeGraph> dialogNodeGraphs = new List<DialogNodeGraph>();
    public enum DialogTitle {Dialog1, Dialog2, Dialog3, Dialog4, Dialog5, Dialog6, Dialog8, Dialog9, Dialog10 }

    public List<CutsceneBehaviour> cutsceneBehaviourList = new List<CutsceneBehaviour>();

    // Start is called before the first frame update
    void Start()
    {
        uiAudioSource = GetComponent<AudioSource>();
        dialogBehaviour = GameObject.Find("Dialog Prefab").GetComponent<DialogBehaviour>();

        AdjustHealthAndPipeDisplay(0, true);
        AdjustHealthAndPipeDisplay(0, false);
    }

    public void AdjustHealthAndPipeDisplay(int adjustValue, bool isHealthChange)
    {
        Debug.Log("UI Display will be adjusted");
        if (isHealthChange)
        {
            //Change health state
            PlayerHealthCount += adjustValue;

            //Adjust to both minimum and maximum health, if needed
            if (PlayerHealthCount > MaxPlayerHealth)
            {
                PlayerHealthCount = MaxPlayerHealth;
            }

            if (PlayerHealthCount < 0)
            {
                PlayerHealthCount = 0;
            }

            //Change the display
            for (int i = 0; i < MaxPlayerHealth; i++)
            {
                if (i < PlayerHealthCount)
                {
                    this.transform.GetChild(0).GetChild(i).GetChild(0).gameObject.SetActive(true);
                }
                else
                {
                    this.transform.GetChild(1).GetChild(i).GetChild(0).gameObject.SetActive(false);
                }
            }
        }
        else
        {
            //Change ammo state
            OrganPipeCount += adjustValue;

            //Adjust to both minimum and maximum ammo count, if needed
            if (OrganPipeCount > MaxOrganPipeCount)
            {
                OrganPipeCount = MaxOrganPipeCount;
            }

            if (OrganPipeCount < 0)
            {
                OrganPipeCount = 0;
            }

            //Change the display
            for (int i = 0; i < MaxOrganPipeCount; i++)
            {
                if (i < OrganPipeCount)
                {
                    this.transform.GetChild(1).GetChild(i).GetChild(0).gameObject.SetActive(true);
                }
                else
                {
                    this.transform.GetChild(1).GetChild(i).GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }

    public int GetAmmoCount()
    {
        return OrganPipeCount;
    }

    public void TriggerHealthGainSound()
    {
        uiAudioSource.clip = audioClipList[(int)UISounds.HealthGain];
        uiAudioSource.Play();
    }

    public void TriggerPipeGainSound()
    {
        uiAudioSource.clip = audioClipList[(int)UISounds.PipeGain];
        uiAudioSource.Play();
    }

    public void ActivateDialog(DialogTitle title)
    {
        Debug.Log("Dialog is starting. Stop moving!");
        //Tell all the other objects, that they are not allowed to do anything
        for (int i = 0; i < cutsceneBehaviourList.Count; i++)
        {
            cutsceneBehaviourList[i].SetInteractivity(false);
        }

        dialogBehaviour.StartDialog(dialogNodeGraphs[(int)title]);
    }

    public void StopShowingDialog()
    {
        Debug.Log("Dialog is over. Move again!");
        //Tell all the other objects, that they can move again
        for (int i = 0; i < cutsceneBehaviourList.Count; i++)
        {
            cutsceneBehaviourList[i].SetInteractivity(true);
        }
    }

    public void AddListener(CutsceneBehaviour cB)
    {
        cutsceneBehaviourList.Add(cB);
    }

    public void RemoveListener(CutsceneBehaviour cB)
    {
        cutsceneBehaviourList.Remove(cB);
    }
}
