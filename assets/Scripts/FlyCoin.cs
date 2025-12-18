using UnityEngine;

public class FlyCoin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public ParticleSystem ps;
    private Vector2 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        startPos = new Vector2(startPos.x += Random.Range(-0.2f, 0.2f), startPos.y += Random.Range(-0.2f, 0.2f));
    }
    void OnTriggerEnter(Collider collider)
    {
        ps.Play();
        Destroy(this);
    }
}
