using TMPro;
using UnityEngine;

public class CrownScript : MonoBehaviour
{
    public GameObject Bird;
    private Transform spot;
    private Vector3 velocity = new Vector3(0, 0, 0);
    private float timer = 0f;
    private Vector3 t;
    public GameObject FinalBoss;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spot = Bird.transform;
        t = new Vector3(transform.position.x, transform.position.y - 15, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Bird == null)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.SmoothDamp(
                    transform.position,
                    t,
                    ref velocity,
                    0.1f,
                    2.5f);
            if (timer > 1.5f)
            {
                GetComponent<SpriteRenderer>().enabled = false;
                FinalBoss.SetActive(true);
                
            }
        }
        else transform.position = Vector3.SmoothDamp(transform.position, new Vector3(spot.position.x, spot.position.y + 0.6f, spot.position.z), ref velocity, 0.1f);
    }
}
