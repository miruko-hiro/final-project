using DG.Tweening;
using UnityEngine;

namespace FinalProject.Architecture.Items.Scripts
{
    public class Item : MonoBehaviour
    {
        public void Jump()
        {
            transform.DOLocalJump(
                transform.position + new Vector3(Random.Range(-2, 2), 0, 0), 
                1f, 
                3, 
                1.5f);
        }
    }
}