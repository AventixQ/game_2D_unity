using UnityEngine;
using Cinemachine;

public class RPGCameraManager : MonoBehaviour
{
    //singleton instance
    public static RPGCameraManager sharedInstance = null;
    [HideInInspector]
    public CinemachineVirtualCamera virtualCamera;

    //is called when the script instance is being loaded
    void Awake()
    {
        if (sharedInstance != null && sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }
        //find a GameObject with the tag "VirtualCamera"
        GameObject vCamGameObject = GameObject.FindWithTag("VirtualCamera");
        //get the CinemachineVirtualCamera component attached to the found GameObject
        virtualCamera = vCamGameObject.GetComponent<CinemachineVirtualCamera>();
    }
}
