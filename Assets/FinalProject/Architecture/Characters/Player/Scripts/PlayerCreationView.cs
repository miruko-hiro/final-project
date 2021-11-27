using UnityEngine;

namespace FinalProject.Architecture.Characters.Player
{
    public class PlayerCreationView : MonoBehaviour
    {
        [Space(10)] 
        [SerializeField] protected SpriteRenderer race;
        [Space(10)]
        [SerializeField] protected SpriteRenderer hairHead;
        [SerializeField] protected SpriteRenderer beard;
        [Space(10)]
        [SerializeField] protected SpriteRenderer body;
        [Space(10)]
        [SerializeField] protected SpriteRenderer rightHand;
        
        public Sprite Race { get => race.sprite; set => race.sprite = value; }
        public Sprite Hair { get => hairHead.sprite; set => hairHead.sprite = value; }
        public Sprite Beard { get => beard.sprite; set => beard.sprite = value; }
        public Sprite BodyArmor { get => body.sprite; set => body.sprite = value; }
        public Sprite RightHand { get => rightHand.sprite; set => rightHand.sprite = value; }
    }
}