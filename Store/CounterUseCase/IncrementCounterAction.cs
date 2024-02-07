namespace MauiFluxor.Store.CounterUseCase;

public class IncrementCounterAction
{
	public int Value { get; set; }

	public IncrementCounterAction(int value)
	{
        Value = value;
	}
}