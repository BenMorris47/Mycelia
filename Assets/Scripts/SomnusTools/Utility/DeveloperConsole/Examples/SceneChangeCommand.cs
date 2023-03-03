using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SomnusTools.Utility.DeveloperConsole.Commands
{
	[CreateAssetMenu(fileName = "New SceneChange Command", menuName ="SomnusTools/Utility/DeveloperConsole/Commands/SceneChange Command")]
	public class SceneChangeCommand : ConsoleCommand
	{
		public override bool Process(string[] args)
		{
			SceneManager.LoadScene(args[0]);
			return true;
		}
	}
}