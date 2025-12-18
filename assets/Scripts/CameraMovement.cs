using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static Transform cameraPos;
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    public Vector3 offset;
    public Vector3 dialogueOffset;
    private static bool isTalking;

    void Awake()
    {
        cameraPos = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cameraPos = transform;

        Vector3 targetPosition = Vector3.zero;
        if (isTalking)
        {
            targetPosition = Player_Move.playerTrans.position + dialogueOffset;
        }
        else
        {
            targetPosition = Player_Move.playerTrans.position;
        }

        transform.position = Vector3.SmoothDamp(transform.position + offset, new Vector3(Mathf.Clamp(targetPosition.x, -2.5f, 115), targetPosition.y, targetPosition.z) + offset, ref velocity, smoothTime);
    }
    public static void isDialogue(bool b)
    {
        isTalking = b;
    }
}
