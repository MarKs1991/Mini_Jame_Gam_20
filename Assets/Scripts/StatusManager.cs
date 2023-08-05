using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{

    public float health;
    public int collectables;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void takeDamage(float dmg)
    {
        health = health - dmg;

        if (health <= 0)
            gameoverState();

    }

    public void gameoverState()
    {
        //play dyingAnimation
        //show GameOVERscreen with restart
    }

    public void addHealth(int addHealth)
    {

        health = health + addHealth;
        if (health > 5)
        {
            health = 5;
        }

    }
    public void addCollectable(int addedCollectables)
    {
        collectables = collectables + addedCollectables;
    }

    
}
