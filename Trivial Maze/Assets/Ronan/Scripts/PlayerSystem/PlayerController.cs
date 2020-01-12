using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera SinglePlayerCamera;
    public Camera SplitCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchToSingleCamera()
    {
        SplitCamera.enabled = false;
        SinglePlayerCamera.enabled = true;
    }

    public void SwitchToSplitCamera(float viewportX)
    {
        SinglePlayerCamera.enabled = false;
        SplitCamera.enabled = true;

        SplitCamera.rect = new Rect(viewportX, SplitCamera.rect.y, SplitCamera.rect.width, SplitCamera.rect.height);
    }
}
