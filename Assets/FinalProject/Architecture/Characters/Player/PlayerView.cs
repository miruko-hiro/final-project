using FinalProject.Architecture.Characters.Scripts;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Game.Scripts;
using FinalProject.Architecture.Scenes.Scripts.Config;
using UnityEngine;
using Zenject;

namespace FinalProject.Architecture.Characters.Player
{
    public class PlayerView : Humanoid
    {
        private PlayerPresenter _presenter;
        public override Sprite Race { get => race.sprite; set => race.sprite = value; }
        public override Sprite Hair { get => hairHead.sprite; set => hairHead.sprite = value; }
        public override Sprite Beard { get => beard.sprite; set => beard.sprite = value; }
        public override Sprite HeadArmor { get => head.sprite; set => head.sprite = value; }
        public override Sprite BodyArmor { get => body.sprite; set => body.sprite = value; }
        public override Sprite PantsArmor { get => pants.sprite; set => pants.sprite = value; }
        public override Sprite BootsArmor { get => boots.sprite; set => boots.sprite = value; }
        public override Sprite RightHand { get => rightHand.sprite; set => rightHand.sprite = value; }
        public override Sprite LeftHand { get => leftHand.sprite; set => leftHand.sprite = value; }

        [Inject]
        private void Construct(GameManager gameManager, AppearanceIssuanceSystem dispenser)
        {
            _presenter = new PlayerPresenter(this, gameManager, dispenser);
        }

        private void OnDestroy()
        {
            _presenter = null;
        }
    }
}