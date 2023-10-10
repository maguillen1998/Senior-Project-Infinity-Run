using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMonster
{
    void Start();
    void TakeDamage(int damageAmount);
    void Die();
}

public abstract class Base_Monster_Behaviors : MonoBehaviour, IMonster
{
    public int MaxHealth;
    public int CurrentHealth;

    public virtual void Start()
    {
        Debug.Log("abstract start");
        MaxHealth = 10;       
        CurrentHealth = MaxHealth;
    }
    public virtual void GetHit(int damage)
    {
        TakeDamage(damage);
    }
    public virtual void TakeDamage(int damageAmount)
    {
        CurrentHealth -= damageAmount;
        Debug.Log("I got hit. HP= " + CurrentHealth);
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log("I Died and will be destroyed: " + gameObject.name);


        gameObject.SetActive(false);
        Destroy(gameObject);


    }
}
