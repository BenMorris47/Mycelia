using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrative4Triggerer : MonoBehaviour
{
    public GameObject Narrative4Trigger;
    // Start is called before the first frame update
    void Start()
    {
        Narrative4Trigger.SetActive(false);
    }

    private void OnDestroy()
    {
        Narrative4Trigger.SetActive(true);
    }
}
