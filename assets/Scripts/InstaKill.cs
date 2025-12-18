using Unity.VisualScripting;
using UnityEngine;

public class InstaKill : MonoBehaviour
{
    public string whatTag;
    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Player" && whatTag == "Player")
        {
            Player_Health.health = 0;

        }
        else if (collider.gameObject.tag == "Enemy" && whatTag == "Enemy")
            collider.gameObject.GetComponent<Enemy>().DamageMe();
    }
}
