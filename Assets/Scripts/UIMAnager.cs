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

    // Start is called before the first frame update
    void Start()
    {
        uiAudioSource = GetComponent<AudioSource>();
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
                    this.transform.GetChild(0).GetChild(i).GetChild(0).gameObject.SetActive(false);
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
}
