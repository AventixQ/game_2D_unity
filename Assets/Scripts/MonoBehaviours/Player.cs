using System.Collections;
using UnityEngine;

public class Player : Character
{
    public HitPoints hitPoints;

    public HealthBar healthBarPrefab;
    HealthBar healthBar;

    public Inventory inventoryPrefab;
    Inventory inventory;

    
    private void OnEnable()
    {
        ResetCharacter();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if collided with coin or heart
        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;
            if (hitObject != null)
            {
                //if false -> it will not be destroyed
                bool shouldDisappear = false;
                switch (hitObject.itemType) //checking if we can destroy it and add to health bar/inventory
                {
                    case Item.ItemType.COIN:
                        shouldDisappear = inventory.AddItem(hitObject);
                        break;
                    case Item.ItemType.HEALTH:
                        shouldDisappear = AdjustHitPoints(hitObject.quantity);
                        break;
                    default:
                        break;
                }
                //deactivate object (if needed)
                if (shouldDisappear)
                {
                    collision.gameObject.SetActive(false);
                }
            }
        }
    }

    //adjust hit point to player health bar
    public bool AdjustHitPoints(int amount)
    {
        //if HP > HP given by heart -> return false, so heart will not disappear
        if (hitPoints.value < maxHitPoints)
        {
            hitPoints.value = hitPoints.value + amount;
            print("Nowe punkty: " + amount + ". Razem: " + hitPoints.value);
            return true;
        }
        return false;
    }

    //coroutine of handling damage to the player
    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        while (true)
        {
            //flickering effect while taking damage
            StartCoroutine(FlickerCharacter());
            //substracting HP of player
            hitPoints.value = hitPoints.value - damage;
            //if player has not enough HP -> kill
            if (hitPoints.value <= float.Epsilon)
            {
                KillCharacter();
                break;
            }
            //if ... wait for a specified interval
            if (interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }

    //ovveride function to kill player character
    public override void KillCharacter()
    {
        //run base method from class Character
        base.KillCharacter();
        //destroy healthbar and inventory
        Destroy(healthBar.gameObject);
        Destroy(inventory.gameObject);
    }

    //reset player, healthbar, inventory
    public override void ResetCharacter()
    {
        inventory = Instantiate(inventoryPrefab);
        healthBar = Instantiate(healthBarPrefab);
        healthBar.character = this;
        hitPoints.value = startingHitPoints;

        GetComponent<SpriteRenderer>().color = Color.white;
    }
}