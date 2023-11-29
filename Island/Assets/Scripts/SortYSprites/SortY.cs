using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortY : MonoBehaviour
{
    //Класс сортировки спрайтов для объектов в игре
    private void Start()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sortingOrder = transform.GetSortingOrder();
    }
}
