using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.XR;


public class GameManager : MonoBehaviour
{
    private GameObject mainCamera;
    private GameObject menu;
    private bool isVr;

    public GameObject cameraPC;
    public GameObject cameraVR;
    public GameObject canvasPC;
    public GameObject canvasVR;
    public GameObject eventSystemPC;
    public GameObject eventSystemVR;



    private Rigidbody grabbedObject;
    private Vector3 offset;
    private float zDistance;

    private bool M=true;

    void Start()
    {
        if (IsVRMode(PlayerPrefs.GetInt("isVR")))
        {
            //istanzia la camera e mettila in mainCamera
            mainCamera = GameObject.Instantiate(cameraVR, new Vector3(2, 1, 0), Quaternion.identity);
            //metti il canva del menu su Menu
            menu = GameObject.Instantiate(canvasVR, new Vector3(0, 1, 6), Quaternion.identity);
            GameObject.Instantiate(eventSystemVR);
        }
        else
        {
            //istanzia la camera e mettila in mainCamera
            mainCamera = GameObject.Instantiate(cameraPC, new Vector3(0, 2, 0), Quaternion.identity);
            //metti il canva del menu su Menu
            menu = GameObject.Instantiate(canvasPC);
            GameObject.Instantiate(eventSystemPC);
        }
    }

    private bool IsVRMode(int i)
    {
        if (i == 0)
        {
            isVr = false;
            return isVr;
        }
        else
        {
            isVr = true;
            return isVr;
        }
    }


    void Update()
    {
        if (!isVr)
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = mainCamera.GetComponentInChildren<Camera>().ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Button")))
                {
                    Debug.Log("BottonePremuto");
                    hit.collider.GetComponent<Button>().onClick.Invoke();
                }
            }
        }
    }


}
