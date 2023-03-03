using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;
public class EmailManager : MonoBehaviour
{
    [SerializeField]List<Email> inbox;
    public static EmailManager instance;
    public EmailUIManager uiManager;

    [Header("New Email GameObject")]
    public GameObject emailBackground;
    public float decayTime;

    TextMeshProUGUI emailText;
    [Header("Sprites")]
    public Sprite opened;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;

        emailText = emailBackground.GetComponentInChildren<TextMeshProUGUI>();
    }

    public List<Email> Inbox
    {
        get { return inbox; }
    }

    /// <summary>
    /// This will send an email to the Inbox
    /// </summary>
    /// <param name="emailToSend">The email to be sent</param>
    public void SendEmail(Email emailToSend)
    {
        StartCoroutine(DecayTime(emailToSend, decayTime));
        if (!inbox.Contains(emailToSend))
        {
            //Insert sound here
            inbox.Add(emailToSend);
        }
    }

    /// <summary>
    /// This will delete an email from the Inbox
    /// </summary>
    /// <param name="emailToDelete">The email you wish to delete</param>
    public void DeleteEmail(Email emailToDelete)
    {
        if (inbox.Contains(emailToDelete))
        {
            inbox.Remove(emailToDelete);
        }
    }

    [ContextMenu("Send Email")]
    private void AddEmailToInboxDevStyle()
    {
        SendEmail(new Email());
    }

    private IEnumerator DecayTime(Email sentEmail, float decayTime)
    {
        emailBackground.SetActive(true);
        var bindings = ControlsManager.instance.controls.TabletShortcuts.Email.bindings;
        emailText.text = $"{sentEmail.emailSubject}\n Press {bindings[0].path.ToUpper()[bindings[0].path.Length-1]} to open";
        yield return new WaitForSeconds(decayTime);
        emailBackground.SetActive(false);
    }
}
