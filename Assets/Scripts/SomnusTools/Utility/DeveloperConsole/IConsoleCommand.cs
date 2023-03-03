using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SomnusTools.Utility.DeveloperConsole
{
	public interface IConsoleCommand
	{
		string CommandWord { get; }
		bool Process(string[] arg);
	}
}
