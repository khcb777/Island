using System;
using UnityEngine;

public static class TransformExtensions 
{
    //Расширение класса трансформ методом 
    public static int GetSortingOrder(this Transform transform, float yOffet = 0)
    {
        return -(int) ((transform.position.y + yOffet) * 100);

    }
}
