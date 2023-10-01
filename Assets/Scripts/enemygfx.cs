using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;
    void Start()
    {
    }

    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-0.3f, 0.3f, 1);
        }
        if (aiPath.desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 1);
        }
        
    }
}
