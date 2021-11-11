using Core.Player;
using PlayerCreation.UI.Selectors;
using Template.Creatures;
using Template.Creatures.Appearance;
using Template.Creatures.Types;

namespace PlayerCreation.Main
{
    public class BeardStyleChanger: IChanger
    {
        private readonly PlayerData _pData;
        private readonly Humanoid _player;
        private readonly AppearanceIssuanceSystem _dispenser;

        public BeardStyleChanger(PlayerData pData, Humanoid player, AppearanceIssuanceSystem dispenser)
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
            if (_pData.IndexBeard == 0)
            {
                if (_pData.BeardLength == BeardLength.Beard)
                    SetBeardStyle(Limits.MustacheIndex - 1, BeardLength.Mustache);
                else
                    SetBeardStyle(Limits.BeardIndex - 1, BeardLength.Beard);
                    
            }
            else
                SetBeardStyle(_pData.IndexBeard - 1, _pData.BeardLength);
        }

        private void DoWhenNext()
        {
            if (_pData.IndexBeard == Limits.BeardIndex - 1 && _pData.BeardLength == BeardLength.Beard)
                SetBeardStyle(0, BeardLength.Mustache);
            else if (_pData.IndexBeard == Limits.MustacheIndex - 1 && _pData.BeardLength == BeardLength.Mustache)
                SetBeardStyle(0, BeardLength.Beard);
            else
                SetBeardStyle(_pData.IndexBeard + 1, _pData.BeardLength);
        }

        private void SetBeardStyle(int index, BeardLength length)
        {
            _pData.IndexBeard = index;
            _pData.BeardLength = length;
            _player.Beard = _dispenser.GetBeard(_pData.IndexBeard, _pData.BeardLength, _pData.BeardColor);
        }
    }
}