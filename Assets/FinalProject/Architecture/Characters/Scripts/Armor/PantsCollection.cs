using UnityEngine;

namespace FinalProject.Architecture.Characters.Scripts.Armor
{
    public class PantsCollection : MonoBehaviour
    {
        [Space(10)]
        [SerializeField] private Sprite[] pants = new Sprite[8];

        public Sprite GetSprite(int index)
        {
            return index < 0 ? null : pants[index];
        }
    }
}