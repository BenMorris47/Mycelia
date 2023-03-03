using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JournalUIManager : MonoBehaviour
{
    public static JournalUIManager instance = null;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public List<JournalEntry> journalEntries = new List<JournalEntry>();
    public List<HintEntry> hintEntries = new List<HintEntry>();
    public int timeToClear = 5;

    #region hints
    [Header("Hints")]
    //this is the object which will store the buttons for entries
    public GameObject hintMenu;
    public Button hintMenuButton;

    public GameObject hintDisplay;

    public GameObject hintButtonPrefab;
    public RectTransform hintRectTransform;
    public TextMeshProUGUI hintTitle;
    public TextMeshProUGUI hintContent;
    public Image hintImage;

    private HintEntry recentHint;
    #endregion

    #region entries
    [Header("Entries")]
    public GameObject entryMenu;
    public Button entryMenuButton;

    public GameObject entryDisplay;

    public GameObject entryButtonPrefab;

    public RectTransform entryRectTransform;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI dateText;
    public TextMeshProUGUI contentText;
    public TextMeshProUGUI authorText;

    private JournalEntry recentEntry;
    #endregion

    #region code

    private void OnEnable()
    {
        ControlsManager.instance.controls.TabletShortcuts.Journal.performed += context => OpenRecentEntry();
    }

    private void OnDisable()
    {
        ControlsManager.instance.controls.TabletShortcuts.Journal.performed -= context => OpenRecentEntry();
    }
    /// <summary>
    /// opens the most recently acquired entry or hint
    /// </summary>
    private void OpenRecentEntry()
    {
        if (recentEntry != null)
        {
            OpenEntry(recentEntry);
        }
        else if (recentHint != null)
        {
            OpenHint(recentHint);
        }
        StartCoroutine(ClearRecent());
    }
    /// <summary>
    /// adds an entry to the end of the list, this method does not sort it
    /// </summary>
    /// <param name="entryToAdd">This is the journal entry being added</param>
    public void AppendEntry(JournalEntry entryToAdd)
    {
        journalEntries.Add(entryToAdd);
        GameObject buttonInstance = Instantiate(entryButtonPrefab, entryMenu.transform);
        EntryButton newButton = buttonInstance.GetComponent<EntryButton>();
        newButton.entryToPrint = entryToAdd;
        recentEntry = entryToAdd;
        recentHint = null;
    }

    /// <summary>
    /// Adds a hint to the end of the list
    /// </summary>
    /// <param name="entryToAdd">This is the hint being added</param>
    public void AppendHint(HintEntry entryToAdd)
    {
        hintEntries.Add(entryToAdd);
        GameObject buttonInstance = Instantiate(hintButtonPrefab, hintMenu.transform);
        HintButton newButton = buttonInstance.GetComponent<HintButton>();
        newButton.hintEntry = entryToAdd;
        recentHint = entryToAdd;
        recentEntry = null;
    }

    /// <summary>
    /// This prints the selected entry onto the journal page
    /// </summary>
    /// <param name="entryToOpen">This is the journal entry to be displayed</param>
    public void OpenEntry(JournalEntry entryToOpen)
    {
        hintDisplay.SetActive(false);
        entryDisplay.SetActive(true);
        titleText.text = entryToOpen.title;
        dateText.text = entryToOpen.dateStringDDMMYYYY;
        contentText.text = entryToOpen.entry;
        authorText.text = entryToOpen.author;
        LayoutRebuilder.ForceRebuildLayoutImmediate(entryRectTransform);
    }

    /// <summary>
    /// Displays the selected hint onto the journal page
    /// </summary>
    /// <param name="entryToOpen">This is the hint being opened</param>
    public void OpenHint(HintEntry entryToOpen)
    {
        hintDisplay.SetActive(true);
        entryDisplay.SetActive(false);
        hintTitle.text = entryToOpen.hintTitle;
        hintContent.text = entryToOpen.hintContent;
        LayoutRebuilder.ForceRebuildLayoutImmediate(hintRectTransform);
    }


    /// <summary>
    /// Displays the hint menu, and makes its button unusable
    /// </summary>
    public void DisplayHintButtons()
    {
        hintMenuButton.interactable = false;
        entryMenuButton.interactable = true;
        hintMenu.SetActive(true);
        entryMenu.SetActive(false);

    }

    /// <summary>
    /// Displays the entry menu, and makes its button unusable
    /// </summary>
    public void DisplayEntriesButtons()
    {
        hintMenuButton.interactable = true;
        entryMenuButton.interactable = false;
        hintMenu.SetActive(false);
        entryMenu.SetActive(true);
    }

    IEnumerator ClearRecent()
    {
        yield return new WaitForSeconds(timeToClear);
        recentHint = null;
        recentEntry = null;
    }
    #endregion
}
