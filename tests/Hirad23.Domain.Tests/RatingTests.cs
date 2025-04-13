using Hirad23.Domain.Catalog;

namespace Hirad23.Domain.Tests;

[TestClass]
public sealed class RatingTests
{
    [TestMethod]
    public void Can_create_New_Rating()
    {
        // Arrange
        var rating = new Rating(1, "Mike", "Great fit!");

        // Act (empty for now)

        // Assert
        Assert.AreEqual(1, rating.Stars);
        Assert.AreEqual("Mike", rating.UserName);
        Assert.AreEqual("Great fit!", rating.Review);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Cannot_Create_Rating_With_Invalid_Stars()
    {
        // Arrange
        var rating = new Rating(0, "Mike", "Great fit!");
    }

    [TestMethod]
    public void Can_Create_Add_Rating()
    {
        // Arrange
        var item = new Item("Name", "Descriptoin", "Brand", 10.00m);
        var rating = new Rating(5, "Name", "Review");

        // Act
        item.AddRating(rating);

        // Assert
        Assert.AreEqual(rating, item.Ratings[0]);
    }
}
