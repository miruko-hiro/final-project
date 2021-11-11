using Core.Player;
using PlayerCreation.UI.Selectors;
using Template.Creatures;
using Template.Creatures.Appearance;
using Template.Creatures.Types;

namespace PlayerCreation.Main
{
    public class HairStyleChanger: IChanger
    {
        private readonly PlayerData _pData;
        private readonly Humanoid _player;
        private readonly AppearanceIssuanceSystem _dispenser;

        public HairStyleChanger(PlayerData pData, Humanoid player, AppearanceIssuanceSystem dispenser)
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
            if (_pData.IndexHair == 0)
            {
                if (_pData.HairLength == HairLength.Long)
                    SetHairStyle(Limits.ShortHairIndex - 1, HairLength.Short);
                else
                    SetHairStyle(Limits.LongHairIndex - 1, HairLength.Long);
            }
            else
                SetHairStyle(_pData.IndexHair - 1, _pData.HairLength);
        }

        private void DoWhenNext()
        {
            if (_pData.IndexHair == Limits.LongHairIndex - 1 && _pData.HairLength == HairLength.Long)
                SetHairStyle(0, HairLength.Short);
            else if (_pData.IndexHair == Limits.ShortHairIndex - 1 && _pData.HairLength == HairLength.Short)
                SetHairStyle(0, HairLength.Long);
            else
                SetHairStyle(_pData.IndexHair + 1, _pData.HairLength);
        }

        private void SetHairStyle(int index, HairLength length)
        {
            _pData.IndexHair = index;
            _pData.HairLength = length;
            _player.HairHead = _dispenser.GetHairHead(_pData.IndexHair, _pData.HairLength, _pData.HairColor);
        }
    }
}