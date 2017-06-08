using Dollar.Authentication.Domain;
using System;
using System.Linq;
using Xunit;

namespace Dollar.Authentication.Data.Tests
{
    public class IdentityRepositoryTests : IDisposable
    {
        private readonly TestableIdentityRepository _identityRepository = TestableIdentityRepository.Create();

        public void Dispose()
        {
            _identityRepository.DeleteTestIdentities();
        }

        [Fact]
        public void GetAll_ValidConditions_ReturnsCorrectlyMappedData()
        {
            // Arrange
            var expected = _identityRepository.PersistNewValidIdentity();

            // Act
            var actual = _identityRepository.GetAll().Single();

            // Assert
            AssertValidAndEqual(expected, actual);
        }

        [Fact]
        public void GetById_ValidConditions_ReturnsCorrectlyMappedData()
        {
            // Arrange
            var expected = _identityRepository.PersistNewValidIdentity();

            // Act
            var actual = _identityRepository.GetById(expected.Id);

            // Assert
            AssertValidAndEqual(expected, actual);
        }

        [Fact]
        public void GetByResourceAndUserId_ValidConditions_ReturnsCorrectlyMappedData()
        {
            // Arrange
            var expected = _identityRepository.PersistNewValidIdentity();

            // Act
            var actual = _identityRepository.GetByResourceAndUserId(expected.ResourceName, expected.UserId);

            // Assert
            AssertValidAndEqual(expected, actual);
        }

        [Fact]
        public void GetByResource_ValidConditions_ReturnsCorrectlyMappedData()
        {
            // Arrange
            var expected1 = _identityRepository.PersistNewValidIdentity();
            var expected2 = _identityRepository.PersistNewValidIdentity();

            // Act
            var actual = _identityRepository.GetByResource(expected1.ResourceName)
                .ToList();

            // Assert
            Assert.Equal(expected1.ResourceName, expected2.ResourceName);
            Assert.Equal(2, actual.Count());
            AssertValidAndEqual(expected1, actual.First());
            AssertValidAndEqual(expected2, actual.Last());
        }

        [Fact]
        public void Delete_DeleteById_OldEntityCannotBeRead()
        {
            // Arrange
            var expected = _identityRepository.PersistNewValidIdentity();
            var id = expected.Id;

            // Act
            var actualBeforeDeletion = _identityRepository.GetById(id);
            _identityRepository.Delete(id);
            var actualAfterDeletion = _identityRepository.GetById(id);

            // Assert
            Assert.NotNull(actualBeforeDeletion);
            Assert.Null(actualAfterDeletion);
        }

        [Fact]
        public void Delete_DeleteByObject_OldEntityCannotBeRead()
        {
            // Arrange
            var expected = _identityRepository.PersistNewValidIdentity();
            var id = expected.Id;

            // Act
            var actualBeforeDeletion = _identityRepository.GetById(id);
            _identityRepository.Delete(expected);
            var actualAfterDeletion = _identityRepository.GetById(id);

            // Assert
            Assert.NotNull(actualBeforeDeletion);
            Assert.Null(actualAfterDeletion);
        }

        private void AssertValidAndEqual(Identity expected, Identity actual)
        {
            Assert.NotEqual(Guid.Empty, actual.Id);
            Assert.NotNull(actual.ResourceName);
            Assert.NotNull(actual.UserId);
            Assert.NotNull(actual.LastSuccessfulLogin);
            Assert.NotNull(expected.Passwords.Single());
            Assert.NotEqual(expected.Passwords.Single().Hash, "");
            Assert.NotNull(expected.SecurityChecks.Single());
            Assert.NotEqual(expected.SecurityChecks.Single().Key, "");
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.ResourceName, actual.ResourceName);
            Assert.Equal(expected.UserId, actual.UserId);
            Assert.Equal(expected.LastSuccessfulLogin, actual.LastSuccessfulLogin);
            Assert.Equal(expected.AccountLocked, actual.AccountLocked);
            Assert.Equal(expected.CreatedOn, actual.CreatedOn);
            Assert.Equal(expected.FailedLoginAttempts.Single(), actual.FailedLoginAttempts.Single());
            Assert.Equal(expected.Passwords.Single(), actual.Passwords.Single());
            Assert.Equal(expected.SecurityChecks.Single(), actual.SecurityChecks.Single());
        }
    }
}