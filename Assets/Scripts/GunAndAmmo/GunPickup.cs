using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    public void Pickup()
    {
        MushroomLauncher.instance.gameObject.SetActive(true);
    }
}
