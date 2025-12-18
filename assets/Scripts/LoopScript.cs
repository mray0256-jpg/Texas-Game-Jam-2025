using JetBrains.Annotations;
using UnityEngine;
using System.Collections.Generic;

public class Loop
{
    public enum State { One, Two, Three, Four, Five }
}

public class LoopScript : MonoBehaviour
{
    private float Timer = 60 * 15; //5 represents amount of minutes the timer lasts.
    public int loopCounter = 1;
    public GameObject flag;
    public GameObject player;
    public bool hasTouched = false;
    public bool completeQuest = false;
    public static Loop.State CurrentState { get; private set; } = Loop.State.One;
    public static event System.Action<Loop.State> OnLoopChanged;
    public ParticleSystem ps;

    public List<GameObject> levels;

    Collider2D playerBox;
    Collider2D flagBox;
    //public GameObject[] NPCs;//array of NPC gameobjects. use these to refrence the specific NPCs for loop sequencing.
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       playerBox = player.GetComponent<Collider2D>();
       flagBox = flag.GetComponent<Collider2D>();
       CurrentState = Loop.State.One;
    }

    void Quigame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if(Timer < 0)
        {
            Pause.GameOverScreen();
            Invoke("Quigame", 5f);
        }
        //Debug.Log(string.Format("{0:00}:{1:00}", minutes, seconds)); //Logs the time left on the timer


        if (CurrentState == Loop.State.Four)
        {
            if (JuggleScript.hasCollectedBall == true)
            {
                completeQuest = true;
            }
            else completeQuest = false;
        }
        else if (CurrentState == Loop.State.Three)
        {
            if (ChefScript.Complete == true)
            {
                completeQuest = true;
            }
            else completeQuest = false;
        }
        else completeQuest = true;


        if (playerBox.IsTouching(flagBox) && !hasTouched) //Checks if player is in the same spot as the flag
        {
            GetComponent<AudioSource>().volume = 0.7f;
            GetComponent<AudioSource>().Play();
            ps.Play();
            hasTouched = true;
            Player_Health.health = 0;
            //player.transform.position = new Vector2(0, 0);

            if (completeQuest)
            {
                if (loopCounter < 5) loopCounter++;
                for (int i = 0; i < levels.Count; i++)
                {
                    if (loopCounter == i + 1)
                    {
                        levels[i].SetActive(true);
                    }
                    else
                    {
                        levels[i].SetActive(false);
                    }
                }
            }
        }
        
        if (Player_Move.playerTrans.position.x < 10) hasTouched = false;

        switch(loopCounter)
        {
            case 1:
                CurrentState = Loop.State.One;
                break;
            case 2:
                CurrentState = Loop.State.Two;
                break;
            case 3:
                CurrentState = Loop.State.Three;
                break;
            case 4:
                CurrentState = Loop.State.Four;
                break;
            case 5:
                CurrentState = Loop.State.Five;
                break;
        }
    }
}
