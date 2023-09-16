using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymoveright : MonoBehaviour
{
    // Start is called before the first frame update
    public float enemySpeed;
    public Rigidbody2D enemyRigidBody;

    // Update is called once per frame
    void Update()
    {
        enemyRigidBody.AddForce(Vector2.left*enemySpeed);
    }
}
