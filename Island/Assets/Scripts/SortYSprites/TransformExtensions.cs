using System;
using UnityEngine;

public static class TransformExtensions 
{
    //���������� ������ ��������� ������� 
    public static int GetSortingOrder(this Transform transform, float yOffet = 0)
    {
        return -(int) ((transform.position.y + yOffet) * 100);

    }
}
