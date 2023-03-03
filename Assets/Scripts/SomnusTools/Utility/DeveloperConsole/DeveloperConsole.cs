using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SomnusTools.Utility.DeveloperConsole
{
	public class DeveloperConsole
	{

		private readonly string prefix;
		private readonly IEnumerable<IConsoleCommand> commands;

		public DeveloperConsole(string prefix,IEnumerable<IConsoleCommand> commands)
		{
			this.prefix = prefix;
			this.commands = commands;
		}

		public void ProcessCommand(string inputvalue)
		{
			if (!inputvalue.StartsWith(prefix))
			{
				return;
			}

			inputvalue = inputvalue.Remove(0, prefix.Length);

			string[] inputSplit = inputvalue.Split(' ');

			string commandInput = inputSplit[0];
			string[] args = inputSplit.Skip(1).ToArray();

			ProcessCommand(commandInput, args);
		}

		public void ProcessCommand(string commandInput,string[] arg)
		{
			foreach (var command in commands)
			{
				if (!commandInput.Equals(command.CommandWord,System.StringComparison.OrdinalIgnoreCase))
				{
					continue;
				}

				if (command.Process(arg))
				{
					return;
				}
			}
		}
	}
}

