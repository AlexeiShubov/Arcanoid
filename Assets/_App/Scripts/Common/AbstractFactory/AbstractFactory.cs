using UnityEngine;

public abstract class AbstractFactory<T>
{
    public abstract T Spawn(bool newEntityActive = default, Vector2 spawnPosition = default);
}
