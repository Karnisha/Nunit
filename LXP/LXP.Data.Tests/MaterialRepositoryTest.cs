using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LXP.Common.Entities;
using LXP.Data.DBContexts;
using LXP.Data.IRepository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace LXP.Data.Repository.Tests
{
    [TestFixture]
    public class MaterialRepositoryTest
    {
        private DbContextOptions<LXPDbContext> _options;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<LXPDbContext>()
                .UseInMemoryDatabase(databaseName: "lxp")
                .Options;
            var topicName = "Test Topic";
            using (var context = new LXPDbContext(_options))
            {
                context.Materials.AddRange(
                    new Material
                    {
                        MaterialId = Guid.NewGuid(),
                        Name = "Material 1",
                        Duration = 1,
                        IsActive = true,
                        CreatedBy = "Karni",
                        CreatedAt = DateTime.Now,
                        ModifiedBy = "karikalan",
                        ModifiedAt = DateTime.Now
                    },
                    new Material
                    {
                        MaterialId = Guid.NewGuid(),
                        Name = "Material 2",
                        Duration = 1,
                        IsActive = true,
                        CreatedBy = "Karni",
                        CreatedAt = DateTime.Now,
                        ModifiedBy = "karikalan",
                        ModifiedAt = DateTime.Now
                    }
                );
                context.SaveChanges();
            }
        }

        [Test]
        public async Task AddMaterial_ValidMaterial_AddsMaterialToContextAndSavesChanges()
        {
            // Arrange
            using (var context = new LXPDbContext(_options))
            {
                var repository = new MaterialRepository(context);
                var materialToAdd = new Material
                {
                    MaterialId = Guid.NewGuid(),
                    Name = "Test Material",
                    Duration = 1,
                    IsActive = true,
                    CreatedBy = "Karni",
                    CreatedAt = DateTime.Now,
                    ModifiedBy = "karikalan",
                    ModifiedAt = DateTime.Now
                };

                // Act
                await repository.AddMaterial(materialToAdd);

                // Assert
                var addedMaterial = await context.Materials.FindAsync(materialToAdd.MaterialId);
                Assert.IsNotNull(addedMaterial);
                Assert.AreEqual(materialToAdd.Name, addedMaterial.Name);
                Assert.AreEqual(materialToAdd.Topic, addedMaterial.Topic);
                Assert.AreEqual(materialToAdd.IsActive, addedMaterial.IsActive);
            }
        }

        [Test]
        public async Task AnyMaterialByMaterialNameAndTopic_ExistingMaterial_ReturnsTrue()
        {
            // Arrange
            using (var context = new LXPDbContext(_options))
            {
                var repository = new MaterialRepository(context);

                // Act
                var result = await repository.AnyMaterialByMaterialNameAndTopic("Material 1", Topic.Math);

                // Assert
                Assert.IsTrue(result);
            }
        }

        [Test]
        public async Task AnyMaterialByMaterialNameAndTopic_NonExistingMaterial_ReturnsFalse()
        {
            // Arrange
            using (var context = new LXPDbContext(_options))
            {
                var repository = new MaterialRepository(context);

                // Act
                var result = await repository.AnyMaterialByMaterialNameAndTopic("Non-existing Material", Topic.English);

                // Assert
                Assert.IsFalse(result);
            }
        }

        [Test]
        public async Task GetMaterialByMaterialNameAndTopic_ExistingMaterial_ReturnsMaterial()
        {
            // Arrange
            using (var context = new LXPDbContext(_options))
            {
                var repository = new MaterialRepository(context);

                // Act
                var result = await repository.GetMaterialByMaterialNameAndTopic("Material 2", Topic.Science);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual("Material 2", result.Name);
                Assert.AreEqual(Topic.Science, result.Topic);
            }
        }

        [Test]
        public async Task GetMaterialByMaterialNameAndTopic_NonExistingMaterial_ReturnsNull()
        {
            // Arrange
            using (var context = new LXPDbContext(_options))
            {
                var repository = new MaterialRepository(context);

                // Act
                var result = await repository.GetMaterialByMaterialNameAndTopic("Non-existing Material", Topic.English);

                // Assert
                Assert.IsNull(result);
            }
        }

        [Test]
        public void GetAllMaterialDetailsByTopic_ExistingTopic_ReturnsMaterials()
        {
            // Arrange
            using (var context = new LXPDbContext(_options))
            {
                var repository = new MaterialRepository(context);

                // Act
                var result = repository.GetAllMaterialDetailsByTopic(Topic.Math);

                // Assert
                Assert.AreEqual(1, result.Count());
                Assert.AreEqual(Topic.Math, result.First().Topic);
            }
        }

        [Test]
        public void GetAllMaterialDetailsByTopic_NonExistingTopic_ReturnsEmptyList()
        {
            // Arrange
            using (var context = new LXPDbContext(_options))
            {
                var repository = new MaterialRepository(context);

                // Act
                var result = repository.GetAllMaterialDetailsByTopic(Topic.English);

                // Assert
                Assert.AreEqual(0, result.Count());
            }
        }
    }
}