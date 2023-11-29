using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class GameItem : MonoBehaviour
    {
        [SerializeField]
        private ItemStack _stack;

        [SerializeField]
        private SpriteRenderer _spriteRenderer;

        //���������� ������ ��� ��� ��������� �������� ������� � ����������
        private void OnValidate()
        {
            SetupGameObject();
        }


        private void SetupGameObject()
        {
            if (_stack.Item == null) return;

            SetGameSprite();
            AdjustNumberOfItems();
            UpdateGameObjectName();
            
        }

        //������������ ������
        private void SetGameSprite()
        {
            _spriteRenderer.sprite = _stack.Item.InGameSprite;
        }

        //������ �������� �������
        private void UpdateGameObjectName()
        { 
            var name = _stack.Item.Name;
            var number = _stack.IsStackable ? _stack.NumberOfItems.ToString() : "notStac";

            gameObject.name = $"{name} ({number})";
        }
        //������ ��� ����� � ���������� ������ ���� ���������� ������������ �������� � ���������� ���������, ��� �������� � �������� NumberOfItems
        private void AdjustNumberOfItems()
        {
            _stack.NumberOfItems = _stack.NumberOfItems;
        }
    }
}