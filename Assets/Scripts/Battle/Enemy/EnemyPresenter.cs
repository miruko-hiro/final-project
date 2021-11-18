using Core.Interfaces;
using Template.Creatures;
using UnityEngine;

namespace Battle.Enemy
{
    public class EnemyPresenter
    {
        private readonly Humanoid _view;
        private readonly ICharacterData _model;

        public EnemyPresenter(Humanoid view, ICharacterData model)
        {
            _view = view;
            _model = model;
            OnOpen();
        }

        private void LoadData()
        {
            SetRace(_model.HumanoidRaceSprite.Value);
            SetHair(_model.HairSprite.Value);
            SetBeard(_model.BeardSprite.Value);
            
            SetHeadArmor(_model.HeadArmorSprite.Value);
            SetBodyArmor(_model.BodyArmorSprite.Value);
            SetPantsArmor(_model.PantsArmorSprite.Value);
            SetBootsArmor(_model.BootsArmorSprite.Value);

            SetLeftHand(_model.LeftHandSprite.Value);
            SetRightHand(_model.RightHandSprite.Value);
        }

        private void SaveData()
        {
            
        }

        private void OnOpen()
        {
            LoadData();

            _model.HumanoidRaceSprite.Change += SetRace;
            _model.HairSprite.Change += SetHair;
            _model.BeardSprite.Change += SetBeard;
            _model.HeadArmorSprite.Change += SetHeadArmor;
            _model.BodyArmorSprite.Change += SetBodyArmor;
            _model.PantsArmorSprite.Change += SetPantsArmor;
            _model.BootsArmorSprite.Change += SetBootsArmor;
            _model.LeftHandSprite.Change += SetLeftHand;
            _model.RightHandSprite.Change += SetRightHand;
        }

        private void OnClose()
        {
            SaveData();

            _model.HumanoidRaceSprite.Change -= SetRace;
            _model.HairSprite.Change -= SetHair;
            _model.BeardSprite.Change -= SetBeard;
            _model.HeadArmorSprite.Change -= SetHeadArmor;
            _model.BodyArmorSprite.Change -= SetBodyArmor;
            _model.PantsArmorSprite.Change -= SetPantsArmor;
            _model.BootsArmorSprite.Change -= SetBootsArmor;
            _model.LeftHandSprite.Change -= SetLeftHand;
            _model.RightHandSprite.Change -= SetRightHand;
        }

        private void SetRace(Sprite sprite)
        {
            _view.Race = sprite;
        }

        private void SetHair(Sprite sprite)
        {
            _view.Hair = sprite;
        }

        private void SetBeard(Sprite sprite)
        {
            _view.Beard = sprite;
        }

        private void SetHeadArmor(Sprite sprite)
        {
            _view.HeadArmor = sprite;
        }

        private void SetBodyArmor(Sprite sprite)
        {
            _view.BodyArmor = sprite;
        }

        private void SetPantsArmor(Sprite sprite)
        {
            _view.PantsArmor = sprite;
        }

        private void SetBootsArmor(Sprite sprite)
        {
            _view.BootsArmor = sprite;
        }

        private void SetRightHand(Sprite sprite)
        {
            _view.RightHand = sprite;
        }

        private void SetLeftHand(Sprite sprite)
        {
            _view.LeftHand = sprite;
        }

        ~EnemyPresenter()
        {
            OnClose();
        }
    }
}