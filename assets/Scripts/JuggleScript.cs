using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class JuggleScript : MonoBehaviour
{

    public static bool hasCollectedBall = false;
    SpriteRenderer b;
    Vector3 v;
    Vector3 t;
    float timer = 0f;


    private void Start()
    {
        b = GetComponent<SpriteRenderer>();
        v = new Vector3(0, 0, 0);

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            hasCollectedBall = true;
            Debug.Log("Collected!");
            t = new Vector3(b.transform.position.x, b.transform.position.y - 2, b.transform.position.z);
            Pause.isJester = true;
        }
    }

    private void Update()
    {
        if (hasCollectedBall)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.SmoothDamp(
                    b.transform.position,
                    t,
                    ref v,
                    0.1f,
                    2.5f
                );
            if (timer > 1.5f)
            {
                GetComponent<AudioSource>().volume = 0.7f;
                GetComponent<AudioSource>().Play();
                b.enabled = false;
                this.enabled = false;
            }
        }
    }
}

