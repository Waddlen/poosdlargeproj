using UnityEngine;
using System.Collections;

public class CollisionDamage : MonoBehaviour
{
    public LevelManager LM;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Enemy"))
        {
            LM.current_life --;
        }
    }
}