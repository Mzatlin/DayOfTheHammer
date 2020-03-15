using System;

public interface IEntry
{
    event Action OnEnter;
    event Action OnExit;
}