using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerFunglebehaviour : MonoBehaviour
{
    //God I need to get better at naming these classes.
    public MushroomLauncher launcher;

    public virtual void Start()
    {
        if (launcher != null)
        { //adds the currently existing bullet to the list of active bullets
            launcher.AddActiveBullet(gameObject);
        }
    }
    public virtual void OnDestroy()
    {
        if (launcher != null)
        {
            //removes bullet from list
            launcher.RemoveActiveBullet(gameObject);
        }
        
    }
}
