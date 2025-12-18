using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int health;
    public float cooldown = 0;
    public Animator animator;
    public float damageCoolDown;
    protected virtual void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
    }
    public void DamageMe()
    {
        if (cooldown <= 0)
        {
            health -= 1;
            cooldown = damageCoolDown;
            animator.SetTrigger("Damaged");
        }
    }
}
