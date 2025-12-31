using NUnit.Framework;
using NUnit.Framework.Internal;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using NUnit.Framework.Internal.Commands;
using static NUnit.Framework.RetryAttribute;

public class RetryOnFailureAttribute: NUnitAttribute,IWrapSetUpTearDown
{
    private readonly int _retryCount;
    public RetryOnFailureAttribute(int retryCount=2)
    {
        _retryCount=retryCount;
    }
    public TestCommand Wrap(TestCommand command)
    {
        return new RetryCommand(command,_retryCount);
    }
    private class RetryCommand: DelegatingTestCommand
    {
        private readonly int _retryCount;
        public RetryCommand(TestCommand innerCommand,int retryCount):base(innerCommand)
        {
            _retryCount=retryCount;
        }
        public override TestResult Execute(TestExecutionContext context)
        {
            int attempt=1;
            while(attempt<=_retryCount+1)
            {
                Console.WriteLine($"Attempt {attempt} for test: {context.CurrentTest.Name}");
                context.CurrentResult=innerCommand.Execute(context);
                if(context.CurrentResult.ResultState==ResultState.Success)
                {
                    if(attempt>1)
                    {
                        Console.WriteLine($"Test Passed on:{attempt-1} retry");
                        return context.CurrentResult;
                    }
                }
                Console.WriteLine($"Attempt failed: {context.CurrentResult.Message}");
                attempt++;
            }
            return context.CurrentResult;
        }
    }

}