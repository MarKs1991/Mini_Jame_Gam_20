using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMAnager : MonoBehaviour
{
    public int MaxPlayerHealth = 3;
    public int PlayerHealthCount = 3;

    public int MaxOrganPipeCount = 5;
    public int OrganPipeCount = 0;

    // Start is called before the first frame update
    void Start()
    {
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

            if (PlayerHealthCount == 0)
            {
                //Trigger Game Over
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
}
