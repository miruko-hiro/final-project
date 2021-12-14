using DG.Tweening;
using FinalProject.Architecture.Scenes.MainMenu.Scripts;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts
{
    public class TraderDialog : MonoBehaviour
    {
        [SerializeField] private GameObject _buyWindow;
        [SerializeField] private GameObject _sellWindow;
        [SerializeField] private Text _buyText;
        [SerializeField] private Text _sellText;
        private SoundEffectsButtons _soundEffectsButtons;
        private Image _image;
        private float _duration = 0.2f;

        [Inject]
        private void Construct(SoundEffectsButtons soundEffectsButtons)
        {
            _soundEffectsButtons = soundEffectsButtons;
        }

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        private void OnEnable()
        {
            DOTween.Sequence()
                .Insert(0f, _image.DOFade(1f, _duration).From(0f))
                .Insert(0f, _buyText.DOFade(1f, _duration).From(0f))
                .Insert(0f, _sellText.DOFade(1f, _duration).From(0f));
        }

        public void Disable()
        {
            DOTween.Sequence()
                .Insert(0f, _image.DOFade(0f, _duration).From(1f))
                .Insert(0f, _buyText.DOFade(0f, _duration).From(1f))
                .Insert(0f, _sellText.DOFade(0f, _duration).From(1f))
                .AppendCallback(() => gameObject.SetActive(false));
        }

        public void OnClickBuy()
        {
            _soundEffectsButtons.SoundEffectClick();
            _buyWindow.SetActive(true);
        }

        public void OnClickSell()
        {
            _soundEffectsButtons.SoundEffectClick();
            _sellWindow.SetActive(true);
        }
    }
}
