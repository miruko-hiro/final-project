using Core.Player;
using PlayerCreation.UI.Selectors;
using Template.Creatures;
using Template.Creatures.Appearance;
using Template.Creatures.Types;

namespace PlayerCreation.Main
{
    public class GenderTypeChanger: IChanger
    {
        private readonly PlayerData _pData;
        private readonly Humanoid _player;
        private readonly AppearanceIssuanceSystem _dispenser;

        public GenderTypeChanger(PlayerData pData, Humanoid player, AppearanceIssuanceSystem dispenser)
        {
            _pData = pData;
            _player = player;
            _dispenser = dispenser;
        }


        public void Change(SelectionType type)
        {
            if (_pData.HumanoidGender == HumanoidGender.Female)
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
            SetGenderType(HumanoidGender.Male);
            SetBodyArmor(0, ArmorType.Light);
        }

        private void DoWhenNext()
        {
            SetGenderType(HumanoidGender.Female);
            SetBodyArmor(1, ArmorType.Light);
        }

        private void SetGenderType(HumanoidGender gender)
        {
            _pData.HumanoidGender = gender;
            _player.Race = _dispenser.GetHumanoid(_pData.IndexHumanoidRace, _pData.HumanoidRace, _pData.HumanoidGender);
        }

        private void SetBodyArmor(int index, ArmorType type)
        {
            _pData.IndexBodyArmor = index;
            _pData.BodyArmorType = type;
            _player.BodyArmor = _dispenser.GetBodyArmor(_pData.IndexBodyArmor, _pData.BodyArmorType);
        }
    }
}