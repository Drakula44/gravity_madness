using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private static List<Gravity> objekti = new List<Gravity>();
    public Rigidbody2D telo;
    public float ugao;
    void Start()
    {
        objekti.Add(this);
    }

    void Update()
    {

        for(int i = 0;i < objekti.Count;i++)
        {
            if(objekti[i] == this)
                continue;
            float G = -1;
            float force = G*telo.mass*objekti[i].telo.mass/Vector3.Distance(transform.position,objekti[i].transform.position);
            ugao = Mathf.Atan2((transform.position.y-objekti[i].transform.position.y),(transform.position.x-objekti[i].transform.position.x));
            telo.AddForce(new Vector2(Mathf.Cos(ugao)*force,Mathf.Sin(ugao)*force));
        }

    }
}
