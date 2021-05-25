using System;
using System.Windows.Input;

namespace RoyaleCS
{
    internal class SimpleKeyboardListener
    {
        private Action<Key> onKeyPressed;

        public Action<Key> GetOnKeyPressed()
        {
            return onKeyPressed;
        }

        internal void SetOnKeyPressed(Action<Key> value)
        {
            onKeyPressed = value;
        }
    }
}