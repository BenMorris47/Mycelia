using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SomnusTools.Utility.DeveloperConsole.Commands
{
	[CreateAssetMenu(fileName ="New Log Command",menuName ="SomnusTools/Utility/DeveloperConsole/Commands/Log Command")]
	public class LogCommand : ConsoleCommand
	{
		public override bool Process(string[] args)
		{
			string logtext = string.Join(" ", args);

			Debug.Log(logtext);

			return true;
		}
	}
}