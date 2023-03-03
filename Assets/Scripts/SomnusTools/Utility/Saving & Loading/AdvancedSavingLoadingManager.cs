//Created by Ben Morris (null somnus).
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using UnityEngine;

namespace SomnusTools
{
    public class AdvancedSavingLoadingManager : MonoBehaviour
    {
        public string saveNameIncExtention = "save.sav";
        private string SavePath => $"{Application.persistentDataPath}/{saveNameIncExtention}";
        public static AdvancedSavingLoadingManager instance;


        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this);
            }
            else
            {
                instance = this;
            }
        }

        [ContextMenu("Save")]
        public void Save()
        {
            var state = LoadFile();
            CaptureState(state);
            SaveFile(state);
        }

        [ContextMenu("Load")]
        public void Load()
        {
            RestoreState(LoadFile());
        }
        [ContextMenu("Clean Up Save")]
        public void CleanUpSave()
        {
            Load();
            DeleteSaveFile();
            Save();
        }

        public void DeleteSaveFile()
        {
            if (!File.Exists(SavePath))
            {
                Debug.Log($"<color=Red>File Does Not Exist</color>");
            }
            else if (File.Exists(SavePath))
            {
                File.Delete(SavePath);
                Debug.Log($"<color=green>File Deletion Sucessful</color>");
            }
        }

        private Dictionary<string, object> LoadFile()
        {
            if (!File.Exists(SavePath))
            {
                Debug.Log($"<color=Red>File Does Not Exist</color>");
                return new Dictionary<string, object>();
            }

            using (FileStream stream = File.Open(SavePath, FileMode.Open))
            {
                var formatter = new BinaryFormatter();
                Debug.Log($"<color=green>Loaded</color> {SavePath} was loaded sucessfully");
                return (Dictionary<string, object>)formatter.Deserialize(stream);
            }

        }

        private void SaveFile(object state)
        {
            using (var stream = File.Open(SavePath, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, state);
            }
            Debug.Log($"<color=green>Saved</color> {SavePath} was saved sucessfully");

        }

        private void CaptureState(Dictionary<string, object> state)
        {
            foreach (var saveable in FindObjectsOfType<SaveableEntity>())
            {
                state[saveable.Id] = saveable.CaptureState();
            }
        }

        private void RestoreState(Dictionary<string, object> state)
        {
            foreach (var saveable in FindObjectsOfType<SaveableEntity>())
            {
                if (state.TryGetValue(saveable.Id, out object value))
                {
                    saveable.RestoreState(value);
                }
            }
        }
    }
}
