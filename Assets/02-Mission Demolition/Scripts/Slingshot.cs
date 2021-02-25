using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slingshot : MonoBehaviour
{
    public GameObject launcher;

    private bool isAiming;
    private float sphereRadius;

    public GameObject prefabprojectile;
    public GameObject activeprojectile;
    public float speedMultiplier = 10.0f;

    private int shots = 0;
    public Text scoreText;

    void Start()
    {
        //launcher = transform.Find("launcher").gameObject;
        launcher.SetActive(false);
        isAiming = false;
        sphereRadius = this.GetComponent<SphereCollider>().radius;
        activeprojectile = null;

        scoreText.text = "Shots Fired:" + shots;
    }

    void OnMouseEnter()
    {
        launcher.SetActive(true);

    }

    void OnMouseExit()
    {
        launcher.SetActive(false);
    }

    void OnMouseDown()
    {
        isAiming = true;
        activeprojectile = Instantiate(prefabprojectile) as GameObject;
        activeprojectile.transform.position = launcher.transform.position;
        activeprojectile.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Update()
    {
        if (!isAiming)
            return;

        Vector3 moursePositionScreen = Input.mousePosition;
        moursePositionScreen.z = -Camera.main.transform.position.z;
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(moursePositionScreen);
        Vector3 dragVector = mousePositionWorld - launcher.transform.position;

        if(dragVector.magnitude > sphereRadius)
        {
            dragVector.Normalize();
            dragVector *= sphereRadius;
        }
        activeprojectile.transform.position = launcher.transform.position + dragVector;

        if (Input.GetMouseButtonUp(0))
        {
            isAiming = false;
            Rigidbody rb = activeprojectile.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.velocity = -dragVector * speedMultiplier;

            GameObject cam = GameObject.Find("MainCamera");
            cam.GetComponent<FollowTarget>().targetObject = activeprojectile;

            shots += 1;
            scoreText.text = "Shots Fired:" + shots;
        }
    }
}
