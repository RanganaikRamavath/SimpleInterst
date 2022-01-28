using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInterest.Controllers;
using SimpleInterest.Service.Interface;
using Xunit;



namespace SimpleInterest.UnitTesting
{
    [TestClass]
    public class UnitTest1
    {

        /* private  ISimpleInterstService _simpleInterestService;
         private  SimpleInterestController _simpleInterestController;
         public UnitTest1()
         {
              _simpleInterestService = A.Fake<ISimpleInterstService>();

              _simpleInterestController = new SimpleInterestController(_simpleInterestService);

         }*/

        [Fact]
        public void Validate_Interest_calculator()
        {
            // Arrange
            var _simpleInterestService = A.Fake<ISimpleInterstService>();

            var _simpleInterestController = new SimpleInterestController(_simpleInterestService);

            var _simleInModel = A.Fake<SimpleInterestModel>();
            _simleInModel.Principal = 50000;
            _simleInModel.Year = 10;
            _simleInModel.RateOfInterest = 8;
            var actualresult = (_simleInModel.Principal * _simleInModel.Year * _simleInModel.RateOfInterest) / 100;
            var _result = 0;
            A.CallTo(() => _simpleInterestService.CalculateSimpleInterest(_simleInModel)).Returns(_result);


            //Act
            var resultInterest = _simpleInterestController.Get(_simleInModel);

            //Assert

            A.CallTo(() => _simpleInterestService.CalculateSimpleInterest(_simleInModel)).MustHaveHappenedOnceExactly();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(resultInterest, actualresult);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreNotEqual(resultInterest, 0);
        }


       /* [Fact]
        public void TestMethod1()
        {
            var simpleInterestService = A.Fake<ISimpleInterstService>();

            var simpleInterest = new SimpleInterestController(simpleInterestService);

        }
       */

    }
}