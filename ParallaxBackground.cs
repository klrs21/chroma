using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Transform[] backgrounds; // Array of all backgrounds and foregrounds to be parallaxed
    private float[] parallaxScales; //proportion of camera's movements to move backgrounds by
    public float smoothing = 1f; //how smooth the parallax to be, make sure to be > 0

    private Transform cam; // reference to main camera's transform
    private Vector3 previousCamPos; // store position of camera in previous frame

    void Awake() // called before Start(). Great for references
    {
        // set up camera reference
        cam = Camera.main.transform;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //previous frame had the current frame's camera position
        previousCamPos = cam.position;

        //assigning corresponding parallax scales
        parallaxScales = new float[backgrounds.Length];
        for(int i = 0; i < backgrounds.Length; i++)
        {
            parallaxScales[i] = backgrounds[i].position.z*-1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float parallax = (previousCamPos.x - cam.position.x)* parallaxScales[i];

            //set a target x position which is the current pos + parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            //create target position which is backgrounds current pos with its target pos
            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            //fade between current pos and target pos using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, backgroundTargetPos, smoothing * Time.deltaTime);
        }

        //set prev cam pos to camera position at the end of frame
        previousCamPos = cam.position;
    }
}
