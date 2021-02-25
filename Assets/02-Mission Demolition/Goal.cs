using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal: MonoBehaviour
{
    public Text WinText;

    // Start is called before the first frame update
    void Start()
    {
        WinText.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "projectile")
        {
            WinText.enabled = true;

            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
