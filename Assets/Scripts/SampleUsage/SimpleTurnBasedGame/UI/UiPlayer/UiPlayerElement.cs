using UnityEngine;

namespace SimpleTurnBasedGame
{
    public class UiPlayerElement : MonoBehaviour
    {
        private UiPlayerContainer Handler { get; set; }

        private void Awake()
        {
            Handler = GetComponentInParent<UiPlayerContainer>();
        }
    }
}