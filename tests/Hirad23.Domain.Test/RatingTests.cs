using Hirad23.Domain;
using Hirad23.Domain.Catalog;

namespace Hirad23.Domain.Test;

[TestClass]
public class RatingTests
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

}
