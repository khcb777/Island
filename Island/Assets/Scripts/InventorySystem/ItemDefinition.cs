using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    [CreateAssetMenu(menuName = "Inventory/Item Definition", fileName = "New Item Definition")]
    public class ItemDefinition : ScriptableObject
    {
        [SerializeField]
        private string _name;

        [SerializeField]
        private string _description;

        [SerializeField]
        private bool _isStackable;

        [SerializeField]
        private Sprite _inGameSprite;

        [SerializeField]
        private Sprite _uiSprite;

        public string Name => _name;
        public string Description => _description;
        public bool IsStackable => _isStackable;
        public Sprite InGameSprite => _inGameSprite;
        public Sprite UISprite => _uiSprite;
    }
}