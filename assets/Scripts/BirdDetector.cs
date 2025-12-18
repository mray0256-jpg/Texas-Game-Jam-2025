using UnityEngine;
using System.Collections;

public class BirdDetector : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private int detectionRadiusBird = 5;
    private int loseDetectionBird = 6;
    private float attackDetectionBird = 3;
    public float birdSpeed = 3.0f;
    private Vector3 Vel = Vector3.zero;
    private Vector3 homePos;
    float idlingx, idlingy;
    bool isIdling = false;
    float arbTimer = 0;
    float timer = 0;
    float anotherTimer = 0;
    float gust = 0.3f;


    Vector3 playerLocation;
    
    

    enum State { Idle, Chasing, Returning, Attacking, Charging}
    State state = State.Idle;


    void Start()
    {
        homePos = transform.position;
    }

    public void idling()
    {
        if (!isIdling)
        {
            CancelInvoke("IdleMovement");
            InvokeRepeating("IdleMovement", 1f, 5f);
            isIdling = true;
        }
    }    


    public void IdleMovement()
    {
        // Debug.Log("Idling!");
        if (isIdling)
        {
            idlingx = Random.Range(-1f, 1f);
            idlingy = Random.Range(-1f, 1f);
        }
    }

    public void Flap()
    {
        if(anotherTimer < 1)
        {
            MoveTowards(new Vector3(transform.position.x, transform.position.y + gust, transform.position.z), 0.1f, 0.2f);
        }
        else
        {
            gust = -gust;
            anotherTimer = 0;
        }
    }



    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        animator.SetInteger("State", (int)state);
        anotherTimer += Time.deltaTime;
        Flap();
        playerLocation = new Vector3(Player_Move.playerTrans.transform.position.x, Player_Move.playerTrans.transform.position.y + 1f, 0f);
        float d = Vector2.Distance(playerLocation, transform.position);
        switch (state)
        {
            case State.Idle:
                if (d <= detectionRadiusBird) state = State.Chasing;
                break;

            case State.Chasing:
                timer += Time.deltaTime;
                //Debug.Log(timer);
                if (d >= loseDetectionBird) state = State.Returning;
                if (d <= attackDetectionBird && timer > 3)
                {
                    state = State.Charging;
                    timer = 0;
                }
                break;

            case State.Returning:
                if (d <= detectionRadiusBird)
                {
                    state = State.Chasing;
                    break;
                }
                if (transform.position == homePos) state = State.Idle;
                break;

            case State.Charging:
                if (d > loseDetectionBird) state = State.Returning;
                break;

        }
        if (state == State.Idle)
        {
            idling();
            MoveTowards(new Vector3(homePos.x + idlingx, homePos.y + idlingy), 0.1f, birdSpeed);
        }
        if (state == State.Chasing)
        {
            MoveTowards(playerLocation, 0.5f, birdSpeed*2);
            isIdling = false;
        }
        if (state == State.Returning)
        {
            MoveTowards(homePos, 0.2f, birdSpeed);
            isIdling = false;
        }
        if (state == State.Attacking)
        {

            isIdling = false;
            arbTimer += Time.deltaTime;
            
            MoveTowards(playerLocation, 0.1f, birdSpeed * 5);
            if (arbTimer > 1.8)
            {
                arbTimer = 0;
                state = State.Chasing;
            }
        }
        if (health <= 0)
        {
            GetComponent<AudioSource>().volume = 0.7f;
            GetComponent<AudioSource>().Play();
            Destroy(this.gameObject);
            
        }
        if (state == State.Charging)
        {
            isIdling = false;
            MoveTowards(-playerLocation, 0.1f, 0.7f);
            arbTimer += Time.deltaTime;
            if (arbTimer > 0.4)
            {
                arbTimer = 0;
                state = State.Attacking;
            }
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

