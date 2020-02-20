using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conture : MonoBehaviour
{
    public  static Conture[] contures = new Conture[8];
    public int id = 0;
    public int type;
    public float x=0;
    public float y=0;
    public float r=4;
    public float angle=Mathf.PI/2;
    public float ix = 1;
    public float iy = 1;
    public float conX;
    public float conY;

    void Start()
    {
        contures[id] = this;
        if(type == 1)
        {
            x =  transform.position.x;
            y =  transform.position.y;
        }
    }
    Vector2 Evaulate(float t)
    {
        float nx = 0;
        float ny = 0;
        if(type == 1)
        {
            nx = ix * (x + r*Mathf.Sin(t/100*angle));
            ny = iy * (y + r*Mathf.Cos(t/100*angle));
        }
        else if(type == 0)
        {

        }
        return new Vector2(nx,ny);
    }
}
