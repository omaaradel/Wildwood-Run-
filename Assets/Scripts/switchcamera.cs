using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchcamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject camera1;
    [SerializeField] private GameObject camera2;
    [SerializeField] private int manager;

    //public void managecamera()
    //{
    //    if (manager == 0)
    //    {
    //        cam2();
    //        manager = 1;
    //    }
    //    else
    //    {
    //        cam1();
    //        manager = 0;
    //    }
    //}
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
    }
}
