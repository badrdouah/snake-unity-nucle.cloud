using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class WaitingPanel : MonoBehaviour
{

    private int count = 0;
    private Text textWaiting;
    // Start is called before the first frame update
    void Start()
    {

        textWaiting = transform.Find("Wait").GetComponent<Text>();
        InvokeRepeating("Waiting",0,0.5f);
    }

    private void Waiting()
    {
        count++;
        if (count >= 4) textWaiting.text = "Please Wait";
        textWaiting.text += ".";
    }
}
