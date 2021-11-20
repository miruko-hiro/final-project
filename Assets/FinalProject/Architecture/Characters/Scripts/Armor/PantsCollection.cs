using UnityEngine;

namespace Template.Creatures.Appearance.Armor
{
    public class PantsCollection : MonoBehaviour
    {
        [Space(10)]
        [SerializeField] private Sprite[] pants = new Sprite[8];

        public Sprite GetSprite(int index)
        {
            return pants[index];
        }
    }
}