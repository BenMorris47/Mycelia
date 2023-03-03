using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[ExecuteInEditMode]
public class ObjectBatchPlacementTool : MonoBehaviour
{
    [Header("Profile Override Settings")]
    public bool Override = false;
    public PlacementProfile overridePlacementProfile = new PlacementProfile(10);
    [Space]
    [Header("General Placer Settings")]
    public Vector3 prevPos = Vector3.zero;
    public Quaternion prevRot = new Quaternion();
    public string seedPrefix = "";
    public LayerMask rayLayerMask = -1;
    public float spawnRadius = 5;
    [Space]
    [Header("Placement Profiles and Placed Objects")]
    public PlacementProfile[] spawnableObjects = new PlacementProfile[1] { new PlacementProfile(10)};
    public List<Transform> spawnedObjects = new List<Transform>();
    private System.Random randomGen = new System.Random();
    public bool update = true;
    

    public void overrideProfileValues()
    {
        for (int i = 0; i < spawnableObjects.Length; i++)
        {
            GameObject placementObject = overridePlacementProfile.placeableObject;
            if (placementObject == null)
            {
                placementObject = spawnableObjects[i].placeableObject;
            }
            spawnableObjects[i] = overridePlacementProfile;
            spawnableObjects[i].placeableObject = placementObject;
        }
        Override = false;
    }

    private void Update()
    {
        if (Override)
        {
            overrideProfileValues();
        }
        if (!update)
        {
            return;
        }
        if (prevPos == transform.position && prevRot == transform.rotation)
        {
            return;
        }
        prevPos = transform.position;
        prevRot = transform.rotation;
        randomGen = new System.Random($"{seedPrefix},{prevPos},{prevRot}".GetHashCode());
        
        foreach (var item in transform.GetComponentsInChildren<Transform>())
        {
            if (item == null)
            {
                continue;
            }
            if (item.gameObject == gameObject)
            {
                continue;
            }
			
            DestroyImmediate(item.gameObject);
        }
        foreach (var objectProfile in spawnableObjects)
        {
            if (objectProfile.placeableObject == null)
            {
                continue;
            }
            for (int i = 0; i < objectProfile.amountToTryPlace; i++)
            {
                
                float x = (float)(randomGen.NextDouble() * (spawnRadius - -spawnRadius) + -spawnRadius);
                float z = (float)(randomGen.NextDouble() * (spawnRadius - -spawnRadius) + -spawnRadius);
                float scaleMod = (float)(randomGen.NextDouble() * (objectProfile.minMaxSize.y - objectProfile.minMaxSize.x) + objectProfile.minMaxSize.x);
                var pos = new Vector3(x + transform.position.x, transform.position.y, z + transform.position.z);
                if (!Physics.Raycast(pos, objectProfile.placementRayDirection, out RaycastHit hit, objectProfile.placementRayRange, rayLayerMask)|| spawnedObjects.Contains(hit.collider.transform))
                {
                    continue; 
                }
                if (Mathf.Abs(Vector3.Angle(-objectProfile.placementRayDirection, hit.normal)) > Mathf.Abs(objectProfile.maxPlacementAngle) )
                {
                    continue;  
                }
                pos.y = hit.point.y;
                var spawnedObject = Instantiate(objectProfile.placeableObject, pos, Quaternion.Euler(0, 1, 0), transform);
                if (objectProfile.alignToNormals)
                {
                    spawnedObject.transform.rotation = Quaternion.FromToRotation(spawnedObject.transform.rotation.eulerAngles, hit.normal);
                }
                //Rotation Adjustments
                spawnedObject.transform.Rotate(spawnedObject.transform.up, randomGen.Next(-360, 360));
                //spawnedObject.transform.Rotate(spawnedObject.transform.forward, randomGen.Next(-10, 10));
                //spawnedObject.transform.Rotate(spawnedObject.transform.right, randomGen.Next(-10, 10));

                spawnedObject.transform.localScale = spawnedObject.transform.localScale * scaleMod;
                
            }
        }
        //reloads the list, not needed more for adding 
        spawnedObjects.Clear();
        foreach (var item in transform.GetComponentsInChildren<Transform>())
        {
            if (item.gameObject == gameObject)
            {
                continue;
            }
            spawnedObjects.Add(item);
        } 
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnRadius * 2, 0.1f, spawnRadius * 2));
        
        foreach (var item in spawnableObjects)
        {
            Gizmos.color = item.gizmoColour;
            Gizmos.DrawLine(transform.position, transform.position + (item.placementRayDirection * 3));
        }
    }


    [System.Serializable]
    public struct PlacementProfile
    {
        public GameObject placeableObject;
        public Vector3 placementRayDirection;
        public bool alignToNormals;
        public int amountToTryPlace;
        public Color gizmoColour;
        public Vector2 minMaxSize;
        public float placementRayRange;
        public float maxPlacementAngle;

        public PlacementProfile(int amount)
        {
            placeableObject = null;
            placementRayDirection = -Vector3.up;
            alignToNormals = true;
            amountToTryPlace = amount;
            gizmoColour = Color.white;
            minMaxSize = new Vector2(0.75f,1);
            placementRayRange = 10;
            maxPlacementAngle = 30;
        }

    }

}

