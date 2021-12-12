using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace FinalProject.Architecture.Scenes.FreeZone.Scripts
{
    public class TraderDialog : MonoBehaviour
    {
        [SerializeField] private GameObject _buyWindow;
        [SerializeField] private GameObject _sellWindow;
        [SerializeField] private Text _buyText;
        [SerializeField] private Text _sellText;
        private Image _image;
        private float _duration = 0.2f;

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
            _buyWindow.SetActive(true);
        }

        public void OnClickSell()
        {
            _sellWindow.SetActive(true);
        }
    }
}
