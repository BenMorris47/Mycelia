using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
public class DialogueHistory : MonoBehaviour
{
    public List<Dialogue.DialoguePiece> history = new List<Dialogue.DialoguePiece>();
    private List<GameObject> historyList = new List<GameObject>();
    public GameObject parent;
    public GameObject prefab;

    private void OnEnable()
    {
        ControlsManager.instance.controls.PlayerMovement.History.performed += ShowHistory;
    }

    private void OnDisable()
    {
        ControlsManager.instance.controls.PlayerMovement.History.performed -= ShowHistory;
    }

    private void ShowHistory(InputAction.CallbackContext context)
    {
        foreach (GameObject item in historyList)
        {
            GameObject.Destroy(item);
        }
        historyList.Clear();

        foreach (Dialogue.DialoguePiece current in history)
        {
            GameObject temp = GameObject.Instantiate(prefab, parent.transform);

            temp.GetComponentInChildren<TextMeshProUGUI>().text = current.subtitles;

            historyList.Add(temp);
        }
    }
}
