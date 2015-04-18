using UnityEngine;
using System.Collections;

// https://forums.oculus.com/viewtopic.php?t=1648#p219052
// detects presence/absence and disconnection, but not reconnection?
public class CamChooser : MonoBehaviour
{
    public GameObject nonOVRCam;
    public GameObject ovrRig;
    private bool oculusActive = true;

    void Update()
    {
        if (oculusActive && !OVRManager.display.isPresent)
        {
            ovrRig.SetActive(false);
            nonOVRCam.SetActive(true);
        }
        if (!oculusActive && OVRManager.display.isPresent)
        {
            nonOVRCam.SetActive(false);
            ovrRig.SetActive(true);
        }
        oculusActive = OVRManager.display.isPresent;
    }
}