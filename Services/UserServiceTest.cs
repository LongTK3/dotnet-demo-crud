using Moq;
using UserManagementAPI.Models;
using UserManagementAPI.Repositories;
using UserManagementAPI.Repositories.Common.UnitOfWork;
using UserManagementAPI.Repositories.Interfaces;
using Xunit;

namespace UserManagementAPI.Services;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _userRepoMock;
    private readonly UserService _userService;

    private readonly Mock<IUnitOfWork> _unitOfWorkMock;

    public UserServiceTests()
    {
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var userService = new UserService(mockUnitOfWork.Object);

        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _userRepoMock = new Mock<IUserRepository>();

        _unitOfWorkMock.Setup(u => u.Users).Returns(_userRepoMock.Object);

        _userService = new UserService(_unitOfWorkMock.Object);
    }

    [Fact]
    public async Task GetUserById_ShouldReturnUser_WhenUserExists()
    {
        // Arrange
        var userId = 1;
        var user = new User { Id = userId, FirstName = "Nguyễn A", LastName = "Văn An", Email = "an.nguyen@example.com" };

        _userRepoMock.Setup(repo => repo.GetUserById(userId)).ReturnsAsync(user);

        // Act
        var result = await _userService.GetUserById(userId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Nguyễn A Văn An", result.FullName);
        Assert.Equal("an.nguyen@example.com", result.Email);
    }

    // ✅ Test: GetAllUsers (Get all user and user's information)
    [Fact]
    public async Task GetAllUsers_ShouldReturnListOfUsers_WithFullDetails()
    {
        // Arrange
        var users = new List<User>
        {
            new User { Id = 1, FirstName = "Nguyễn A", LastName = "Văn An", Email = "an.nguyen@example.com", PhoneNumber = "0912345678", ZipCode = "700000" },
            new User { Id = 2, FirstName = "Trần", LastName = "Thị Bích", Email = "bich.tran@example.com", PhoneNumber = "0987654321", ZipCode = "100000" },
            new User { Id = 3, FirstName = "Phạm", LastName = "Thanh Hùng", Email = "hung.pham@example.com", PhoneNumber = "0905123456", ZipCode = "550000" },
            new User { Id = 4, FirstName = "Lê", LastName = "Hồng Nhung", Email = "nhung.le@example.com", PhoneNumber = "0933123456", ZipCode = "600000" },
            new User { Id = 6, FirstName = "Bùi", LastName = "Thị Mai", Email = "mai.bui@example.com", PhoneNumber = "0978899001", ZipCode = "120000" },
            new User { Id = 7, FirstName = "Hoàng", LastName = "Anh Tuấn", Email = "anh.hoang@example.com", PhoneNumber = "0967788992", ZipCode = "150000" },
            new User { Id = 8, FirstName = "Vũ", LastName = "Quang Huy", Email = "huy.vu@example.com", PhoneNumber = "0911223344", ZipCode = "250000" },
            new User { Id = 9, FirstName = "Lý", LastName = "Thị Lan", Email = "lan.ly@example.com", PhoneNumber = "0933445566", ZipCode = "400000" },
            new User { Id = 10, FirstName = "Đỗ", LastName = "Thành Công", Email = "cong.do@example.com", PhoneNumber = "0944556677", ZipCode = "350000" },
            new User { Id = 1001, FirstName = "aaaaaaa", LastName = "aavvvv", Email = "longtk@onepay.vn", PhoneNumber = "0966069299", ZipCode = "11400" },
            new User { Id = 1002, FirstName = "a", LastName = "c", Email = "longtk@onepay.vn", PhoneNumber = "0966069299", ZipCode = "11400" }
        };

        _userRepoMock.Setup(repo => repo.GetAllUsers()).ReturnsAsync(users);

        // Act
        var result = await _userService.GetAllUsers();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(11, result.Count());
        Assert.Contains(result, u => u.Id == 1 && u.FullName == "Nguyễn A Văn An");
        Assert.Contains(result, u => u.Id == 2 && u.FullName == "Trần Thị Bích");
        Assert.Contains(result, u => u.Id == 1001 && u.Email == "longtk@onepay.vn");
    }

    [Fact]
    public async Task AddUser_ShouldReturnUser_WhenUserIsAdded()
    {
        // Arrange
        var newUser = new User
        {
            Id = 1003,
            FirstName = "Nguyễn A",
            LastName = "Văn An",
            Email = "an.nguyen@example.com",
            PhoneNumber = "0912345678",
            ZipCode = "700000"
        };

        _userRepoMock.Setup(repo => repo.AddUser(It.IsAny<User>())).Returns(Task.CompletedTask);
        _unitOfWorkMock.Setup(uow => uow.SaveChangesAsync()).ReturnsAsync(1);

        // Act
        var result = await _userService.AddUser(newUser);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Nguyễn A", result.FirstName);
        Assert.Equal("Văn An", result.LastName);
        _userRepoMock.Verify(repo => repo.AddUser(It.IsAny<User>()), Times.Once);
        _unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task UpdateUser_ShouldReturnUpdatedUser_WhenUserExists()
    {
        // Arrange
        var userId = 1;
        var existingUser = new User
        {
            Id = userId,
            FirstName = "Nguyễn A",
            LastName = "Văn An",
            Email = "an.nguyen@example.com",
            PhoneNumber = "0912345678",
            ZipCode = "700000"
        };

        var updatedUser = new User
        {
            Id = userId,
            FirstName = "Nguyễn B",
            LastName = "Văn Bình",
            Email = "binh.nguyen@example.com",
            PhoneNumber = "0987654321",
            ZipCode = "100000"
        };

        _userRepoMock.Setup(repo => repo.GetUserById(userId)).ReturnsAsync(existingUser);
        _unitOfWorkMock.Setup(uow => uow.SaveChangesAsync()).ReturnsAsync(1);

        // Act
        var result = await _userService.UpdateUser(userId, updatedUser);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Nguyễn B", result.FirstName);
        Assert.Equal("Văn Bình", result.LastName);
        Assert.Equal("binh.nguyen@example.com", result.Email);
        Assert.Equal("0987654321", result.PhoneNumber);
        Assert.Equal("100000", result.ZipCode);

        _userRepoMock.Verify(repo => repo.GetUserById(userId), Times.Once);
        _unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task UpdateUser_ShouldReturnNull_WhenUserDoesNotExist()
    {
        // Arrange
        var userId = 99;
        var updatedUser = new User
        {
            Id = userId,
            FirstName = "Nguyễn B",
            LastName = "Văn Bình",
            Email = "binh.nguyen@example.com",
            PhoneNumber = "0987654321",
            ZipCode = "100000"
        };

        _userRepoMock.Setup(repo => repo.GetUserById(userId)).ReturnsAsync((User?)null);

        // Act
        var result = await _userService.UpdateUser(userId, updatedUser);

        // Assert
        Assert.Null(result);
        _userRepoMock.Verify(repo => repo.GetUserById(userId), Times.Once);
        _unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Never);
    }

    [Fact]
    public async Task DeleteUser_ShouldReturnTrue_WhenUserExists()
    {
        // Arrange
        var userId = 1;
        var existingUser = new User
        {
            Id = userId,
            FirstName = "Nguyễn A",
            LastName = "Văn An",
            Email = "an.nguyen@example.com",
            PhoneNumber = "0912345678",
            ZipCode = "700000"
        };

        _userRepoMock.Setup(repo => repo.GetUserById(userId)).ReturnsAsync(existingUser);
        _unitOfWorkMock.Setup(uow => uow.SaveChangesAsync()).ReturnsAsync(1);

        // Act
        var result = await _userService.DeleteUser(userId);

        // Assert
        Assert.True(result);

        _userRepoMock.Verify(repo => repo.GetUserById(userId), Times.Once);
        _userRepoMock.Verify(repo => repo.DeleteUser(existingUser), Times.Once);
        _unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Once);
    }

    [Fact]
    public async Task DeleteUser_ShouldReturnFalse_WhenUserDoesNotExist()
    {
        // Arrange
        var userId = 99;

        _userRepoMock.Setup(repo => repo.GetUserById(userId)).ReturnsAsync((User?)null);

        // Act
        var result = await _userService.DeleteUser(userId);

        // Assert
        Assert.False(result);

        _userRepoMock.Verify(repo => repo.GetUserById(userId), Times.Once);
        _userRepoMock.Verify(repo => repo.DeleteUser(It.IsAny<User>()), Times.Never);
        _unitOfWorkMock.Verify(uow => uow.SaveChangesAsync(), Times.Never);
    }

}