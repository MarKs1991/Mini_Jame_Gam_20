using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{

    public int Health;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {        
        
        if (other.gameObject.layer == 12)
        {
       
            if (other.GetComponent<StatusManager>() != null)
            {

                other.gameObject.GetComponent<StatusManager>().addHealth(Health);
                Destroy(this.gameObject);

            }

        }
    }
}
