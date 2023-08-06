using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public int collectableValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.layer == 12)
        {

            if (other.GetComponent<StatusManager>() != null)
            {
                other.gameObject.GetComponent<StatusManager>().addCollectable(collectableValue);
                Destroy(this.gameObject);

            }

        }
    }
}
