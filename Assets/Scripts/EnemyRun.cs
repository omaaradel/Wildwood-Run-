using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRun : MonoBehaviour
{
    [SerializeField] float enemySpeed;
    [SerializeField] Rigidbody2D enemyRigidBody;

    void Update()
    {
        enemyRigidBody.AddForce(Vector2.left*enemySpeed);
    }
}
