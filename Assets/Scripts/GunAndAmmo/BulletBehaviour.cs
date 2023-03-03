using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public PlayerFunglebehaviour mushroomAmmoObject;
    public MushroomLauncher launcher;
    public Rigidbody rigidbody;
    public float lifeTime = 4;
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)//6 is the player layer
        {
            Destroy(gameObject);//destroy the bullet
            return;
        }
        ContactPoint contact = collision.contacts[0]; // gets the first place that is hit
        Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal); //alligns the fungle mass to the normals of the hit surface
        Vector3 position = contact.point;//places it at the hit position
        var mushroom = Instantiate(mushroomAmmoObject, position, rotation);//spawn the bullet
        mushroom.launcher = launcher;
        mushroom.transform.parent = collision.transform;//set the parent keeping the original size
        Destroy(gameObject);//destroy the bullet
    }
}
