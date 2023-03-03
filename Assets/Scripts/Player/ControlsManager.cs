using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ControlsManager : MonoBehaviour
{
    public Controls controls;
	public bool allowConsole = true;
	public static ControlsManager instance;
	public UnityEvent onControlModeChange;
	public enum ControlModes { PlayMode, StartOfGame, PhotoMode, MenuMode, Pause }
	public ControlModes currentMode { get; private set; }
	public ControlModes prevMode { get; private set; }
	void OnEnable() => controls.Enable();
	void OnDisable() => controls.Disable();
	private void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(this);
			return;
		}
		instance = this;
		if (controls == null)
		{
			controls = new Controls();
		}
		controls.ConstantControls.Enable();
	}
	private void Start()
	{
		ChangeControlMode(currentMode);
		if (allowConsole)
		{
			controls.DevConsole.Enable();
		}
		else
		{
			controls.DevConsole.Disable();
		}
	}

	public void ChangeControlMode(ControlModes mode)
	{
		prevMode = currentMode;
		currentMode = mode;
		Debug.Log($"Switched control mode to <color=Green>{mode}</color>");
		switch (currentMode)
		{
			case ControlModes.PlayMode:
				EnterPlayMode();
				break;
			case ControlModes.PhotoMode:
				EnterPhotoMode();
				break;
			case ControlModes.MenuMode:
				EnterMenuMode();
				break;
			case ControlModes.Pause:
				EnterPauseMode();
				break;
			case ControlModes.StartOfGame:
				EnterStart();
				break;
			default:
				break;
		}
		onControlModeChange?.Invoke();
	}


    public bool ToggleControlMode(ControlModes mode)
    {
        if (currentMode == mode)
        {
			ChangeControlMode(prevMode);
			return true;
        }
		else
        {
			ChangeControlMode(mode);
			return false;
		}
    }

	private void EnterPlayMode()
	{
		controls.Look.Enable();
		controls.GunConrols.Enable();
		controls.PlayerMovement.Enable();
		controls.InteractionSystem.Enable();
		controls.PhotoModeControls.Disable();
		controls.TabletShortcuts.Enable();
		controls.StartGameText.Disable();
		controls.ConstantControls.Enable();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void EnterPhotoMode()
	{
		controls.Look.Disable();
		controls.GunConrols.Disable();
		controls.PlayerMovement.Enable();
		controls.InteractionSystem.Disable();
		controls.PhotoModeControls.Enable();
		controls.TabletShortcuts.Enable();
		controls.StartGameText.Disable();
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void EnterMenuMode()
	{
		controls.Look.Disable();
		controls.GunConrols.Disable();
		controls.PlayerMovement.Disable();
		controls.InteractionSystem.Enable();
		controls.PhotoModeControls.Disable();
		controls.TabletShortcuts.Disable();
		controls.StartGameText.Disable();
		Cursor.lockState = CursorLockMode.Confined;
	}	

	
	private void EnterPauseMode()
    {
		controls.Look.Disable();
		controls.GunConrols.Disable();
		controls.PlayerMovement.Disable();
		controls.InteractionSystem.Disable();
		controls.PhotoModeControls.Disable();
		controls.TabletShortcuts.Enable();
		controls.StartGameText.Disable();
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
	}
	private void EnterStart()
	{
		controls.Look.Disable();
		controls.GunConrols.Disable();
		controls.PlayerMovement.Disable();
		controls.InteractionSystem.Disable();
		controls.PhotoModeControls.Disable();
		controls.TabletShortcuts.Disable();
		controls.StartGameText.Enable();
		controls.ConstantControls.Disable();
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
	}

}
