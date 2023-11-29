using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicYSort : MonoBehaviour
{
    /*
     Класс делает динамическую сортировку спрайта игрока
        с учетом того что он будет состоять из частей
     */
    [SerializeField]
    private int _baseSortingOrder;

    [SerializeField]
    private Transform _sortOffsetMarker;

    private float _ySortOffset;

    [SerializeField]
    private SortableSprite[] sortableSprites;

    private void Start()
    {
        _ySortOffset = _sortOffsetMarker.localPosition.y;
    }

    private void Update()
    {
        _baseSortingOrder = transform.GetSortingOrder(_ySortOffset);
        
        foreach (var sortableSprite in sortableSprites)
        {
            sortableSprite.spriteRenderer.sortingOrder = _baseSortingOrder + sortableSprite.relativeOrder;
        }
    }

    //задаем слои для частей персонажа
    [Serializable]
    public struct SortableSprite
    {
        public SpriteRenderer spriteRenderer;
        public int relativeOrder;
    }
}
