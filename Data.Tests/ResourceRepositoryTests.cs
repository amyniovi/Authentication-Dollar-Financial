using Dollar.Authentication.Domain;
using System;
using System.Linq;
using Xunit;

namespace Dollar.Authentication.Data.Tests
{
    public class ResourceRepositoryTests : IDisposable
    {
        private readonly TestableResourceRepository _resourceRepository = TestableResourceRepository.Create();

        public void Dispose()
        {
            _resourceRepository.DeleteTestIdentities();
        }

        [Fact]
        public void GetAll_ValidConditions_ReturnsCorrectlyMappedData()
        {
            // Arrange
            var expected = _resourceRepository.PersistNewValidIdentity();

            // Act
            var actual = _resourceRepository.GetAll().Single();

            // Assert
            AssertValidAndEqual(expected, actual);
        }

        [Fact]
        public void GetById_ValidConditions_ReturnsCorrectlyMappedData()
        {
            // Arrange
            var expected = _resourceRepository.PersistNewValidIdentity();

            // Act
            var actual = _resourceRepository.GetById(expected.Id);

            // Assert
            AssertValidAndEqual(expected, actual);
        }

        [Fact]
        public void GetByName_ValidConditions_ReturnsCorrectlyMappedData()
        {
            // Arrange
            var expected = _resourceRepository.PersistNewValidIdentity();

            // Act
            var actual = _resourceRepository.GetByName(expected.Name);

            // Assert
            AssertValidAndEqual(expected, actual);
        }

        [Fact]
        public void Delete_DeleteById_OldEntityCannotBeRead()
        {
            // Arrange
            var expected = _resourceRepository.PersistNewValidIdentity();
            var id = expected.Id;

            // Act
            var actualBeforeDeletion = _resourceRepository.GetById(id);
            _resourceRepository.Delete(id);
            var actualAfterDeletion = _resourceRepository.GetById(id);

            // Assert
            Assert.NotNull(actualBeforeDeletion);
            Assert.Null(actualAfterDeletion);
        }

        [Fact]
        public void Delete_DeleteByObject_OldEntityCannotBeRead()
        {
            // Arrange
            var expected = _resourceRepository.PersistNewValidIdentity();
            var id = expected.Id;

            // Act
            var actualBeforeDeletion = _resourceRepository.GetById(id);
            _resourceRepository.Delete(expected);
            var actualAfterDeletion = _resourceRepository.GetById(id);

            // Assert
            Assert.NotNull(actualBeforeDeletion);
            Assert.Null(actualAfterDeletion);
        }


        private void AssertValidAndEqual(Resource expected, Resource actual)
        {
            Assert.NotEqual(Guid.Empty, actual.Id);
            Assert.NotNull(actual.Name);
            Assert.NotNull(actual.ActiveSecurityChecks);
            Assert.NotEqual(expected.MaximumFailedLoginAttempts, 0);
            Assert.NotNull(expected.ActiveSecurityChecks.Single());
            Assert.NotEqual(expected.ActiveSecurityChecks.Single().Key, "");
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.MaximumFailedLoginAttempts, actual.MaximumFailedLoginAttempts);
            Assert.Equal(expected.ActiveSecurityChecks.Single(), actual.ActiveSecurityChecks.Single());
        }
    }
}