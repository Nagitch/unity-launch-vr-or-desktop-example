using System.Collections;
using UnityEngine;
using UnityEngine.XR.Management;

public class UnityLaunchVrOrDesktopExample : MonoBehaviour
{
    [SerializeField] private bool isVRMode = false;
    [SerializeField] private GameObject xrDeviceSimulatorPrefab;

    private GameObject xrDeviceSimulatorInstance = null;
    
    void Start()
    {
        if (isVRMode)
        {
            // run as VR
            StartCoroutine(StartXR());
        } else {
            // run as VR Simulator (Desktop alternative)
            if (xrDeviceSimulatorPrefab != null)
            {
                xrDeviceSimulatorInstance = Instantiate(xrDeviceSimulatorPrefab);
                Debug.Log("XR Device Simulator instantiated.");
            }
        }
        
    }

    IEnumerator StartXR()
    {
        Debug.Log("Initializing XR...");
        yield return XRGeneralSettings.Instance.Manager.InitializeLoader();

        if (XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.LogError("Initializing XR Failed.");
        }
        else
        {
            XRGeneralSettings.Instance.Manager.StartSubsystems();
            Debug.Log("Starting XR...");
        }
    }
}
