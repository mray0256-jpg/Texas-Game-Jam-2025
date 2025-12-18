using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class IngredientScript : MonoBehaviour
{

    public bool hasCollected1 = false;
    public GameObject child;
    SpriteRenderer r;
    SpriteRenderer g;
    Vector3 v;
    Vector3 t;
    float timer = 0f;
    AudioSource music;


    private void Start()
    {
        r = GetComponent<SpriteRenderer>();
        g = child.GetComponent<SpriteRenderer>();
        g.enabled = false;
        v = new Vector3(0, 0, 0);

    }
    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Player")
        {
            hasCollected1 = true;
            r.enabled = false;
            g.enabled = true;
            t = new Vector3(g.transform.position.x, g.transform.position.y + 5, g.transform.position.z);
            //t = new Vector3(0, 5,0);
            music = GetComponent<AudioSource>();
            music.volume = 1f;
            music.Play();
            GetComponent<ParticleSystem>().Stop();
        }

    }

    private void Update()
    {
        if (hasCollected1)
        {
            timer += Time.deltaTime;
            transform.position = Vector3.SmoothDamp(
                    g.transform.position,
                    t,
                    ref v,
                    0.1f,
                    2.5f
                );
            if (timer > 2.5f)
            {
                g.enabled = false;
            }
        }
    }
}
