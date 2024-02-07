﻿namespace MauiFluxor.Store.CounterUseCase;

using Fluxor;

[FeatureState]
public class CounterState
{
    public int ClickCount { get; }

    // Required for creating initial state
    private CounterState() { } 

    public CounterState(int clickCount)
    {
        ClickCount = clickCount;
    }
}