using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PullMushroom : PlayerFunglebehaviour
{
	public float searchRadius = 2;
	public float mushroomStrength = 30;
	public float mushroomLifeTime = 5;
	public AnimationCurve lineWidthCurve;
	[SerializeField]private List<rbClosePointPair> connectedRBPair = new List<rbClosePointPair>();
    public override void Start()
    {
		RuntimeManager.PlayOneShotAttached("event:/Sound Effects/Gun/Gun_TendrilImpact", gameObject);
		var closeColliders = Physics.OverlapSphere(transform.position, searchRadius);

		//find every rb in a certain radius and save its closest point to this transform
		foreach (var item in closeColliders)
		{
			Vector3 closestpoint = item.ClosestPoint(transform.position);

			if (item.gameObject == gameObject)
			{
				continue;
			}
			if (item.tag == "FungleMass" && Physics.Raycast(transform.position + (transform.up * 0.5f), (transform.position + (transform.up * 0.5f)) - closestpoint, out RaycastHit hit)) //make sure the objects can be seen
			{
				rbClosePointPair pair = new rbClosePointPair { targetRb = null, connectionPoint = item.transform };
				if (item.transform.parent != null && item.transform.parent.TryGetComponent<Rigidbody>(out Rigidbody rb))
				{
					item.transform.parent = rb.transform;
					pair = new rbClosePointPair { targetRb = rb, connectionPoint = item.transform };
				}
				connectedRBPair.Add(pair);
			}


		}
		Destroy(gameObject, mushroomLifeTime); //destroy after set time
		base.Start();
    }
    private void FixedUpdate()
	{
		//add force at connected point to pull towards the bullet
		foreach (var pair in connectedRBPair)
		{
			if (pair.targetRb != null )
			{
				pair.targetRb.AddForceAtPosition((transform.position - pair.connectionPoint.position) * mushroomStrength, pair.connectionPoint.position, ForceMode.Force);
			}
		}
	}

	

	[System.Serializable]
	public struct rbClosePointPair
	{
		public Rigidbody targetRb;
		public Transform connectionPoint;
	}

	private void OnDrawGizmos()
	{
		//visuallizes the connections
		Gizmos.color = Color.yellow;
		foreach (var item in connectedRBPair)
		{
			if (item.connectionPoint != null)
			{
				Gizmos.DrawLine(transform.position, item.connectionPoint.position);
			}
		}
		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, searchRadius);
	}
}
