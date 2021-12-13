using System;
using FinalProject.Architecture.Characters.Scripts.Appearance;
using FinalProject.Architecture.Game.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace FinalProject.Architecture.Inventory
{
    public class PlayerAppearance : MonoBehaviour
    {
        [Space(10)] 
        [SerializeField] protected Image race;
        [Space(10)]
        [SerializeField] protected Image hairHead;
        [SerializeField] protected Image beard;
        [Space(10)]
        [SerializeField] protected Image head;
        [SerializeField] protected Image body;
        [SerializeField] protected Image pants;
        [SerializeField] protected Image boots;
        [Space(10)]
        [SerializeField] protected Image rightHand;
        [SerializeField] protected Image leftHand;

        private PlayerAppearancePresenter _presenter;
        private GameManager _gameManager;
        private AppearanceIssuanceSystem _dispenser;

        public Sprite Race
        {
            get => race.sprite;
            set
            {
                if (value == null)
                {
                    SetAlpha(race, 0f);
                    return;
                }
                race.sprite = value;
                SetAlpha(race, 1f);
            }
        }

        public Sprite Hair
        {
            get => hairHead.sprite;
            set
            {
                if (value == null)
                {
                    SetAlpha(hairHead, 0f);
                    return;
                }
                hairHead.sprite = value;
                SetAlpha(hairHead, 1f);
            }
        }

        public Sprite Beard
        {
            get => beard.sprite;
            set
            {
                if (value == null)
                {
                    SetAlpha(beard, 0f);
                    return;
                }
                beard.sprite = value;
                SetAlpha(beard, 1f);
            }
        }

        public Sprite HeadArmor
        {
            get => head.sprite;
            set
            {
                if (value == null)
                {
                    SetAlpha(head, 0f);
                    return;
                }
                head.sprite = value;
                SetAlpha(head, 1f);
            }
        }

        public Sprite BodyArmor
        {
            get => body.sprite;
            set
            {
                if (value == null)
                {
                    SetAlpha(body, 0f);
                    return;
                }
                body.sprite = value;
                SetAlpha(body, 1f);
            }
        }

        public Sprite PantsArmor
        {
            get => pants.sprite;
            set
            {
                if (value == null)
                {
                    SetAlpha(pants, 0f);
                    return;
                }
                pants.sprite = value;
                SetAlpha(pants, 1f);
            }
        }

        public Sprite BootsArmor
        {
            get => boots.sprite;
            set
            {
                if (value == null)
                {
                    SetAlpha(boots, 0f);
                    return;
                }
                boots.sprite = value;
                SetAlpha(boots, 1f);
            }
        }

        public Sprite RightHand
        {
            get => rightHand.sprite;
            set
            {
                if (value == null)
                {
                    SetAlpha(rightHand, 0f);
                    return;
                }
                rightHand.sprite = value;
                SetAlpha(rightHand, 1f);
            }
        }

        public Sprite LeftHand
        {
            get => leftHand.sprite;
            set
            {
                if (value == null)
                {
                    SetAlpha(leftHand, 0f);
                    return;
                }
                leftHand.sprite = value;
                SetAlpha(leftHand, 1f);
            }
        }

        [Inject]
        private void Construct(GameManager gameManager, AppearanceIssuanceSystem dispenser)
        {
            _gameManager = gameManager;
            _dispenser = dispenser;
        }

        private void Awake()
        {
            _presenter = new PlayerAppearancePresenter(this, _gameManager, _dispenser);
        }

        private void SetAlpha(Image image, float count)
        {
            var tempColor = image.color;
            tempColor.a = count;
            image.color = tempColor;
        }

        private void OnDestroy()
        {
            _presenter = null;
        }
    }
}