using GorillaRoasters.ViewModels;
using NUnit.Framework;
using Moq;
using Xamarin.Forms;
using System.Windows.Input;
using GorillaRoasters.Services;
using System.Collections.ObjectModel;
using GorillaRoasters.Models.StarWarModels.UIModels;
using System.Collections.Generic;
using GorillaRoasters.Models.StarWarModels.DALModels;

namespace GorillaRoastersTests
{
    [TestFixture]
    public class StarWarsPageVMTests
    {
        private StarWarsPageVM _viewModel;
        private Mock<IStarWarsService> _service;

        [SetUp]
        public void Setup()
        {
            _viewModel = new StarWarsPageVM();
            _service = new Mock<IStarWarsService>(MockBehavior.Strict);
            _viewModel.Service = _service.Object;
        }

        [Test]
        public void ConstructorTest()
        {
            if (_viewModel != null &&
                _viewModel.Service != null &&
                _viewModel.GetCharactersCommand != null &&
                _viewModel.PushCharacterCommand != null &&
                _viewModel.Characters != null)
                Assert.Pass();
            else
                Assert.Fail();
        }
       
        [Test, TestCaseSource(nameof(GetCharactersCommandExecuteTestData))]
        public void GetCharactersCommandExecuteTest(CaractersResponseModel responseModel, ObservableCollection<CharacterModel> models)
        {
            //Arrange
           var result = _service.Setup(s => s.GetCharacters()).ReturnsAsync(responseModel);

            //Act
             _viewModel.GetCharactersCommandExecute();

            //Assert
            _service.Verify(s => s.GetCharacters(), Times.Once);
            Assert.AreEqual(models, _viewModel.Characters);
        }

        [Test]
        public void PushCharacterCommandExecuteTest()
        {
            //Arrange
            _service.Setup(s => s.PushCharacter(It.IsAny<CharacterInfoModel>())).ReturnsAsync(true);

            //Act
            _viewModel.PushCharacterCommandExecute();

            //Assert
            _service.Verify(s => s.PushCharacter(It.IsAny<CharacterInfoModel>()), Times.Once);
        }

        public static IEnumerable<TestCaseData> GetCharactersCommandExecuteTestData()
        {
            yield return new TestCaseData(
                new CaractersResponseModel
                {
                    Results = new List<CharacterInfoModel>
                    {
                        new CharacterInfoModel
                        {
                            Name = "fsdwef",
                            Height = 123,
                            Mass = 213,
                            Gender = "efrwef"
                        }
                    }
                }, new ObservableCollection<CharacterModel>
                {
                    new CharacterModel
                    {
                        Name = "fsdwef",
                        Height = 123,
                        Mass = 213,
                        Gender = "efrwef"
                    }
                }
                );
            yield return new TestCaseData(
                new CaractersResponseModel
                {
                    Results = new List<CharacterInfoModel>
                    {
                        new CharacterInfoModel
                        {
                            Name = "fsdw32ef",
                            Height = 1233,
                            Mass = 23,
                            Gender = "efrsdfwef"
                        }
                    }
                }, new ObservableCollection<CharacterModel>
                  {
                    new CharacterModel
                    {
                        Name = "fsdw32ef",
                        Height = 1233,
                        Mass = 23,
                        Gender = "efrsdfwef"
                    }
                }
                );
        }
    }
}