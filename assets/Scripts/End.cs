using JetBrains.Annotations;
using UnityEngine;

public class End : MonoBehaviour
{
    private Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("IsRunning", false);
    }

// Update is called once per frame
void Update()
    {
        if (animator.GetBool("IsRunning") && animator.GetCurrentAnimatorStateInfo(0).IsName("Human") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        Pause.ActivateWinScreen();
        Invoke("Quitgame", 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("IsRunning", true);
    
    }

    public void Quitgame()
    {
        Application.Quit();
    }

}
