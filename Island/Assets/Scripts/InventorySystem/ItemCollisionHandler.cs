using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class ItemCollisionHandler : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(!collision.TryGetComponent<GameItem>(out var gameItem)) return;
            Debug.Log("sd");
            gameItem.Pick();
        }
    }
}