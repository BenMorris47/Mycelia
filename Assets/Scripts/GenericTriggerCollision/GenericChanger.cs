using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericChanger : MonoBehaviour
{
    //I don't know why this class exists... I don't know why I made this
    public bool onTriggerEnter;
    public bool onTriggerExit;
    public bool onCollisionEnter;
    public bool onCollisionExit;

    public virtual void OnTriggerEnter(Collider other)
    {
        if (onTriggerEnter)
        {
            Debug.Log("Entered Trigger");
        }
    }
    public virtual void OnTriggerExit(Collider collision)
    {
        if (onTriggerExit)
        {
            Debug.Log("Exited Trigger");
        }
    }
    public virtual void OnCollisionEnter(Collision collision)
    {
        if (onCollisionEnter)
        {
            Debug.Log("Entered Collision");
        }
    }
    public virtual void OnCollisionExit(Collision collision)
    {
        if (onCollisionExit)
        {
            Debug.Log("Exited Trigger");
        }
    }


}
