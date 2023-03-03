using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToChangeScene : MonoBehaviour
{
	public string sceneName = "SCN_StartMenu";
	private void Update()
	{
		if (Input.anyKey)
		{
			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;
			SceneManager.LoadScene(sceneName);
			
		}
	}
}
