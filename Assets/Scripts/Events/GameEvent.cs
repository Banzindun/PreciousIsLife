using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "gameEvent.asset", menuName = "Game/GameEvent")]
public class GameEvent : ScriptableObject {

    // List of listeners
    private List<GameEventListener> listeners = new List<GameEventListener>();

    /// <summary>
    /// Raises the event by calling OnEventRaised method on each of the listeners.
    /// </summary>
    public void Raise() {
        for (int i = 0; i < listeners.Count; i++) {
            listeners[i].OnEventRaised();
        }
    }

    /// <summary>
    /// Registers listener. 
    /// </summary>
    /// <param name="listener"></param>
    public void RegisterListener(GameEventListener listener) {
        listeners.Add(listener);
    }

    /// <summary>
    /// Unregisters listener.
    /// </summary>
    /// <param name="listener"></param>
    public void UnRegisterListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }
}
