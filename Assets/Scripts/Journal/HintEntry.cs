using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[CreateAssetMenu(fileName = "Hint", menuName = "Journal/New Hint")]
public class HintEntry : ScriptableObject
{
    public string hintTitle;
    public string hintContent;
    public Image hintImage;

}
