using System;
using TowerDefense.ScriptableEvents;
using UnityEngine;
using UnityEngine.UI;

public class SimpleButtonEventEmitter : MonoBehaviour
{
    [SerializeField] private GameEvent _gameEvent;
    [SerializeField] private Button mButton;

    private void Awake() => InitializeButton();
    

    public void InitializeButton()
    {
        mButton = GetComponents<Button>()[0];
        if(mButton.onClick.GetPersistentEventCount() != 0) return;
        mButton.onClick.AddListener(()=> _gameEvent.Rise());
    }
    
}
