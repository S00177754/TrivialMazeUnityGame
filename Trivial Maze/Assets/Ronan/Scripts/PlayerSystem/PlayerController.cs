using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera SinglePlayerCamera;
    public Camera SplitCamera;
    public TimerController timeController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Timer")
        {
            if(other.gameObject.GetComponent<TimerZone>().Type == ZoneType.Start)
            {
                timeController.StartTimer();
            }
            else if(other.gameObject.GetComponent<TimerZone>().Type == ZoneType.End)
            {
                timeController.StopTimer();
            }
        }
    }

    public void SwitchToSingleCamera()
    {
        SplitCamera.enabled = false;
        SinglePlayerCamera.enabled = true;
        gameObject.GetComponent<PlayerLineOfSight>().playerCamera = SinglePlayerCamera;
    }

    public void SwitchToSplitCamera(float viewportX)
    {
        SinglePlayerCamera.enabled = false;
        SplitCamera.enabled = true;

        SplitCamera.rect = new Rect(viewportX, SplitCamera.rect.y, SplitCamera.rect.width, SplitCamera.rect.height);

        gameObject.GetComponent<PlayerLineOfSight>().playerCamera = SplitCamera;

    }
}
