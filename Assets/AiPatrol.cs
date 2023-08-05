using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPatrol : MonoBehaviour
{
    // Start is called before the first frame update
 
    void Start()
    {
        gameObject.SetActive(true);
        gAM
      
    }

  // Update is called once per frame
  void Update()
  {
 

  }


  void OnTriggerEnter2D(Colliider2D col)
  {
    if (col.gameObject.CompareTag("Bounds")
    {
      direction = direction * -1; // reverse direction

     
      movingLeft = !movingLeft  //reverse the bool whatever it is
    }
  

  }
}
