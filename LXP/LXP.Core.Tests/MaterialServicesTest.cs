//using NUnit.Framework;
//using Moq;
//using System;
//using System.Threading.Tasks;
//using LXP.Common.Entities;
//using LXP.Common.ViewModels;
//using LXP.Core.IServices;
//using LXP.Data.IRepository;
//using LXP.Core.Services;

//namespace YourNamespace.Tests
//{
//    [TestFixture]
//    public class MaterialServicesTests
//    {
//        private Mock<IMaterialRepository> _materialRepositoryMock;
//        private Mock<ICourseTopicRepository> _courseTopicRepositoryMock;
//        private MaterialServices _materialServices;

//        [SetUp]
//        public void Setup()
//        {
//            _materialRepositoryMock = new Mock<IMaterialRepository>();
//            _courseTopicRepositoryMock = new Mock<ICourseTopicRepository>();
//            _materialServices = new MaterialServices(_materialRepositoryMock.Object, _courseTopicRepositoryMock.Object);
//        }

//        [Test]
//        public async Task AddMaterial_ValidMaterial_AddsMaterial()
//        {
//            // Arrange
//            var materialViewModel = new MaterialViewModel
//            {
//                MaterialName = "New Material",
//                TopicId = "TopicId"
//            };

//            _courseTopicRepositoryMock.Setup(x => x.GetTopicByTopicId(It.IsAny<string>())).Returns(new Topic());
//            _materialRepositoryMock.Setup(x => x.AnyMaterialByMaterialNameAndTopic(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(false));

//            // Act
//            await _materialServices.AddMaterial(materialViewModel);

//            // Assert
//            _materialRepositoryMock.Verify(x => x.AddMaterial(It.IsAny<Material>()), Times.Once);
//        }

//        [Test]
//        public async Task AddMaterial_ExistingMaterial_ThrowsException()
//        {
//            // Arrange
//            var materialViewModel = new MaterialViewModel
//            {
//                MaterialName = "Existing Material",
//                TopicId = "TopicId"
//            };

//            _materialRepositoryMock.Setup(x => x.AnyMaterialByMaterialNameAndTopic(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(true));

//            // Act + Assert
//            Assert.ThrowsAsync<InvalidOperationException>(async () => await _materialServices.AddMaterial(materialViewModel));
//            _materialRepositoryMock.Verify(x => x.AddMaterial(It.IsAny<Material>()), Times.Never);
//        }

//        [Test]
//        public void GetAllMaterialDetailsByTopic_ValidTopicId_ReturnsMaterialDetails()
//        {
//            // Arrange
//            var topicId = "TopicId";
//            var materials = new List<Material>
//            {
//                new Material { MaterialId = Guid.NewGuid(), MaterialName = "Material 1", TopicId = topicId },
//                new Material { MaterialId = Guid.NewGuid(), MaterialName = "Material 2", TopicId = topicId }
//            };

//            _materialRepositoryMock.Setup(x => x.GetAllMaterialByTopic(It.IsAny<string>())).Returns(materials);

//            // Act
//            var result = _materialServices.GetAllMaterialDetailsByTopic(topicId);

//            // Assert
//            Assert.IsNotNull(result);
//            Assert.AreEqual(materials.Count, result.Count);
//        }

//        [Test]
//        public async Task GetMaterialByMaterialNameAndTopic_ValidInputs_ReturnsMaterial()
//        {
//            // Arrange
//            var materialName = "Material 1";
//            var topicId = "TopicId";
//            var material = new Material { MaterialId = Guid.NewGuid(), MaterialName = materialName, TopicId = topicId };

//            _materialRepositoryMock.Setup(x => x.GetMaterialByMaterialNameAndTopic(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(material));

//            // Act
//            var result = await _materialServices.GetMaterialByMaterialNameAndTopic(materialName, topicId);

//            // Assert
//            Assert.IsNotNull(result);
//            Assert.AreEqual(materialName, result.MaterialName);
//            Assert.AreEqual(topicId, result.TopicId);
//        }
//    }
//}