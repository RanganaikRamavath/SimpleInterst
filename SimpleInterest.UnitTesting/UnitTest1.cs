using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInterest.Controllers;
using SimpleInterest.Service.Interface;
using SimpleInterest.Service;
//using Xunit;



namespace SimpleInterest.UnitTesting
{
    [TestClass]
    public class UnitTest1
    {

        private readonly ISimpleInterstService _simpleInterestService;
         private readonly SimpleInterestController _simpleInterestController;
         public UnitTest1()
         {
              this._simpleInterestService = A.Fake<ISimpleInterstService>();

              this._simpleInterestController = new SimpleInterestController(_simpleInterestService);

         }
        
        [TestMethod]
        public void Validate_Interest_calculator()
        {

            // Arrange
            var _simleInModel = A.Fake<SimpleInterestModel>();
            _simleInModel.Principal = 50000;
            _simleInModel.Year = 10;
            _simleInModel.RateOfInterest = 8;
            // var _simpleInterestService = A.Fake<ISimpleInterstService>();

            //var _simpleInterestController = new SimpleInterestController(_simpleInterestService);

            var sinterestObj = A.Fake<SimpleInterstService>();
            var actualresult = (_simleInModel.Principal * _simleInModel.Year * _simleInModel.RateOfInterest) / 100;
            var _result = 0;
            var testresult1 = sinterestObj.CalculateSimpleInterest(_simleInModel);
            A.CallTo(() => _simpleInterestService.CalculateSimpleInterest(_simleInModel)).Returns(_result);
            var _simpleInterestController = new SimpleInterestController(_simpleInterestService);
            var _simpleInterestContr = new SimpleInterestController(sinterestObj);
            //Act

            //_simleInModel.Year = 12;
            var testresult2 = _simpleInterestContr.Get(_simleInModel);

            //Assert

            A.CallTo(() => _simpleInterestService.CalculateSimpleInterest(_simleInModel)).MustHaveHappenedOnceOrLess();
            Assert.AreEqual(testresult1, actualresult);
            Assert.AreEqual(actualresult, testresult2);
            Assert.AreNotEqual(testresult2, 1);
        }



    }
}
