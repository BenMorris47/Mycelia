using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EmailItemSlot : MonoBehaviour
{
    public Email reference;
    public GameObject emailFromText;
    public GameObject emailSubjectText;
    public GameObject emailIcon;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(Click);
    }

    /// <summary>
    /// This will setup the buttons on the EmailItemSlot prefab to allow for the particular email to be shown when clicking on the ItemSlot
    /// </summary>
    private void Click()
    {
        EmailManager.instance.uiManager.OpenEmail(reference);
    }
}
