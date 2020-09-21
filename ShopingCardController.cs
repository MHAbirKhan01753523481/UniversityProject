using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkAppp.Data;
using WorkAppp.Models;

namespace WorkAppp.Controllers
{
    public class ShopingCardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShopingCardController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            //ViewBag.data = HttpContext.Session.GetString("UText");
            ViewBag.msg = TempData["msg"];
            return View(getCart());
        }

        [HttpPost]
        public IActionResult AddProduct(string tableNo, string OrderNo, DateTime OderDate, string orderType, string OrderStutas, string paymentType, double paymentAmount)
        {
            OrderR order = new OrderR();
            order.TableNo = tableNo;
            order.OrderNumber = OrderNo;
            order.OrderDate = OderDate;
            order.OrderType = orderType;
            order.StatusType = OrderStutas;
            order.PaymentType = paymentType;
            order.PaymentAmount = paymentAmount;
            _context.OrderR.Add(order);
            _context.SaveChanges();
            string msg = "";
            if (!string.IsNullOrEmpty(order.TableNo))
            {
                if (!string.IsNullOrEmpty(order.OrderNumber))
                {
                    if (!string.IsNullOrEmpty(order.OrderDate.ToString()))
                    {
                        if (!string.IsNullOrEmpty(order.OrderType))
                        {
                            if (!string.IsNullOrEmpty(order.StatusType))
                            {
                                if (!string.IsNullOrEmpty(order.PaymentType))
                                {
                                    if (order.PaymentAmount>0)
                                    {
                     string item = order.TableNo + ";" +order.OrderNumber+ ";" + order.OrderDate.ToString() + ";" + order.OrderType + ";" + order.StatusType + ";" + order.PaymentType + ";" + order.PaymentAmount.ToString();
                                        string prods =                                           HttpContext.Session.GetString("shopcart");
                     if (!string.IsNullOrEmpty(prods))
                                      {
                    prods += "|" + item;
                    HttpContext.Session.SetString("shopcart", prods);
                    msg = "Order is addedsuccessfully.";
                                        }
                                        else
                                        {
                     HttpContext.Session.SetString("shopcart", item);
                     msg = "Order is added successfully.";
                                        }
                                    }
                                    else
                                    {
                                        msg = "Payment Amount Must Be Entered";
                                    }
                                }
                                else
                                {
                                    msg = "Payment Type Must Be Entered";
                                }
                            }
                            else
                            {
                                msg = "Order5 Stutas Must Be Entered";
                            }
                        }
                        else
                        {
                            msg = "OrderType Must Be Entered";
                        }
                    }
                    else
                    {
                        msg = "OrderDate Must Be Entered";
                    }
                }
                else
                {
                    msg = "Order Must Be Entered";
                }
              
            }
            else
            {
                msg = "Table Number Must Be Entered";
            }
            TempData["msg"] = msg;
            return RedirectToAction("Index");
            }
        
        public IActionResult ShowCart()
        {
            List<OrderR> prodlist = new List<OrderR>();
           
            string cart = HttpContext.Session.GetString("shopcart");
            if (string.IsNullOrEmpty(cart))
            {
                return View("Index");
            }

            string[] prod = cart.Split("|");
            int i = 1;
            if (prod.Length > 0)
            {
                foreach (var item in prod)
                {
                    string[] p = item.Split(";");
                    if (p.Length > 0)
                    {
                        prodlist.Add(new OrderR { Id=i,TableNo=p[0],OrderNumber=p[1],OrderDate=Convert.ToDateTime(p[2]),OrderType=p[3],StatusType=p[4],PaymentType=p[5],PaymentAmount=Convert.ToDouble(p[6])});

                        //prodlist.Add(new OrderR { Id = i, TableNo=p[0], OrderNumber= p[1],OrderDate= Convert.ToDateTime(p[2]),OrderType=p[3],PaymentAmount=Convert.ToDouble(p[4]),PaymentType=p[5],StatusType=p[6] });
                    }
                }
            }


            //ViewBag.msg = TempData["msg"];
            return View("Index", prodlist);
        }

        private List<OrderR> getCart()
        {
            List<OrderR> prodlist = new List<OrderR>();

            string cart = HttpContext.Session.GetString("shopcart");
            if (string.IsNullOrEmpty(cart))
            {
                return null;
            }

            string[] prod = cart.Split("|");
            int i = 1;
            if (prod.Length > 0)
            {
                foreach (var item in prod)
                {
                    string[] p = item.Split(";");
                    if (p.Length > 0)
                    {
                        prodlist.Add(new OrderR { Id = i, TableNo = p[0], OrderNumber = p[1], OrderDate = Convert.ToDateTime(p[2]), OrderType = p[3], StatusType = p[4], PaymentType = p[5], PaymentAmount = Convert.ToDouble(p[6]) });

                        //prodlist.Add(new OrderR { Id = i, TableNo = p[0], OrderNumber = p[1], OrderDate = Convert.ToDateTime(p[2]), OrderType = p[3], PaymentAmount = Convert.ToDouble(p[4]), PaymentType = p[5], StatusType = p[6] });
                    }
                }
            }
            return prodlist;
        }


    }
}
