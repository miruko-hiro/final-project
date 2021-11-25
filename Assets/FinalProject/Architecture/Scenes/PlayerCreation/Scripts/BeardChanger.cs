using System;
using FinalProject.Architecture.Characters.Player;
using FinalProject.Architecture.Characters.Player.Interactors;
using FinalProject.Architecture.Characters.Scripts;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Characters.Scripts.Types;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Scenes.PlayerCreation.Scripts.UI.Selectors;

namespace FinalProject.Architecture.Scenes.PlayerCreation.Scripts
{
    public class BeardChanger
    {
        private readonly PlayerCreationView _player;
        private readonly AppearanceIssuanceSystem _dispenser;
        private int _index =  0;
        private BeardLength _beardLength = BeardLength.Mustache;
        private HairColor _beardColor = HairColor.Black;
        private PlayerBeardInteractor _playerBeardInteractor;

        public BeardChanger(GameManager gameManager, PlayerCreationView player, AppearanceIssuanceSystem dispenser)
        {
            _playerBeardInteractor = gameManager.GetInteractor<PlayerBeardInteractor>();
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
                switch (_beardLength)
                {
                    case BeardLength.Beard:
                        SetBeardStyle(Limits.MustacheIndex - 1, BeardLength.Mustache);
                        break;
                    case BeardLength.Mustache:
                        SetBeardStyle(0, BeardLength.None);
                        break;
                    case BeardLength.None:
                        SetBeardStyle(Limits.BeardIndex - 1, BeardLength.Beard);
                        break;
                    default: 
                        throw new ArgumentOutOfRangeException(nameof(_beardLength), _beardLength, null);
                }
                    
            }
            else
                SetBeardStyle(_index - 1, _beardLength);
        }

        private void DoStyleWhenNext()
        {
            if (_index == Limits.BeardIndex - 1 && _beardLength == BeardLength.Beard)
                SetBeardStyle(0, BeardLength.None);
            else if (_index == Limits.MustacheIndex - 1 && _beardLength == BeardLength.Mustache)
                SetBeardStyle(0, BeardLength.Beard);
            else if (_index == 0 && _beardLength == BeardLength.None)
                SetBeardStyle(0, BeardLength.Mustache);
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
            var beardProperties = _playerBeardInteractor.GetBeardProperties();
            beardProperties.BeardColor = _beardColor;
            beardProperties.BeardLength = _beardLength;
            beardProperties.SpriteIndex = _index;
            _playerBeardInteractor.ChangeBeard(beardProperties);
            
            _player.Beard = _dispenser.GetBeard(beardProperties);
        }
    }
}