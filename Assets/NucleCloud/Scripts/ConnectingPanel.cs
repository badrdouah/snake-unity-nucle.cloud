using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;

public class ConnectingPanel : MonoBehaviour
{

    private int count = 0;
    private Text textConnecting;
    // Start is called before the first frame update
    void Start()
    {
          textConnecting = transform.Find("Connecting").GetComponent<Text>();
        InvokeRepeating("Connecting",0,0.5f);
    }


    private void Connecting()
    {
        count++;
        if (count >= 4) textConnecting.text = "Connecting";
        textConnecting.text += ".";
    }
    // Update is called once per frame
   // void Update()
   // {
   //     t += Time.deltaTime;
   //     if (t >= 0.5f)
   //     {
   //         textConnecting.text += ".";
   //         t = 0;
   //     }
   // }
}
