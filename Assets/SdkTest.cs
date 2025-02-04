using Snapyr;
using Snapyr.Types;
using UnityEngine;
using System.Collections.Generic;

public class SdkTest : MonoBehaviour
{
    int callnum = 0;
    int callnumi = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(">>>>>>> Starting Snapyr SDK Test <<<<<<<");
        SnapyrWrapper.I.Initialize("4IIPRssIBRGzcQdkrYJhMtcXwB4a6AKf",
            new SnapyrConfiguration.Builder()
                .trackApplicationLifecycleEvents(true)
                .recordScreenViews(true)
                .build()
        );
        SnapyrUnity.Instance.onSnapyrAction += snapyrActionReceived;
    }

    void snapyrActionReceived(string data) {
       Debug.Log("Data Received " + data);
     }


    public void handleIdentifyButtonClick()
    {
        Debug.Log("IDENTIFY CLICKED " + callnumi);
        if (callnumi == 0)
        {
            SnapyrWrapper.I.Identify("testevent0", new Traits().Put("name1", "value1"));
        }
        else if (callnumi == 1)
        {
            SnapyrWrapper.I.Identify("testevent1", new Traits().Put("name1", "value1").Put("name2", "value2"));
        }
        else
        {
            SnapyrWrapper.I.Identify("testevent" + callnumi, null);
        }

        callnumi++;
    }

    public void handleTrackButtonClick()
    {
        Debug.Log("Track CLICKED" + callnum);
        if (callnum == 0)
        {
            SnapyrWrapper.I.Track("testevent0", new Properties().Put("name1", "value1"));
        }
        else if (callnum == 1)
        {
            SnapyrWrapper.I.Track("testevent1", new Properties().Put("name1", "value1").Put("name2", "value2"));
        }
        else
        {
            SnapyrWrapper.I.Track("testevent" + callnum, null);
        }

        callnum++;
    }

    public void handleScreenButtonClick()
    {
        Debug.Log("Screen CLICKED");
        SnapyrWrapper.I.Screen("testscreen");
    }


    // Update is called once per frame
    void Update()
    {
    }
}
