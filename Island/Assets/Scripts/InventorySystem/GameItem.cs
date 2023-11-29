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

        //Вызывается каждый раз при изменении настроек обьекта в инспекторе
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

        //Утанавливаем спрайт
        private void SetGameSprite()
        {
            _spriteRenderer.sprite = _stack.Item.InGameSprite;
        }

        //Меняем название обьекта
        private void UpdateGameObjectName()
        { 
            var name = _stack.Item.Name;
            var number = _stack.IsStackable ? _stack.NumberOfItems.ToString() : "notStac";

            gameObject.name = $"{name} ({number})";
        }
        //Делаем так чтобы в инспекторе нельзя было установить неправильные значения в количество предметов, все проверки в свойстве NumberOfItems
        private void AdjustNumberOfItems()
        {
            _stack.NumberOfItems = _stack.NumberOfItems;
        }
    }
}