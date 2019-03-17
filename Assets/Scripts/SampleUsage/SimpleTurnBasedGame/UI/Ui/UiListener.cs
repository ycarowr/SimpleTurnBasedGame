using Patterns;
using SimpleTurnBasedGame;
using UnityEngine;

public class UiListener : MonoBehaviour, IListener
{
    protected virtual void Start()
    {
        //subscribe
        if (GameEvents.Instance)
            GameEvents.Instance.AddListener(this);
    }

    protected virtual void OnDestroy()
    {
        //unsubscribe
        if (GameEvents.Instance)
            GameEvents.Instance.RemoveListener(this);
    }
}