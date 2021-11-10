using UnityEngine;

namespace Template.Creatures
{
    public class Humanoid : MonoBehaviour
    {
        [Space(10)] 
        [SerializeField] private SpriteRenderer race;
        [Space(10)]
        [SerializeField] private SpriteRenderer hairHead;
        [SerializeField] private SpriteRenderer beard;
        [Space(10)]
        [SerializeField] private SpriteRenderer head;
        [SerializeField] private SpriteRenderer body;
        [SerializeField] private SpriteRenderer pants;
        [SerializeField] private SpriteRenderer boots;
        [Space(10)]
        [SerializeField] private SpriteRenderer rightHand;
        [SerializeField] private SpriteRenderer leftHand;
        
        public Sprite Race { get => race.sprite; set => race.sprite = value; }
        public Sprite HairHead { get => hairHead.sprite; set => hairHead.sprite = value; }
        public Sprite Beard { get => beard.sprite; set => beard.sprite = value; }
        public Sprite HeadArmor { get => head.sprite; set => head.sprite = value; }
        public Sprite BodyArmor { get => body.sprite; set => body.sprite = value; }
        public Sprite PaintsArmor { get => pants.sprite; set => pants.sprite = value; }
        public Sprite BootsArmor { get => boots.sprite; set => boots.sprite = value; }
        public Sprite RightHand { get => rightHand.sprite; set => rightHand.sprite = value; }
        public Sprite LeftHand { get => leftHand.sprite; set => leftHand.sprite = value; }
    }
}
