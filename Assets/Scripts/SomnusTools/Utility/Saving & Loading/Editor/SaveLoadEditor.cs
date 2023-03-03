//Created by Ben Morris.
using UnityEngine;
using UnityEditor;

namespace SomnusTools.SomnusEditors
{
	[CustomEditor(typeof(AdvancedSavingLoadingManager))]
	public class SaveLoadEditor : Editor
	{
		public override void OnInspectorGUI()
		{

			base.OnInspectorGUI();
			AdvancedSavingLoadingManager saveLoadManager = (AdvancedSavingLoadingManager)target;

			GUILayout.BeginHorizontal();

			if (GUILayout.Button("Save"))
			{
				saveLoadManager.Save();
			}

			if (GUILayout.Button("Load"))
			{
				saveLoadManager.Load();
			}
			GUILayout.EndHorizontal();
			if (GUILayout.Button("DeleteSaveFile"))
			{
				saveLoadManager.DeleteSaveFile();
			}
		}
	}
}

