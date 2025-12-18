using UnityEngine;

public class Collectible : MonoBehaviour
{

    public ParticleSystem ps;
    public Vector2 startPos;
    public float interval;
    public float buzzAmt = 0.2f;
    private float tempCnt;
    private bool isDestroyed = false;
    AudioSource music;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ps.Stop();
        startPos = transform.position;
    }

    void Update()
    {
        if (tempCnt >= interval)
        {
            transform.position = new Vector2(startPos.x + Random.Range(-buzzAmt, buzzAmt), startPos.y + Random.Range(-buzzAmt, buzzAmt));
            tempCnt = 0;
        }
        tempCnt += Time.deltaTime;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collect) {
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();

        if (collect.gameObject.tag == "Player" && !isDestroyed)
        {
            SetCounter.AddFlyCount();
            renderer.enabled = false;
            ps.Play();
            isDestroyed = true;

            music = GetComponent<AudioSource>();
            music.volume = 1f;
            music.Play();
        }
    }
}
