using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrganInteraction : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.layer == 12)
        {

            if (other.GetComponent<StatusManager>() != null)
            {
                SceneManager.LoadScene("Success");
                Destroy(this.gameObject);

            }

        }
    }
}
