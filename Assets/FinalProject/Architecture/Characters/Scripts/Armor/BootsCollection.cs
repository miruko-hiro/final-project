using UnityEngine;

namespace FinalProject.Architecture.Characters.Scripts.Armor
{
    public class BootsCollection : MonoBehaviour
    {
        [Space(10)]
        [SerializeField] private Sprite[] boots = new Sprite[12];
        public Sprite GetSprite(int index)
        {
            return index < 0 ? null : boots[index];
        }
    }
}