using UnityEngine;



public class MenuManager : MonoBehaviour
{
    private int isVR;

    public GameObject CanvasPC;
    public GameObject CameraPC;
    public GameObject VR;

    void Start()
    {
        if (SystemInfo.deviceType == DeviceType.Desktop)
        {
            isVR = 0;
            GameObject.Instantiate(CameraPC, new Vector3(0, 3, 0), Quaternion.identity);
            GameObject.Instantiate(CanvasPC).SetActive(true);
        }
        else
        {
            isVR = 1;
            GameObject.Instantiate(VR);
        }
        PlayerPrefs.SetInt("isVR", isVR);
    }
}
