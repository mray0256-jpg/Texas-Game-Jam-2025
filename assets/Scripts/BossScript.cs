using Unity.VisualScripting;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public GameObject Player;
    public CameraMovement Camera;
    public GameObject CameraPos;
    public GameObject Wiz;
    public GameObject room;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player.transform.position = new Vector2(Wiz.transform.position.x, Wiz.transform.position.y);
        Player_Move.PausePlayerMovement();
        Camera.enabled = false;
        CameraPos.transform.position = new Vector3(room.transform.position.x, room.transform.position.y, -10);
        //Edit
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
