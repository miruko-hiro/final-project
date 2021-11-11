using System;
using Core.Player;
using PlayerCreation.UI.Selectors;
using Template.Creatures;
using Template.Creatures.Appearance;
using Template.Creatures.Types;

namespace PlayerCreation.Main
{
    public class HairColorChanger: IChanger
    {
        private readonly PlayerData _pData;
        private readonly Humanoid _player;
        private readonly AppearanceIssuanceSystem _dispenser;

        public HairColorChanger(PlayerData pData, Humanoid player, AppearanceIssuanceSystem dispenser)
        {
            _pData = pData;
            _player = player;
            _dispenser = dispenser;
        }
        
        public void Change(SelectionType type)
        {
            if (type == SelectionType.Prev)
            {
                DoWhenPerv();
            }
            else
            {
                DoWhenNext();
            }
        }
        
        private void DoWhenPerv()
        {
            switch (_pData.HairColor)
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

        private void DoWhenNext()
        {
            switch (_pData.HairColor)
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
            _pData.HairColor = color;
            _player.HairHead = _dispenser.GetHairHead(_pData.IndexHair, _pData.HairLength, _pData.HairColor);
        }
    }
}