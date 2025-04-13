using Hirad23.Domain.Catalog;

namespace Hirad23.Domain.Tests;

[TestClass]
public sealed class ItemTests
{

    [TestMethod]
    public void Can_create_New_Item()
    {
        var item = new Item("Name", "Description", "Brand", 10.00m);

        Assert.AreEqual("Name", item.Name);
        Assert.AreEqual("Description", item.Description);
        Assert.AreEqual("Brand", item.Brand);
        Assert.AreEqual(10.00m, item.Price);
    }

}
