using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  switchcamera : MonoBehaviour
{

    public bool camera1working = true;

    [SerializeField]  GameObject camera1;
    [SerializeField]  GameObject camera2;
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cam2();
            BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
            if (boxCollider != null)
            {
                boxCollider.isTrigger = false;
            }
        }
       
    }
   
    public void cam2()
    {
        camera1.SetActive(false);
        camera2.SetActive(true);
        camera1working = false;
    }
}
