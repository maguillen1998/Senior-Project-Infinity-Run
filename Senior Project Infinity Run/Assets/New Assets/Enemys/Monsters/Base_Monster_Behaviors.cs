using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonster
{
    void Start();
    void TakeDamage(int damageAmount);
    void Die();
}

public abstract class Base_Monster_Behaviors : MonoBehaviour, IHitHandler
{
    public int MaxHealth = 1;
    public int CurrentHealth;

    public virtual void Start()
    {
        //Debug.Log("abstract start");    
        CurrentHealth = MaxHealth;
    }
    public virtual void GetHit(int damage)
    {
        HandleHit(damage);
    }
    public virtual void HandleHit(int damageAmount)
    {
        CurrentHealth -= damageAmount;
        Debug.Log(this.name +" got hit. HP= " + CurrentHealth);
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log(" Died and will be destroyed: " + gameObject.name);

        
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
