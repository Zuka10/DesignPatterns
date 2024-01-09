namespace DesignPatterns.CircuitBreaker;

public enum CircuitBreakerState
{
    Closed,
    Open,
    HalfOpen
}

public class CircuitBreaker
{
    public CircuitBreakerState State { get; private set; }
    public int FailureThreshold { get; }
    public int ResetTimeout { get; }

    private int failures;
    private DateTime lastFailureTime;

    public CircuitBreaker(int failureThreshold, int resetTimeout)
    {
        State = CircuitBreakerState.Closed;
        FailureThreshold = failureThreshold;
        ResetTimeout = resetTimeout;
        failures = 0;
    }

    public void ExecuteAction(Action action)
    {
        switch (State)
        {
            case CircuitBreakerState.Closed:
                try
                {
                    action.Invoke();
                }
                catch (Exception ex)
                {
                    HandleFailure(ex);
                }
                break;
            case CircuitBreakerState.Open:
                if (IsTimeoutExpired())
                {
                    State = CircuitBreakerState.HalfOpen;
                    failures = 0;
                }
                else
                {
                    Console.WriteLine("Circuit is open, Operation not attempted");
                }
                break;
            case CircuitBreakerState.HalfOpen:
                try
                {
                    action.Invoke();
                    State = CircuitBreakerState.Closed;
                }
                catch (Exception ex)
                {
                    HandleFailure(ex);
                    State = CircuitBreakerState.Open;
                }
            break;
        default:
                throw new InvalidOperationException("Invalid circuit breaker state");
        }
    }

    private void HandleFailure(Exception ex)
    {
        failures++;
        lastFailureTime = DateTime.Now;
        Console.WriteLine($"Failure #{failures}: {ex.Message}");

        if (failures >= FailureThreshold)
        {
            OpenCircuit();
        }
    }

    private void OpenCircuit()
    {
        State = CircuitBreakerState.Open;
        Console.WriteLine("Circuit is open. Entering Open state");
    }

    private bool IsTimeoutExpired()
    {
        TimeSpan elapsed = DateTime.Now - lastFailureTime;
        return elapsed.TotalMilliseconds >= ResetTimeout;
    }
}
