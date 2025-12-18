using Unity.VisualScripting;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    public string whatTag;
    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Player" && whatTag == "Player")
        {
            Player_Health.TakeDamage();
        }
        else if (collider.gameObject.tag == "Enemy" && whatTag == "Enemy")
            collider.gameObject.GetComponent<Enemy>().DamageMe();
    }
}
