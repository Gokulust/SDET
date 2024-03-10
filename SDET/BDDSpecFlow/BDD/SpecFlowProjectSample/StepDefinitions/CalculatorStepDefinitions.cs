using NUnit.Framework;

namespace SpecFlowProjectSample.StepDefinitions
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        private int firstNumber,secondNumber,sum,difference;
        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
           firstNumber = number;
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            secondNumber = number;
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            sum = firstNumber + secondNumber;
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
          Assert.AreEqual(sum, result);
        }

        [When(@"the second number is subtracted from first number")]
        public void WhenTheSecondNumberIsSubtractedFromFirstNumber()
        {
            difference=secondNumber- firstNumber;
        }

        [Then(@"the difference should be (.*)")]
        public void ThenTheDifferenceShouldBe(int result)
        {
            Assert.AreEqual(difference, result);
        }

    }
}