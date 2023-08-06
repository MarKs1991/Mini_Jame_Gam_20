using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StatusManager : MonoBehaviour
{

    public float health;
    public int collectables;

    public bool InMeleeRange;
    public Transform AttackTarget;

    private UIMAnager uiManager = null;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("CharacterDisplayCanvas").GetComponent<UIMAnager>() != null)
        {
            uiManager = GameObject.Find("CharacterDisplayCanvas").GetComponent<UIMAnager>();
        }
    }

    public void takeDamage(float dmg)
    {
        if (uiManager == null)
        {
            uiManager = GameObject.Find("CharacterDisplayCanvas").GetComponent<UIMAnager>();
        }
        uiManager.AdjustHealthAndPipeDisplay((int)-dmg, true);

        health = health - dmg;

        if (health <= 0)
            gameoverState();

    }

    public void gameoverState()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void addHealth(int addHealth)
    {
        if (uiManager == null)
        {
            uiManager = GameObject.Find("CharacterDisplayCanvas").GetComponent<UIMAnager>();
        }

        uiManager.AdjustHealthAndPipeDisplay(addHealth, true);
        uiManager.TriggerHealthGainSound();

        health = health + addHealth;
        if (health > 5)
        {
            health = 5;
        }

    }
    public void addCollectable(int addedCollectables)
    {
        if (uiManager == null)
        {
            uiManager = GameObject.Find("CharacterDisplayCanvas").GetComponent<UIMAnager>();
        }
        uiManager.AdjustHealthAndPipeDisplay(addedCollectables, false);
        uiManager.TriggerPipeGainSound();

        collectables = collectables + addedCollectables;
    }
    
    public void setAttackRange(bool inRange)
    {
        InMeleeRange = inRange;
    }

    public bool getAttackRange()
    {
        return InMeleeRange;

    }
    public void setAttackTarget(Transform Target)
    {
        AttackTarget = Target;
    }

    public Transform getAttackTarget()
    {
        return AttackTarget;

    }

}
