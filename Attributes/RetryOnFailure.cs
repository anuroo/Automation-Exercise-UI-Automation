using NUnit.Framework;

public class RetryOnFailureAttribute: RetryAttribute
{
    public RetryOnFailureAttribute(): base(2)
    {
        
    }
}