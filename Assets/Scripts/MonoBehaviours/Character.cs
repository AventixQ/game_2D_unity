using System.Collections;
using UnityEngine;

//abstract base class for character objects
public abstract class Character : MonoBehaviour
{
    
    public float maxHitPoints;
    public float startingHitPoints;

    //default behaviour for destroing character
    public virtual void KillCharacter()
    {
        Destroy(gameObject);
    }

    //abstract functions implemented in derived classes
    public abstract void ResetCharacter();
    public abstract IEnumerator DamageCharacter(int damage, float interval);

    //default behaviour to make the chararacter flicker
    public virtual IEnumerator FlickerCharacter()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}