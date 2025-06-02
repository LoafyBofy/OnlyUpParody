using System.Linq;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private IPause[] _canPausedObjects;

    public bool IsPaused { get; private set; } = false;
 
    private void Start()
    {
        _canPausedObjects = FindObjectsOfType<MonoBehaviour>(true).OfType<IPause>().ToArray();
    }

    /// <summary>
    /// If <paramref name="isPaused"/> == true, Game stoped! if <paramref name="isPaused"/> == false, Game continue!
    /// </summary>
    /// <param name="isPaused"></param>
    public void SetPause(bool isPaused)
    {
        IsPaused = isPaused;

        if (_canPausedObjects.Length > 0)
        {
            for (int i = 0; i < _canPausedObjects.Length; i++)
            {
                _canPausedObjects[i].IsPaused = isPaused;
            }
        }
    }
}
