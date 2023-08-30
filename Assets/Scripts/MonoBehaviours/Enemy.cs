using System.Collections;
using UnityEngine;

public class Enemy : Character
{
    public int damageStrength; 
    Coroutine damageCoroutine;

    float hitPoints;

    //override DamageCharacter function
    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        while (true)
        {
            //flickering effect when taking damage
            StartCoroutine(FlickerCharacter());
            hitPoints = hitPoints - damage;     //reduce hit points
            //if player has not enough HP -> kill
            if (hitPoints <= float.Epsilon)
            {
                KillCharacter();
                break;
            }
            if (interval > float.Epsilon) //if ... wait for specified interval
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }

    public override void ResetCharacter()
    {
        hitPoints = startingHitPoints;
    }

    private void OnEnable()
    {
        ResetCharacter();
    }

    //when collision with player -> damage player by 10 points
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            if (damageCoroutine == null)
            {
                damageCoroutine = StartCoroutine(player.DamageCharacter(damageStrength, 1.0f));
            }
        }
    }

    //stop damage
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
                damageCoroutine = null;
            }
        }
    }
}