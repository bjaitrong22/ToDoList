using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;

namespace ToDoList.Controllers
{
  public class ItemsController: Controller
  {
    [HttpGet("/items")]
    public ActionResult Index()
    {
      List<Item> allItems = Item.GetAll();
      //Item starterItem = new Item("Add first item to To Do List");
      return View(allItems);
    }

    [HttpGet("/items/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/items")]
    public ActionResult Create(string description)
    {
      Item myItem = new Item(description);
      return RedirectToAction("Index");
      //return View("Index", myItem);
    }

    [HttpGet("/items/{id}")]
    public ActionResult Show(int id)
    {
      Item foundItem = Item.Find(id);
      return View(foundItem);
    }
  }
}