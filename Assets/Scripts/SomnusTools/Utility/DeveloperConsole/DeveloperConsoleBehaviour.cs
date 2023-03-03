using SomnusTools.Utility.DeveloperConsole.Commands;
using UnityEngine;
using TMPro;
using static UnityEngine.InputSystem.InputAction;
using System.Collections.Generic;
using System;

namespace SomnusTools.Utility.DeveloperConsole
{
	public class DeveloperConsoleBehaviour : MonoBehaviour
	{
		[SerializeField] private string prefix;
		[SerializeField] private ConsoleCommand[] commands = new ConsoleCommand[0];
		private List<string> previouseCommands;

		[Header("UI")]
		[SerializeField] private GameObject uiCanvas;
		[SerializeField] private TMP_InputField inputField;
		[SerializeField] private TextMeshProUGUI previouseCommandDisplay;

		private float pausedTimeScale;
		private CursorLockMode pausedLockMode;
		private bool pausedWasCursorVisible;
		//public Controls controls;

		private static DeveloperConsoleBehaviour instance;

		private DeveloperConsole developerConsole;

		private DeveloperConsole DeveloperConsole
		{
			get 
			{
				if (developerConsole != null)
				{
					return developerConsole;
				}
				return developerConsole = new DeveloperConsole(prefix, commands);
			}
		}

		private void Awake()
		{
			if (instance != null && instance == this)
			{
				Destroy(gameObject);
				return;
			}
			instance = this;
			previouseCommands = new List<string>();
			UpdatedPreviousCommandUI();
			DontDestroyOnLoad(gameObject);
			//controls = new Controls();
			//controls.DevConsole.ConsoleToggle.performed += context => Toggle();
			
		}
		//void OnEnable() => controls.Enable();
		//void OnDisable() => controls.Disable();
		void OnEnable()
		{
			ControlsManager.instance.controls.DevConsole.ConsoleToggle.performed += context => Toggle();
		}
		void OnDisable()
		{
			ControlsManager.instance.controls.DevConsole.ConsoleToggle.performed -= context => Toggle();
		}

		public void Toggle()
		{

			if (uiCanvas.activeSelf)
			{
				Time.timeScale = pausedTimeScale;
				Cursor.lockState = pausedLockMode;
				Cursor.visible = pausedWasCursorVisible;
				uiCanvas.SetActive(false);
			}
			else
			{
				pausedTimeScale = Time.timeScale;
				pausedWasCursorVisible = Cursor.visible;
				pausedLockMode = Cursor.lockState;
				Cursor.lockState = CursorLockMode.Confined;
				Cursor.visible = true;
				Time.timeScale = 0;
				uiCanvas.SetActive(true);
				inputField.ActivateInputField();
			}
		}

		public void ProcessCommand(string inputValue)
		{
			DeveloperConsole.ProcessCommand(inputValue);
			UpdatePreviouseCommands(inputValue);
			inputField.text = string.Empty;
			inputField.ActivateInputField();
		}

		public void UpdatePreviouseCommands(string inputValue)
		{
			if (!string.IsNullOrEmpty(inputValue))
			{
				previouseCommands.Add(inputValue);
				UpdatedPreviousCommandUI();
			}
		}

		private void UpdatedPreviousCommandUI()
		{
			if (previouseCommandDisplay != null)
			{
				string tempString = string.Empty;
				foreach (var item in previouseCommands)
				{
					if (item.StartsWith(prefix))
					{
						tempString = $"{tempString}\n <color=green>{item}</color>";
					}
					else
					{
						tempString = $"{tempString}\n {item}";
					}
					
				}
				previouseCommandDisplay.text = tempString;
			}
		}
	}

}

