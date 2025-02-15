using Moq;
using RealEstateListing.Application.Interfaces.Repositories;
using RealEstateListing.Application.Services;
using RealEstateListing.Application.Validators;
using RealEstateListing.Domain.Entities;

namespace RealEstateListing.UnitTests
{
    [Trait(nameof(RealEstateListing), nameof(ListingServiceTests))]
    public class ListingServiceTests
    {
        private readonly Mock<IRepositoryBase<Listing>> _mockRepository;
        private readonly ListingService _listingService;

        public ListingServiceTests()
        {
            _mockRepository = new Mock<IRepositoryBase<Listing>>();
            var unitOfWork = new Mock<IUnitOfWork>();

            _listingService = new ListingService(_mockRepository.Object, unitOfWork.Object);
        }

        [Fact]
        public async Task Should_Return_List_Of_Listings()
        {
            // Arrange
            var listings = SetupMockRepositoryData();
            _mockRepository.Setup(repo => repo.GetAllAsync(It.IsAny<CancellationToken>())).ReturnsAsync(listings);

            // Act
            var result = await _listingService.GetAllAsync(CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            _mockRepository.Verify(r => r.GetAllAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Should_Return_Only_One_Listing_Item()
        {
            // Arrange
            var listing = SetupMockRepositoryData().First();
            _mockRepository.Setup(repo => repo.GetByIdAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(listing);

            // & Act
            var result = await _listingService.GetByIdAsync(1, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            _mockRepository.Verify(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Should_ReturnsNull_WhenNotExists()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetByIdAsync(99, It.IsAny<CancellationToken>())).ReturnsAsync((Listing?)null);

            // Act
            var result = await _listingService.GetByIdAsync(99, CancellationToken.None);

            // Assert
            Assert.Null(result);
            _mockRepository.Verify(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Should_AddListing_And_Return_The_Entity_Added()
        {
            // Arrange
            var request = new Listing { Id = 3, Title = "New Test", Price = "30.0m" };

            // Act
            var result = await _listingService.AddAsync(request, CancellationToken.None);

            // Assert
            Assert.Equal(request, result.Data);
            _mockRepository.Verify(repo => repo.AddAsync(request, It.IsAny<CancellationToken>()), Times.Once);
            _mockRepository.Verify(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Should_Not_Add_Listing_When_Id_Exists()
        {
            // Arrange
            var item = SetupMockRepositoryData().First();
            _mockRepository.Setup(repo => repo.GetByIdAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(item);

            var request = new Listing { Id = 1, Title = "New Test", Price = "30.0m" };

            // Act
            var result = await _listingService.AddAsync(request, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            _mockRepository.Verify(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Once);
            _mockRepository.Verify(repo => repo.AddAsync(request, It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task Should_Delete_When_Listing_Exists()
        {
            // Arrange
            var listing = SetupMockRepositoryData().First();
            _mockRepository.Setup(repo => repo.GetByIdAsync(1, It.IsAny<CancellationToken>())).ReturnsAsync(listing);

            // Act
            var result = await _listingService.DeleteAsync(1, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            _mockRepository.Verify(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Once);
            _mockRepository.Verify(repo => repo.DeleteAsync(It.IsAny<Listing>()), Times.Once);
        }

        [Fact]
        public async Task Should_Not_Delete_When_Listing_NotExists()
        {
            // Arrange
            _mockRepository.Setup(repo => repo.GetByIdAsync(99, It.IsAny<CancellationToken>())).ReturnsAsync((Listing?)null);

            // Act
            var result = await _listingService.DeleteAsync(99, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            _mockRepository.Verify(r => r.GetByIdAsync(It.IsAny<int>(), It.IsAny<CancellationToken>()), Times.Once);
            _mockRepository.Verify(repo => repo.DeleteAsync(It.IsAny<Listing>()), Times.Never);
        }

        [Fact]
        public async Task Should_Return_Error_When_Model_Is_Invalid()
        {
            // Arrange
            var request = new Listing { Id = 1, Title = "", Price = "0" };
            var validator = new ListingValidator();

            // Act
            var validatorResult = await validator.ValidateAsync(request, CancellationToken.None);

            // Assert
            Assert.False(validatorResult.IsValid);
            Assert.Equal(2, validatorResult.Errors.Count);
        }

        private static List<Listing> SetupMockRepositoryData()
        {
            return
            [
                new() { Id = 1, Title = "Item 1", Price = "10", Description = "Fake Description added here" },
                new() { Id = 2, Title = "Item 2", Price = "20"}
            ];
        }
    }
}