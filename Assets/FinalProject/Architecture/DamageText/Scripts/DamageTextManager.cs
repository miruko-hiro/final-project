using FinalProject.Architecture.Helpers.Scripts;
using FinalProject.Architecture.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace FinalProject.Architecture.DamageText.Scripts
{
    public class DamageTextManager : MonoBehaviour
    {
        [SerializeField] private GameObject _damageToEnemyTextPrefab;
        private PoolMono<Text> _poolDamageToEnemyText;
        
        [SerializeField] private GameObject _damageToPlayerTextPrefab;
        private PoolMono<Text> _poolDamageToPlayerText;

        private TranslatorWorldToScreen _translator;
        private RectTransform _rectTransform;
        [SerializeField] private Camera _camera;

        private void Awake()
        {
            _translator = new TranslatorWorldToScreen();
            _rectTransform = GetComponent<RectTransform>();
            _poolDamageToEnemyText = new PoolMono<Text>(_damageToEnemyTextPrefab.GetComponent<Text>(), 5, transform);
            _poolDamageToPlayerText = new PoolMono<Text>(_damageToPlayerTextPrefab.GetComponent<Text>(), 3, transform);
        }

        public void ShowDamageToEnemy(Vector3 position, int damage)
        {
            var pos = _translator.WorldToScreenSpace(position, _camera, _rectTransform);
            var damageText = _poolDamageToEnemyText.GetFreeElement();
            damageText.GetComponent<RectTransform>().anchoredPosition = pos;
            damageText.text = "-" + damage;
        }

        public void ShowDamageToPlayer(Vector3 position, int damage)
        {
            var pos = _translator.WorldToScreenSpace(position, _camera, _rectTransform);
            var damageText = _poolDamageToPlayerText.GetFreeElement();
            damageText.GetComponent<RectTransform>().anchoredPosition = pos;
            damageText.text = "-" + damage;
        }
    }
}
