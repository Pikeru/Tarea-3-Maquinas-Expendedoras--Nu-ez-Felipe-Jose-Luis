using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Diagnostics;

namespace Tarea3
{
    [Serializable()]
    public class VendingMachine
    {
        //Fields

        private int credit;
        private List<Product> products;


        //Properties

        public int Credit
        {
            get { return credit; }
            set
            {
                if (value == 1 || value == 2 || value == 5 || value == 10 || value == 20 || value == 50)
                {
                    credit += value;
                    Console.Clear();
                }
                else if (value == 0)
                {
                    credit = 0;
                    Console.Clear();
                }
                else
                {
                    if (value < 20)
                    {
                        Console.Clear();
                        System.Console.WriteLine("I do not acept coins of {0}", value);
                    }
                    if (value > 20)
                    {
                        Console.Clear();
                        System.Console.WriteLine("I do not acept bills of {0}", value);
                    }
                }
            }
        }

        //Constructors

        public VendingMachine()
        {
            credit = 0;
            products = new List<Product>();
        }

        public VendingMachine(string typeProducts)
        {
            credit = 0;
            products = new List<Product>();

            if (typeProducts == "snacks")
            {
                products.Add(new Product(1, "Doritos", 16.50, 2));
                products.Add(new Product(2, "Ruffles", 15.50, 10));
                products.Add(new Product(3, "Oreo", 12.50, 5));
                products.Add(new Product(4, "Crackets", 8.50, 10));
            }
            else if (typeProducts == "drinks")
            {
                products.Add(new Product(1, "Coke", 8.50, 2));
                products.Add(new Product(2, "Sprite", 8, 10));
                products.Add(new Product(3, "Pepsi", 7.50, 5));
                products.Add(new Product(4, "Water", 10, 10));
            }


        }

        //Methods

        public void DeliveredProduct(Product selectProduct)
        {
            //Comprueba que tengas dinero suficiente

            //if(products[selection].Price<=credit)
            if (selectProduct.Price <= credit)
            {
                //Decrementa la cantidad de productos
                selectProduct.Quantity--;
                //Si la cantidad es 0 entonces lo quita del    
                Console.WriteLine("Your {0} is here! :)", selectProduct.Name);

                GiveChange(selectProduct);
            }
            else
            {
                Console.WriteLine("You don't have enoungh money");
            }
        }

        public void EnterCash()
        {
            Console.WriteLine("Enter the quantity");
            Credit = int.Parse(Console.ReadLine());
        }

        public void GiveChange(Product selectProduct)
        {
            Console.WriteLine("Your change is {0}", (credit - selectProduct.Price));
            if (selectProduct.Quantity == 0)
            {
                products.Remove(selectProduct);
            }
            credit = 0;
        }

        public void Refund()
        {
            Console.WriteLine("Your {0} coins are here", credit);
            credit = 0;
        }

        public void SelectProduct()
        {
            Console.WriteLine("Enter the product ID");
            int selection = int.Parse(Console.ReadLine());
            //Si existe el producto
            Console.Clear();
            if (products.Exists(x => x.Id == selection))
            {
                Product selectProduct = products.Find(x => x.Id == selection);
                DeliveredProduct(selectProduct);
            }
            /* if(products.ContainsKey(selection))
            {
               
            }*/
            else
            {
                Console.WriteLine("Product not avilable");
            }
        }

        public void ShowCredit()
        {
            Console.WriteLine("Your credit is {0}", credit);
        }

        public void ShowProduct()
        {
            foreach (var product in products)
            {
                Console.WriteLine(product.ToString());
            }
        }

        public static void SaveXML<T>(T obj, string fileName)
        {
            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(T));
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + fileName;
            System.IO.FileStream file = System.IO.File.Create(path);
            writer.Serialize(file, obj);
            file.Close();
        }

    }
}