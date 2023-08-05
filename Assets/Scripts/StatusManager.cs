using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{

    public int health;
    public int collectables;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addHealth(int addHealth)
    {

        health = health + addHealth;
        if (health > 100)
        {
            health = 100;
        }

    }
    public void addCollectable(int addedCollectables)
    {
        collectables = collectables + addedCollectables;
    }
}
