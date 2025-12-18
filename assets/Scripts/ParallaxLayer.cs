using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float startPos;
    private float camStartPos;
    public float parallaxAmnt;
    public bool isLooping;
    public float loopLength;
    void Start()
    {
        startPos = transform.position.x;
        camStartPos = CameraMovement.cameraPos.position.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = CameraMovement.cameraPos.position.x * (1 - parallaxAmnt);

        transform.position = new Vector3(startPos - (camStartPos - CameraMovement.cameraPos.position.x) * parallaxAmnt, transform.position.y, transform.position.z);

        if (isLooping)
        {
            if (temp > startPos + loopLength / 2) startPos += loopLength;
            else if (temp < startPos - loopLength / 2) startPos -= loopLength;
        }        
    }
}
