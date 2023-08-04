using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public LayerMask layerMask;

    public int Health;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {        
        
        if (other.gameObject.layer == 12)
        {
       
            if (other.GetComponent<StatusManager>() != null)
            {
                Debug.Log(10);
                other.gameObject.GetComponent<StatusManager>().addHealth(Health);
                Destroy(transform.parent.gameObject);

            }

        }
    }
}
