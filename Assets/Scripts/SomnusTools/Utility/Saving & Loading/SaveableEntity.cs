//Created by Ben Morris.
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SomnusTools
{

	public class SaveableEntity : MonoBehaviour
	{
		[SerializeField] private string id = string.Empty;

		public string Id => id;

		[ContextMenu("Generate Id")]
		private void GenerateID() => id = Guid.NewGuid().ToString(); //generates a new guid as a unique id

		public object CaptureState() //captures the state of ever isaveable script on the game object;
		{
			var state = new Dictionary<string, object>(); //generates a dictionary to hold the script type and captured states.
			foreach (var saveable in GetComponents<ISaveable>()) //runs through all scripts with the isaveable interface
			{
				state[saveable.GetType().ToString()] = saveable.CaptureState(); //sets the string to the script type that it is capturing and sets the object to the scripts capture state
			}
			return state;
		}

		public void RestoreState(object state) // restores the data for all isavables on this gameobject
		{
			var stateDictionary = (Dictionary<string, object>)state; //converts the input state into a Dictionary<string, object> for use when finding data
			foreach (var saveable in GetComponents<ISaveable>()) //runs through all scripts with the isaveable interface
			{
				string typeName = saveable.GetType().ToString(); //gets the type of the script for use as a key
				if (stateDictionary.TryGetValue(typeName, out object value)) //trys to get a value using the type key. If it gets it continues.
				{
					saveable.RestoreState(value);//restores the state using the value from the dictionary;
				}
			}
		}

		private void OnDrawGizmosSelected()
		{
			if (id == string.Empty)
			{
				GenerateID();
			}
		}
	}
}
