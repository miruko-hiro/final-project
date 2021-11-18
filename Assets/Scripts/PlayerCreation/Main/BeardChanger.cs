using System;
using Core.Player;
using PlayerCreation.UI.Selectors;
using Template.Creatures;
using Template.Creatures.Appearance;
using Template.Creatures.Types;

namespace PlayerCreation.Main
{
    public class BeardChanger
    {
        private readonly PlayerData _pData;
        private readonly Humanoid _player;
        private readonly AppearanceIssuanceSystem _dispenser;
        private int _index =  0;
        private BeardLength _beardLength = BeardLength.Mustache;
        private HairColor _beardColor = HairColor.Black;

        public BeardChanger(PlayerData pData, Humanoid player, AppearanceIssuanceSystem dispenser)
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
                if (_beardLength == BeardLength.Beard)
                    SetBeardStyle(Limits.MustacheIndex - 1, BeardLength.Mustache);
                else
                    SetBeardStyle(Limits.BeardIndex - 1, BeardLength.Beard);
                    
            }
            else
                SetBeardStyle(_index - 1, _beardLength);
        }

        private void DoStyleWhenNext()
        {
            if (_index == Limits.BeardIndex - 1 && _beardLength == BeardLength.Beard)
                SetBeardStyle(0, BeardLength.Mustache);
            else if (_index == Limits.MustacheIndex - 1 && _beardLength == BeardLength.Mustache)
                SetBeardStyle(0, BeardLength.Beard);
            else
                SetBeardStyle(_index + 1, _beardLength);
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
            switch (_beardColor)
            {
                case HairColor.Black:
                    SetBeardColor(HairColor.White);
                    break;
                case HairColor.White:
                    SetBeardColor(HairColor.Wheat);
                    break;
                case HairColor.Wheat:
                    SetBeardColor(HairColor.Red);
                    break;
                case HairColor.Red:
                    SetBeardColor(HairColor.Ginger);
                    break;
                case HairColor.Ginger:
                    SetBeardColor(HairColor.Black);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void DoColorWhenNext()
        {
            switch (_beardColor)
            {
                case HairColor.Black:
                    SetBeardColor(HairColor.Ginger);
                    break;
                case HairColor.Ginger:
                    SetBeardColor(HairColor.Red);
                    break;
                case HairColor.Red:
                    SetBeardColor(HairColor.Wheat);
                    break;
                case HairColor.Wheat:
                    SetBeardColor(HairColor.White);
                    break;
                case HairColor.White:
                    SetBeardColor(HairColor.Black);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SetBeardStyle(int index, BeardLength length)
        {
            _index = index;
            _beardLength = length;
            SetBeard();
        }

        private void SetBeardColor(HairColor color)
        {
            _beardColor = color;
            SetBeard();
        }

        private void SetBeard()
        {
            _pData.BeardSprite.Value = _dispenser.GetBeard(_index, _beardLength, _beardColor);
            _player.Beard = _pData.BeardSprite.Value;
        }
    }
}