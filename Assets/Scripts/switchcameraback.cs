using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchcameraback : MonoBehaviour
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            cam1();
        }
    }
    public void cam1()
    {
        camera1.SetActive(true);
        camera2.SetActive(false);
    }
   
}
