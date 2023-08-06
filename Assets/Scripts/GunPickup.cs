using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public CharacterController2D cC2 = null;

    void Start()
    {
        cC2 = GameObject.FindWithTag("Player").GetComponent<CharacterController2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.gameObject.layer == 12)
        {

            if (other.GetComponent<StatusManager>() != null)
            {
                cC2.GainGunPermit();
                Destroy(this.gameObject);
            }

        }
    }
}
