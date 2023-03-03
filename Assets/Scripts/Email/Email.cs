using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Email/New Email")]
public class Email : ScriptableObject
{
    public string emailFrom;
    public string emailSubject;
    [TextArea] public string emailContents;

    public Email() //Inital Setup Email to make it easier to test
    {
        emailFrom = "Test@Email.com";
        emailSubject = "Test Subject Here";
        emailContents = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam venenatis eget velit id viverra. In maximus massa ac nibh placerat, eget mollis est ornare. Ut et cursus purus, eget semper augue. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. In at ante porta, condimentum velit quis, pulvinar turpis. Quisque posuere sem ante, quis dapibus odio molestie id. Nam eros lorem, molestie vitae quam ut, blandit fringilla leo.";
    }
}
