using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EntryButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(delegate { JournalUIManager.instance.OpenEntry(entryToPrint); });
        titleText.text = entryToPrint.title;
        dateText.text = entryToPrint.dateStringDDMMYYYY;
    }
    public JournalEntry entryToPrint;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI dateText;
}
