using UnityEngine;
using System.Collections;

public class CollisionDamage : MonoBehaviour
{
    public LevelManager LM;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag.Equals("Enemy"))
        {
            //Debug.Log("I hit something");
            LM.GetComponent<LevelManager>().current_life --;
        }
        //Debug.Log("touching stuff");
    }
}