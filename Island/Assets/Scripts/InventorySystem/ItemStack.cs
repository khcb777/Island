using System;
using UnityEngine;

namespace InventorySystem
{
    //���� ��������� � �� ���������
    [Serializable]
    public class ItemStack
    {
        [SerializeField]
        private ItemDefinition _item;

        [SerializeField]
        private int _numbersOfItem;

        public bool IsStackable => _item != null &&  _item.IsStackable;
        public ItemDefinition Item => _item;

        //��������� ����� ���������� ��������� ���� ������ ���� � ���� ������� ��������� � ���� �� ������ ���������� ���������
        //����� ���������� ����� 1, ��� ��� ������� � ��������� �� �����������
        public int NumberOfItems
        {  
            get => _numbersOfItem;
            set
            {
                value = value < 0 ? 0 : value;
                _numbersOfItem = IsStackable ? value : 1;
            }
        }
        //����������� ������
        public ItemStack(ItemDefinition item,  int numberOfItems) 
        {
            _item = item;
            NumberOfItems  = numberOfItems;
        }

        //���������� ������ ��� ����������� ���������
        public ItemStack() { }
    }
}