using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmailUIManager : MonoBehaviour
{
    [Header("Prefab")]
    public GameObject emailPreviewPrefab;

    [Header("Content On The Scroll View")]
    public GameObject scrollViewContent;

    [Header("Opened Email Segment")]
    public TextMeshProUGUI openFromEmail;
    public TextMeshProUGUI openSubjectEmail;
    public TextMeshProUGUI openContentEmail;

    List<GameObject> itemSlots;
    EmailManager manager;


    private void OnEnable()
    {
        manager = EmailManager.instance;
        itemSlots = new List<GameObject>();
    }

    public void EmailPreviewSetup()
    {
        if (itemSlots != null) //Nullify it when setting it all up (When we open the email menu) This also saves the emails overlapping and adding each and everytime we open it
        {
            foreach (var item in itemSlots)
            {
                Destroy(item);
            }
            itemSlots = new List<GameObject>();
        }

        foreach (Email email in manager.Inbox)
        {
            GameObject tempObj = GameObject.Instantiate(emailPreviewPrefab, scrollViewContent.transform);

            EmailItemSlot tempSlot = tempObj.GetComponent<EmailItemSlot>();
            tempSlot.reference = email;

            tempSlot.emailIcon.GetComponent<Image>().sprite = manager.opened;
            tempSlot.emailFromText.GetComponent<TextMeshProUGUI>().text = email.emailFrom;
            tempSlot.emailSubjectText.GetComponent<TextMeshProUGUI>().text = email.emailSubject;

            itemSlots.Add(tempObj);
        }

        ResetEmailOpen();
    }

    private void ResetEmailOpen()
    {
        openFromEmail.text = null;
        openContentEmail.text = null;
        openSubjectEmail.text = null;
    }

    /// <summary>
    /// This sorts out opening the email and placing it within the opened email area of the UI
    /// </summary>
    /// <param name="emailToOpen"></param>
    public void OpenEmail(Email emailToOpen)
    {
        openFromEmail.text = emailToOpen.emailFrom;
        openSubjectEmail.text = emailToOpen.emailSubject;
        openContentEmail.text = emailToOpen.emailContents;
    }
}
