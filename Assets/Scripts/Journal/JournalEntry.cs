using System.Collections;
using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
[CreateAssetMenu(fileName = "Journal Entry", menuName = "Journal/New Entry")]
public class JournalEntry : ScriptableObject
{
    //this is the string which stores date and time in dd/mm/yyyy
    public string dateStringDDMMYYYY;
    //this stores the name of the author of the journal entry
    public string author;
    //this stores the title of the journal entry
    public string title;
    //this stores the actual content of the entry
    [TextArea]public string entry;

}
