using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class killcount : MonoBehaviour
{
    public Text KillCount;
    public string count;
    // Start is called before the first frame update
    void Start()
    {
        KillCount.text = "3";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
