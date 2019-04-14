using UnityEngine;
using System.Collections;

public class CollisionDamage : MonoBehaviour
{
    public LevelManager LM;

    protected ContactFilter2D contactFilter;

    Collider m_Collider, m_Collider2;

    void OnCollisionEnter2D(Collision2D col)
    {
        //When Object collides with "Enemey" Object
        if(col.gameObject.tag.Equals("Enemy") || col.gameObject.tag.Equals("Enemy Bullet"))
        {
            LM.GetComponent<LevelManager>().current_life --;
        }

        //When Shadow collides with White walls
        if(gameObject.tag.Equals("Shadow"))
        {
            if(col.gameObject.layer == 10)
            {
                LM.GetComponent<LevelManager>().current_life --;
            }
        }
    }

    void Start()
    {
        m_Collider = GetComponent<Collider>();
        //Player won't collide with Shadow
        Physics2D.IgnoreLayerCollision(8,9);
        //Player won't collide with White Blocks
        Physics2D.IgnoreLayerCollision(8,10);
        //Shadow won't collide with Shadow Blocks
        Physics2D.IgnoreLayerCollision(9,11);

        //Moveable objects don't block moving enemies
        Physics2D.IgnoreLayerCollision(12,13);

        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    void Update()
    {
        /* 
        if(m_Collider.bounds.Intersects(GameObject.))
        {
            LM.GetComponent<LevelManager>().current_life --;
        }*/
    }
}