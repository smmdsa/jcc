using System.Collections;
using System.Collections.Generic;
using TowerDefense.ScriptableEvents;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SimpleButtonEventEmitter : MonoBehaviour
{
    [SerializeField] private GameEvent _gameEvent;
    void Awake()=>
        this.GetComponents<Button>()[0].onClick.AddListener(()=> _gameEvent.Rise());
    
}
