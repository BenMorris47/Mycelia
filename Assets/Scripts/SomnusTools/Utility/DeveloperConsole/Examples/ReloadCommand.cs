using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SomnusTools.Utility.DeveloperConsole.Commands
{
	[CreateAssetMenu(fileName = "New Reload Command", menuName = "SomnusTools/Utility/DeveloperConsole/Commands/Reload Command")]
	public class ReloadCommand : ConsoleCommand
	{
		public override bool Process(string[] args)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
			Time.timeScale = 1;
			return true;
		}
	}
}