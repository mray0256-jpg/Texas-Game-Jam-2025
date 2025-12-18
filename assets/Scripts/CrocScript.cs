using UnityEngine;
using System.Collections;

public class CrocScript : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int detectionRadiusCroc = 3;
    private int loseDetectionCroc = 4;
    private float attackDetectionCroc = 2;
    private float crocSpeed = 2.1f;
    private Vector3 Vel = Vector3.zero;
    private Vector3 homePos;
    float idlingx;
    bool isIdling = false;
    float arbTimer = 0;
    float timer = 0;
    private Collider2D crocBox;
    Vector3 playerLocation;

    enum State { Idle, Chasing, Returning, Attacking }
    State state = State.Idle;


    void Start()
    {
        homePos = transform.position;
        crocBox = GetComponent<Collider2D>();
    }

    public void idling()
    {
        if (!isIdling)
        {
            InvokeRepeating("IdleMovement", 1f, 5f);
            isIdling = true;
        }
    }


    public void IdleMovement()
    {
        // Debug.Log("Idling!");
        if (isIdling) idlingx = Random.Range(-1f, 1f);
    }




    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        animator.SetInteger("State", (int)state);
        playerLocation = new Vector3(Player_Move.playerTrans.position.x, transform.position.y, 0f);
        float d = Vector2.Distance(playerLocation, transform.position);

        transform.localScale = new Vector3(-Mathf.Sign((playerLocation - transform.position).x), 1, 1);


        switch (state)
        {
            case State.Idle:
                if (d <= detectionRadiusCroc) state = State.Chasing;
                break;

            case State.Chasing:
                timer += Time.deltaTime;
                //Debug.Log(timer);
                if (d >= loseDetectionCroc) state = State.Returning;
                if (d <= attackDetectionCroc && timer > 3)
                {
                    state = State.Attacking;
                    timer = 0;
                }
                break;

            case State.Returning:
                if (d <= detectionRadiusCroc)
                {
                    state = State.Chasing;
                    break;
                }
                if (transform.position == homePos) state = State.Idle;
                break;

            case State.Attacking:
                if (d > loseDetectionCroc) state = State.Returning;
                break;

        }
        //Debug.Log(state);
        if (state == State.Idle)
        {
            idling();
            MoveTowards(new Vector3(homePos.x + idlingx, homePos.y), 0.0f, crocSpeed);
        }
        if (state == State.Chasing)
        {
            isIdling = false;
            MoveTowards(playerLocation, 0.1f, crocSpeed);
        }
        if (state == State.Returning)
        {
            MoveTowards(homePos, 0.2f, crocSpeed);
            isIdling = false;
        }
        if (state == State.Attacking)
        {

            isIdling = false;
            arbTimer += Time.deltaTime;
            if (arbTimer > 0.5)
            {
                MoveTowards(playerLocation, 0.1f, crocSpeed * 4);
                if (arbTimer > 1.25)
                {
                    arbTimer = 0;
                    state = State.Chasing;
                }
            }
        }
        if (health <= 0)
        {
            GetComponent<AudioSource>().volume = 0.7f;
            GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
            
        }
    }


    void MoveTowards(Vector3 target, float smoothTime, float maxSpeed)
    {
        target.z = transform.position.z; // keep current Z
        transform.position = Vector3.SmoothDamp(
            transform.position,
            target,
            ref Vel,
            smoothTime,
            maxSpeed
        );
    }
}

