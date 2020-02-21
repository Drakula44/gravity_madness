using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conture : MonoBehaviour
{

    public static float a = 8.2F;
    public static float b = 15;
    public static float angle = Mathf.PI/2;
    public static float r = 3.75F;

    static float f(float x)
    {
        return (Mathf.Sign(x)+1)/2;
    }
    public static Vector2 Evaulate(float t)
    {
        int deo = (int)t/100;
        float tx = 0;
        float ty = 0;
        float h = b + r*Mathf.Sin(angle-Mathf.PI/2);
        float g = a + r*Mathf.Sin(angle-Mathf.PI/2);
        float l = r*Mathf.Sin(angle);
        t = t - deo*100;
        if(deo % 2 == 1)
        {

            t = t/100*(h+g-2*l);
            if(deo %4 == 1)
            t = t+(-h+l);
            else {
                t = t+(-g+l);
            }

        }
        else {
            t = t/100*(2*angle)-angle;
        }
        switch (deo) {
            case 0:
                tx = r*Mathf.Sin(t);
                ty = r*Mathf.Cos(t)-a;
                break;
            case 1:
                tx = f(-t)*t+h;
                ty = f(t)*t-g;
                break;
            case 2:
                tx = -r*Mathf.Cos(t)+b;
                ty = r*Mathf.Sin(t);
                break;
            case 3:
                tx = -f(t)*t+h;
                ty = f(-t)*t+g;
                break;
            case 4:
                tx = r*Mathf.Sin(-t);
                ty = -r*Mathf.Cos(t)+a;
                break;
            case 5:
                tx = -f(-t)*t-h;
                ty = -f(t)*t+g;
                break;
            case 6:
                tx = r*Mathf.Cos(t)-b;
                ty = r*Mathf.Sin(-t);
                break;
            case 7:
                tx = f(t)*t - h;
                ty = -f(-t)*t - g;
                break;
        }
        return new Vector2(tx,ty);
    }

}
