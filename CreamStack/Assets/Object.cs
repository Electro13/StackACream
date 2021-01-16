using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{

    //Every Object will have this
    protected BoxCollider2D bc;
    protected PlatformEffector2D pf;

    protected void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        pf = GetComponent<PlatformEffector2D>();
    }


    //Methods to turn off the collisions
    public void RemoveBoxColider()
    {
        bc.enabled = false;
    }
    public void RemovePlatformEffector()
    {
        pf.enabled = false;
    }
}
