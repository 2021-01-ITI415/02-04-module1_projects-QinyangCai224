using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Apple : MonoBehaviour
{ 
    [Header("Set in Inspector")]
    public static float bottomY = -20f;
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            // Get a reference to the ApplePick
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            // Call the public AppleDestroyed()
            apScript.AppleDestroyed();
        }
    }
}