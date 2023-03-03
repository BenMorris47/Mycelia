using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TestLevelSystem : MonoBehaviour, ISaveable
{
	[SerializeField] private int level = 1;
	[SerializeField] private int xp = 100;

	public object CaptureState()
	{
		return new saveData
		{
			xp = xp,
			level = level
		};
	}

	public void RestoreState(object state)
	{
		var savedata = (saveData)state;
		level = savedata.level;
		xp = savedata.xp;
	}

	[Serializable]
	private struct saveData
	{
		public int level;
		public int xp;
	}
}
