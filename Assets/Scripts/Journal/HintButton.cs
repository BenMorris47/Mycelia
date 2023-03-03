using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HintButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate { JournalUIManager.instance.OpenHint(hintEntry); });
        titleText.text = hintEntry.hintTitle;
    }
    public HintEntry hintEntry;
    public TextMeshProUGUI titleText;
}
