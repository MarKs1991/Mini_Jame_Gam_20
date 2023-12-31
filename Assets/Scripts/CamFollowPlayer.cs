using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollowPlayer : MonoBehaviour
{
    public Transform Player;
    public float OffsetX = -10;
    public float OffsetY = 5;
    public float OffsetZ = -15;



    public bool CamLimits = false;
    public float LeftLimit;
    public float RightLimit;
    public float BottomLimit;
    public float TopLimit;

    void Update()
    {
        float x = Player.position.x + OffsetX;
        float y = Player.position.y + OffsetY;
        float z = Player.position.z + OffsetZ;
        transform.position = new Vector3(x, y, z);

        if (CamLimits)
        {
            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, LeftLimit, RightLimit),
                Mathf.Clamp(transform.position.y, BottomLimit, TopLimit),
                transform.position.z

            );
        }
    }
}