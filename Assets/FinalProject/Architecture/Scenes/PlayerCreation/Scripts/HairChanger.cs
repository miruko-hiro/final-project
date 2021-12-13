using System;
using FinalProject.Architecture.Characters.Player;
using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Characters.Player.Scripts;
using FinalProject.Architecture.Characters.Scripts;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Scenes.PlayerCreation.Scripts.UI.Selectors;

namespace FinalProject.Architecture.Scenes.PlayerCreation.Scripts
{
    public class HairChanger
    {
        private readonly PlayerCreationView _player;
        private readonly AppearanceIssuanceSystem _dispenser;
        private HairColor _hairColor = HairColor.Black;
        private int _index =  0;
        private HairLength _hairLength = HairLength.Short;
        private PlayerHairInteractor _playerHairInteractor;

        public HairChanger(GameManager gameManager, PlayerCreationView player, AppearanceIssuanceSystem dispenser)
        {
            _playerHairInteractor = gameManager.GetInteractor<PlayerHairInteractor>();
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
                switch (_hairLength)
                {
                    case HairLength.Long:
                        SetHairStyle(Limits.ShortHairIndex - 1, HairLength.Short);
                        break;
                    case HairLength.Short:
                        SetHairStyle(0, HairLength.None);
                        break;
                    case HairLength.None:
                        SetHairStyle(Limits.LongHairIndex - 1, HairLength.Long);
                        break;
                }
            }
            else
                SetHairStyle(_index - 1, _hairLength);
        }

        private void DoStyleWhenNext()
        {
            if (_index == Limits.LongHairIndex - 1 && _hairLength == HairLength.Long)
                SetHairStyle(0, HairLength.None);
            else if (_index == Limits.ShortHairIndex - 1 && _hairLength == HairLength.Short)
                SetHairStyle(0, HairLength.Long);
            else if (_index == 0 && _hairLength == HairLength.None)
                SetHairStyle(0, HairLength.Short);
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
            var hairProperties = _playerHairInteractor.HairProperties;
            hairProperties.HairColor = _hairColor;
            hairProperties.HairLength = _hairLength;
            hairProperties.SpriteIndex = _index;
            _playerHairInteractor.HairProperties = hairProperties;
            
            _player.Hair = _dispenser.GetHairHead(hairProperties);
        }
    }
}