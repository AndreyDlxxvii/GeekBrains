using System;
using UnityEditor.VersionControl;

namespace CodeGeek
{
    public class NewException : ArgumentException
    {
        public int Value { get; }
        
        public NewException (string message, int value) : base(message)
        {
            Value = value;
        }
    }
}