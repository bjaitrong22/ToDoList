using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoList.Models;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTests
  {
    [TestMethod]
    public void ItemConstructor_CreatesInstanceOfItem_item()
    {
      Item newItem = new Item();
      Assert.AreEqual(typeof(Item),newItem.GetType());
    }

  } 
}