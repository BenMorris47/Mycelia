using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class DirectionalSceneTrigger : MonoBehaviour
{
	public float dotProduct;
	public string greenScene;
	public string redScene;

	private void OnTriggerExit(Collider other)
	{
        if (other.tag == "Player")
        {
			CheckExitDirection(other.transform);
		}
	}



	public void CheckExitDirection(Transform exitingTransform)
	{
		Vector3 exitDirection = transform.position - exitingTransform.position;
		dotProduct = Vector3.Dot(transform.forward, -exitDirection); 
		//check which way the trigger is exited and load apropriate scene
		if (dotProduct > 0)
		{
			if (SceneManager.GetSceneByName(greenScene).isLoaded)
			{
				return;
			}
			Debug.Log("To Green");
			SceneManager.LoadSceneAsync(greenScene, LoadSceneMode.Additive);
			SceneManager.UnloadSceneAsync(redScene);
		}
		else if (dotProduct < 0)
		{
            if (SceneManager.GetSceneByName(redScene).isLoaded)
            {
				return;
            }
			Debug.Log("To Red");
			SceneManager.LoadSceneAsync(redScene, LoadSceneMode.Additive);
			SceneManager.UnloadSceneAsync(greenScene);

		}
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(transform.position + transform.forward, 0.2f);
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position + -transform.forward, 0.2f);
	}
}

