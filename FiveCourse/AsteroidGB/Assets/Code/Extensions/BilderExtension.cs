using System;
using UnityEngine;
    
namespace AsteroidGB
{
    public static partial class Extensions
    {
        public static GameObject SetName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }

        public static GameObject AddSprite(this GameObject gameObject, Sprite sprite)
        {
            var temp = gameObject.GetOrAddComponent<SpriteRenderer>();
            temp.sprite = sprite;
            return gameObject;
        }

        public static GameObject AddRigidbody(this GameObject gameObject)
        {
            gameObject.GetOrAddComponent<Rigidbody>();
            gameObject.GetComponent<Rigidbody>().useGravity = false;
            return gameObject;
        }
        
        public static GameObject AddBoxCollider(this GameObject gameObject)
        {
            gameObject.GetOrAddComponent<BoxCollider>();
            gameObject.GetComponent<BoxCollider>().isTrigger = true;
            return gameObject;
        }

        public static GameObject AddScriptView <T> (this GameObject gameObject) where T : Component
        {
            gameObject.GetOrAddComponent<T>();
            return gameObject;
        }
        public static GameObject AddTag(this GameObject gameObject, string tag)
        {
            gameObject.tag = tag;
            return gameObject;
        }
        
    }
}