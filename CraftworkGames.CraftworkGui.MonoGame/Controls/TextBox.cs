using System;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public class TextBox : Label
    {
        static TextBox()
        {
            _keyStringMap = new Dictionary<Keys, string>();
            _keyStringMap.Add(Keys.D0, "0");
            _keyStringMap.Add(Keys.D1, "1");
            _keyStringMap.Add(Keys.D2, "2");
            _keyStringMap.Add(Keys.D3, "3");
            _keyStringMap.Add(Keys.D4, "4");
            _keyStringMap.Add(Keys.D5, "5");
            _keyStringMap.Add(Keys.D6, "6");
            _keyStringMap.Add(Keys.D7, "7");
            _keyStringMap.Add(Keys.D8, "8");
            _keyStringMap.Add(Keys.D9, "9");
            _keyStringMap.Add(Keys.Space, " ");
        }

        public TextBox(VisualStyle defaultStyle)
            : base(defaultStyle)
        {
        }

        private static readonly Dictionary<Keys, string> _keyStringMap;
        private bool _firstUpdate = true;
        public override void Update(IInputManager inputManager, float deltaTime)
        {
            if(_firstUpdate)
            {
                inputManager.KeyPressed += HandleKeyPressed;;
                _firstUpdate = false;
            }

            _isShiftDown = inputManager.IsShiftDown;

            base.Update(inputManager, deltaTime);
        }

        private bool _isShiftDown = false;
        private void HandleKeyPressed (object sender, ItemEventArgs<Keys> e)
        {
            if(e.Item == Keys.Back)
            {
                var length = Text.Length - 1;

                if(length >= 0)
                    Text = Text.Substring(0, length);
            }
            else
            {
                string keyValue;
                if(_keyStringMap.TryGetValue(e.Item, out keyValue))
                {
                    Text += keyValue;
                }
                else
                {
                    if(e.Item >= Keys.A && e.Item <= Keys.Z)
                    {
                        var stringValue = e.Item.ToString();

                        if(_isShiftDown)
                            stringValue = stringValue.ToUpper();
                        else
                            stringValue = stringValue.ToLower();

                        Text += stringValue;
                    }
                }
            }
        }
    }
}

