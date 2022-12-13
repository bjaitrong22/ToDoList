using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ToDoList.Models;
using System;

namespace ToDoList.Tests
{
  [TestClass]
  public class ItemTests: IDisposable
  {
    public IConfiguration Configuration {get; set; }

    public void Dispose()
    {
      Item.ClearAll();
    }

    public ItemTests()
    {
      IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
      Configuration = builder.Build();
      DBConfiguration.ConnectionString = Configuration["ConnectionStrings:TestConnection"];
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_ItemList()
    {
      //Arrange
      List<Item> newList = new List<Item> {};

      //Act
      List<Item> result = Item.GetAll();

      //Assert
      CollectionAssert.AreEqual(newList,result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Item()
    {
      //Arrange Act
      Item firstItem = new Item("Mow the Lawn");
      Item secondItem = new Item("Mow the Lawn");

      //Assert
      Assert.AreEqual(firstItem, secondItem);
    }

    [TestMethod]
    public void ReferenceTypes_ReturnsTrueBecauseBothItemsAreSameReference_bool()
  {
    //Arrange, Act
    Item firstItem = new Item("Mow the lawn");
    Item copyOfFirstItem = firstItem;
    copyOfFirstItem.Description = "Learn about c#";

    //Assert
    Assert.AreEqual(firstItem.Description,copyOfFirstItem.Description);
  }

  [TestMethod]
  public void ValueTypes_ReturnsTrueBecauseValuesAreTheSame_Bool()
  {
    //Arrange, Act
    int test1 = 1;
    int test2 = 1;

    //Assert
    Assert.AreEqual(test1,test2);
  }

  [TestMethod]
  public void Save_SavesToDatabase_ItemList()
  {
    //Arrange
    Item testItem = new Item("Mow the Lawn");

    //Act
    testItem.Save();
    List<Item> result = Item.GetAll();
    List<Item> testList = new List<Item>{testItem};

    //Assert
    CollectionAssert.AreEqual(testList, result);
  }

  [TestMethod]
  public void GetAll_ReturnsItems_ItemList()
  {
    //Arrange
    string description01 = "Walk the dog";
    string description02 = "Wash the dishes";
    Item newItem1 = new Item(description01);
    newItem1.Save();
    Item newItem2 = new Item(description02);
    newItem2.Save();
    List<Item> newList = new List<Item> {newItem1,newItem2};

    //Act
    List<Item> result = Item.GetAll();

    //Assert
    CollectionAssert.AreEqual(newList, result);
  }

  [TestMethod]
  public void Find_ReturnsCorrectItemFromDatabase_Item()
  {
    //Arrange
    Item newItem = new Item("Mow the Lawn");
    newItem.Save();
    Item newItem2 = new Item("Wash dishes");
    newItem2.Save();

    //Act
    Item foundItem = Item.Find(newItem.Id);

    //Assert
    Assert.AreEqual(newItem,foundItem);
  }
    
    [TestMethod]
    public void ItemConstructor_CreatesInstanceOfItem_item()
    {
      Item newItem = new Item("test");
      Assert.AreEqual(typeof(Item),newItem.GetType());
    }

    [TestMethod]
    public void GetDescription_ReturnDescription_String()
    {
      //Arrange
      string description = "Walk the dog.";
      Item newItem = new Item(description);

      //Act
      string result = newItem.Description;

      //Assert
      Assert.AreEqual(description,result);
    }

    [TestMethod]
    public void SetDescription_SetDescription_String()
    {
      //Arrange
      string description = "Walk the dog.";
      Item newItem = new Item(description);

      //Act
      string updateDescription = "Do the dishes";
      newItem.Description = updateDescription;
      string result = newItem.Description;

      Assert.AreEqual(updateDescription, result);
    }

    // [TestMethod]
    // public void GetAll_ReturnsEmptyList_ItemList()
    // {
    //   //Arrange
    //   List<Item> newList = new List<Item> {};

    //   //Act
    //   List<Item> result = Item.GetAll();

    //   //Assert
    //   CollectionAssert.AreEqual(newList, result);
    // }

    // [TestMethod]
    // public void GetAll_ReturnsItems_ItemList()
    // {
    //   //Arrange
    //   string description01 = "Walk the dog";
    //   string description02 = "Wash the dishes";
    //   Item newItem1 = new Item(description01);
    //   Item newItem2 = new Item(description02);
    //   List<Item> newlist = new List<Item> { newItem1, newItem2 };

    //   //Act
    //   List<Item> result = Item.GetAll();

    //   //Assert
    //   CollectionAssert.AreEqual(newlist, result);
    // }

    // [TestMethod]
    // public void GetId_ItemsInstantiateWithAnIdAndGetterReturns_Int()
    // {
    //   //Arrange
    //   string description = "Walk the dog.";
    //   Item newItem = new Item(description);

    //   //Act
    //   int result = newItem.Id;

    //   //Assert
    //   Assert.AreEqual(1,result);
    // }

    // [TestMethod]
    // public void Find_ReturnsCorrectItem_Item()
    // {
    //   //Arrange
    //   string description01 = "Walk the dog";
    //   string description02 = "Wash the dishes";
    //   Item newItem1 = new Item(description01);
    //   Item newItem2 = new Item(description02);

    //   //Act
    //   Item result = Item.Find(2);

    //   //Assert
    //   Assert.AreEqual(newItem2,result);
    // }
  } 
}