using System;
using UnityEngine;

namespace InventorySystem
{
    //стек предметов и их количеста
    [Serializable]
    public class ItemStack
    {
        [SerializeField]
        private ItemDefinition _item;

        [SerializeField]
        private int _numbersOfItem;

        public bool IsStackable => _item != null &&  _item.IsStackable;
        public ItemDefinition Item => _item;

        //Проверяем чтобы количество предметов было больше нуля и если предмет стыкуется в кучи то задаем количество предметов
        //Иначе количество будет 1, так как предмет в инвенторе не суммируется
        public int NumberOfItems
        {  
            get => _numbersOfItem;
            set
            {
                value = value < 0 ? 0 : value;
                _numbersOfItem = IsStackable ? value : 1;
            }
        }
        //Конструктор класса
        public ItemStack(ItemDefinition item,  int numberOfItems) 
        {
            _item = item;
            NumberOfItems  = numberOfItems;
        }

        //Коструктор класса для опусташения инвенторя
        public ItemStack() { }
    }
}