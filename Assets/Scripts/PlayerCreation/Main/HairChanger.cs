using System;
using Core.Player;
using PlayerCreation.UI.Selectors;
using Template.Creatures;
using Template.Creatures.Appearance;
using Template.Creatures.Types;

namespace PlayerCreation.Main
{
    public class HairChanger
    {
        private readonly PlayerData _pData;
        private readonly Humanoid _player;
        private readonly AppearanceIssuanceSystem _dispenser;
        private HairColor _hairColor = HairColor.Black;
        private int _index =  0;
        private HairLength _hairLength = HairLength.Short;

        public HairChanger(PlayerData pData, Humanoid player, AppearanceIssuanceSystem dispenser)
        {
            _pData = pData;
            _player = player;
            _dispenser = dispenser;
        }
        
        public void ChangeStyle(SelectionType type)
        {
            if (type == SelectionType.Prev)
            {
                DoStyleWhenPerv();
            }
            else
            {
                DoStyleWhenNext();
            }
        }
        
        private void DoStyleWhenPerv()
        {
            if (_index == 0)
            {
                if (_hairLength == HairLength.Long)
                    SetHairStyle(Limits.ShortHairIndex - 1, HairLength.Short);
                else
                    SetHairStyle(Limits.LongHairIndex - 1, HairLength.Long);
            }
            else
                SetHairStyle(_index - 1, _hairLength);
        }

        private void DoStyleWhenNext()
        {
            if (_index == Limits.LongHairIndex - 1 && _hairLength == HairLength.Long)
                SetHairStyle(0, HairLength.Short);
            else if (_index == Limits.ShortHairIndex - 1 && _hairLength == HairLength.Short)
                SetHairStyle(0, HairLength.Long);
            else
                SetHairStyle(_index + 1, _hairLength);
        }
        
        public void ChangeColor(SelectionType type)
        {
            if (type == SelectionType.Prev)
            {
                DoColorWhenPerv();
            }
            else
            {
                DoColorWhenNext();
            }
        }
        
        private void DoColorWhenPerv()
        {
            switch (_hairColor)
            {
                case HairColor.Black:
                    SetHairColor(HairColor.White);
                    break;
                case HairColor.White:
                    SetHairColor(HairColor.Wheat);
                    break;
                case HairColor.Wheat:
                    SetHairColor(HairColor.Red);
                    break;
                case HairColor.Red:
                    SetHairColor(HairColor.Ginger);
                    break;
                case HairColor.Ginger:
                    SetHairColor(HairColor.Black);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void DoColorWhenNext()
        {
            switch (_hairColor)
            {
                case HairColor.Black:
                    SetHairColor(HairColor.Ginger);
                    break;
                case HairColor.Ginger:
                    SetHairColor(HairColor.Red);
                    break;
                case HairColor.Red:
                    SetHairColor(HairColor.Wheat);
                    break;
                case HairColor.Wheat:
                    SetHairColor(HairColor.White);
                    break;
                case HairColor.White:
                    SetHairColor(HairColor.Black);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SetHairColor(HairColor color)
        {
            _hairColor = color;
            SetHair();
        }

        private void SetHairStyle(int index, HairLength length)
        {
            _index = index;
            _hairLength = length;
            SetHair();
        }

        private void SetHair()
        {
            _pData.HairSprite.Value = _dispenser.GetHairHead(_index, _hairLength, _hairColor);
            _player.Hair = _pData.HairSprite.Value;
        }
    }
}