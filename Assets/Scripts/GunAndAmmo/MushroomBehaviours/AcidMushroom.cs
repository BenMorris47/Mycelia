using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidMushroom : PlayerFunglebehaviour
{
    public float dissolveSpeed = .5f;
    public float currentDesolveAmount = 0;
    public bool dissolving = false;
    float currentDisolveAmount;
    public List<Material> disolveMats = new List<Material>();

    public override void Start()
    {
        if (transform.parent == null)
        {
            Destroy(gameObject);
        }
        //check hit transform can be dissolved
        if (transform.parent.gameObject.tag == "FungleMass" || transform.parent.gameObject.tag == "Dissolvable")
        {
            //play hit sound
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Sound Effects/Gun/Gun_AcidMelt", gameObject);
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Sound Effects/Gun/Gun_AcidImpact", gameObject);
            //get all available materials of all children
            if (transform.parent.TryGetComponent<MeshRenderer>(out MeshRenderer renderer))
            {
                disolveMats.Add(renderer.material);
            }
            if (transform.parent.TryGetComponent<SkinnedMeshRenderer>(out SkinnedMeshRenderer skinedRenderer))
            {
                disolveMats.Add(skinedRenderer.material);
            }
            foreach (var child in transform.parent.GetComponentsInChildren<MeshRenderer>())
            {
                disolveMats.Add(child.material);
            }
            foreach (var child in transform.parent.GetComponentsInChildren<SkinnedMeshRenderer>())
            {
                disolveMats.Add(child.material);
            }
            foreach (var childCol in transform.parent.GetComponentsInChildren<Collider>())
            {
                if (childCol.gameObject.tag == "FungleMass" || transform.parent.gameObject.tag == "Dissolvable") //a second check to ensure all parts are dissolvable
                {
                    dissolving = true;
                    Destroy(childCol, (1 / dissolveSpeed) / 2); //finds the halfway of the dissolve to destroy the colliders
                }
            }
        }
        else
        {
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Sound Effects/Gun/Gun_AcidMiss", gameObject);
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Sound Effects/Gun/Gun_AcidImpact", gameObject);
            foreach (var child in GetComponentsInChildren<MeshRenderer>())
            {
                disolveMats.Add(child.material);
            }
        }

        base.Start();
    }

    private void Update()
    {
        //increase disolve amount over time
        currentDisolveAmount += dissolveSpeed * Time.deltaTime;
        var amountDissolved = Mathf.Lerp(0, 1, currentDisolveAmount);

        foreach (var mat in disolveMats)
        {
            mat.SetFloat("_Dissolve", amountDissolved);
        }
        if (amountDissolved >= 1)
        {
            //destroy gameobects once dissolved
            if (transform.parent.gameObject.tag == "FungleMass" || transform.parent.gameObject.tag == "Dissolvable")
            {
                
                Destroy(transform.parent.gameObject, dissolveSpeed);
            }
            else
            {
                
                Destroy(gameObject, dissolveSpeed);
            }
        }
        
    }
}
