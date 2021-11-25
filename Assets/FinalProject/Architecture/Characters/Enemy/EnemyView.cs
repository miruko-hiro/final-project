using FinalProject.Architecture.Characters.Scripts;
using UnityEngine;

namespace FinalProject.Architecture.Characters.Enemy
{
    public class EnemyView : Humanoid
    {
        public override Sprite Race { get => race.sprite; set => race.sprite = value; }
        public override Sprite Hair { get => hairHead.sprite; set => hairHead.sprite = value; }
        public override Sprite Beard { get => beard.sprite; set => beard.sprite = value; }
        public override Sprite HeadArmor { get => head.sprite; set => head.sprite = value; }
        public override Sprite BodyArmor { get => body.sprite; set => body.sprite = value; }
        public override Sprite PantsArmor { get => pants.sprite; set => pants.sprite = value; }
        public override Sprite BootsArmor { get => boots.sprite; set => boots.sprite = value; }
        public override Sprite RightHand { get => rightHand.sprite; set => rightHand.sprite = value; }
        public override Sprite LeftHand { get => leftHand.sprite; set => leftHand.sprite = value; }
    }
}