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
        public void Validate_Interest_calculator_through_Service()
        {

            // Arrange
            var _simleInModel = A.Fake<SimpleInterestModel>();
            _simleInModel.Principal = 50000;
            _simleInModel.Year = 10;
            _simleInModel.RateOfInterest = 8;
           
            var _sinterestObj = A.Fake<SimpleInterstService>();
            var actualresult = (_simleInModel.Principal * _simleInModel.Year * _simleInModel.RateOfInterest) / 100;
            var _result = 0;

            //Act

           
            var testresult1 = _sinterestObj.CalculateSimpleInterest(_simleInModel);
            A.CallTo(() => _simpleInterestService.CalculateSimpleInterest(_simleInModel)).Returns(_result);



            //Assert

            A.CallTo(() => _simpleInterestService.CalculateSimpleInterest(_simleInModel)).MustHaveHappenedOnceOrLess();
            Assert.AreEqual(testresult1, actualresult);
            Assert.IsNotNull(testresult1);
            Assert.AreNotEqual(testresult1, 1);
        }

        [TestMethod]
        public void Validate_Interest_calculator_through_Controller()
        {

            // Arrange
            var sinterestObj = A.Fake<SimpleInterstService>();
            var _simleInModel = A.Fake<SimpleInterestModel>();
            _simleInModel.Principal = 50000;
            _simleInModel.Year = 20;
            _simleInModel.RateOfInterest = 8;
            // var _simpleInterestService = A.Fake<ISimpleInterstService>();

            //var _simpleInterestController = new SimpleInterestController(_simpleInterestService);

            
            var actualresult = (_simleInModel.Principal * _simleInModel.Year * _simleInModel.RateOfInterest) / 100;
           
            
          
            var _simpleInterestControllr = new SimpleInterestController(sinterestObj);
           
            //Act

            
            var testresult2 = _simpleInterestControllr.Get(_simleInModel);
            
            //Assert

            A.CallTo(() => _simpleInterestService.CalculateSimpleInterest(_simleInModel)).MustHaveHappenedOnceOrLess();
           
            Assert.AreEqual(actualresult, testresult2);
            Assert.AreNotEqual(testresult2, 1);
        }

    }
}
