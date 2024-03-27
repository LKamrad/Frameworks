using Kontaktverwaltung.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System.Net.Mail;
using System.Net;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Kontaktverwaltung
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            int wahl = 0;
            do
            {
                
                ShowMenu();
                Console.Write("Wahl: ");   
                int.TryParse(Console.ReadLine(), out wahl);
                if(wahl == 1)
                {
                    Console.Clear();
                    AddContact();
                }
                else if(wahl == 2)
                {
                    Console.Clear();
                    int id = 0;
                    Console.Write("Id: ");
                    if (int.TryParse(Console.ReadLine(), out id));
                        RemoveContact(id);
                }
                else if (wahl == 3)
                {
                    Console.Clear();
                    int id = 0;
                    Console.Write("Id: ");
                    if (int.TryParse(Console.ReadLine(), out id));
                        Edit(id);
                }
                else if (wahl == 4)
                {
                    Console.Clear();
                    ShowAllContacts();
                }


            } while (wahl != 5);

            Console.WriteLine("Goodbye");

        }
        static void ShowMenu()
        {
            Console.WriteLine("Kontakt formular");
            Console.WriteLine("1. Kontakt addieren");
            Console.WriteLine("2. Kontakt löschen");
            Console.WriteLine("3. Kontakt editieren");
            Console.WriteLine("4. Alle Kontakte anzeigen");
            Console.WriteLine("5. Exit");
        }

        static async void AddContact()
        {
            bool errors = false;
            Kontakt temp = new Kontakt();
            Console.Write("Vorname: ");
            temp.Vorname = Console.ReadLine();
            Console.Write("Nachname: ");
            temp.Nachname = Console.ReadLine();
            Console.Write("Geschlecht: ");
            temp.Geschlecht = Console.ReadLine();
            Console.Write("Telefonnummer: ");
            temp.Telefonnummer = Console.ReadLine();
            Console.Write("E-Mail: ");
            temp.EMail = Console.ReadLine();

            try
            {
                string pattern = @"\b(\w|\.)+@\w+\.\w+$";

                Regex defaultRegex = new Regex(pattern);
                // Get matches of pattern in text
                var matches = defaultRegex.Matches(temp.EMail);

                if (matches != null)
                { 
                    temp.EMail = matches[0].Value;
                }
                else
                {
                    Console.WriteLine("Mail ist falsch!!");
                    return;
                    errors = true;
                }

                
                //temp.EMail = new MailAddress(temp.EMail).Address;
            }
            catch (Exception e)
            {
                Console.WriteLine("Mail ist falsch!!");
                return;
                errors = true;
            }
            Console.Write("PLZ: ");
            temp.PLZ = Console.ReadLine();

            HttpClient client = new HttpClient();

            try
            {
                if (temp.PLZ != null)
                {
                    string plz = temp.PLZ;
                    Task<string> taskInJson = client.GetStringAsync(@"https://api.zippopotam.us/DE/" + plz);
                    Task.WaitAll(taskInJson);

                    Adresse adr = JsonSerializer.Deserialize<Adresse>(taskInJson.Result);

                    temp.Ort = adr.places[0].placename;
                    if(temp.Ort == null)
                    {
                        throw new Exception();
                    }

                }
            }
            catch
            {
                Console.WriteLine("PLZ ort ist falsch");
                return;
                errors = true;
            }

            Console.WriteLine();
            Console.WriteLine(temp);
            Console.WriteLine();
            Console.Write("Press (y) to confirm: ");
            string s = Console.ReadLine();

            if(s == "y" && errors == false)
            {
                using (KontakteContext context = new KontakteContext())
                {

                    context.Add(temp);
                    context.SaveChanges();
                    Console.WriteLine("Kontakt addiert!");
                }
            }
            else
            {
                Console.WriteLine("Kontakt nicht gespeichert");
            }

        }
        static void ShowAllContacts()
        {
            using (KontakteContext context = new KontakteContext())
            {
                foreach (var item in context.Kontakt)
                {
                    Console.WriteLine(item + "\n");
                }
            }
        }

        static void EditMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Kontakt Edit");
            Console.WriteLine("1. Vorname Ändern");
            Console.WriteLine("2. Nachname Ändern");
            Console.WriteLine("3. Geschlecht Ändern");
            Console.WriteLine("4. Telefonnummer Ändern");
            Console.WriteLine("5. E-Mail Ändern");
            Console.WriteLine("6. PLZ Ändern");
            Console.WriteLine("7. Exit");
            Console.WriteLine();


        }
        static void Edit(int id)
        {
            using (KontakteContext context = new KontakteContext())
            {

                try
                {
                    Console.Clear();
                    Kontakt customer = context.Kontakt.First(x => x.Id == id);
                    Console.WriteLine(customer);
                    int wahl = 0;
                    do
                    {
                        
                        EditMenu();
                        Console.Write("Wahl: ");
                        int.TryParse(Console.ReadLine(), out wahl);
                        if (wahl == 1)
                        {
                            Console.Write("Vorname: ");
                            customer.Vorname = Console.ReadLine();
                        }
                        else if (wahl == 2)
                        {
                            Console.Write("Nachname: ");
                            customer.Nachname = Console.ReadLine();
                        }
                        else if (wahl == 3)
                        {
                            Console.Write("Geschlecht: ");
                            customer.Geschlecht = Console.ReadLine();
                        }
                        else if (wahl == 4)
                        {
                            Console.Write("Telefonnumer: ");
                            customer.Telefonnummer = Console.ReadLine();
                        }
                        else if (wahl == 5)
                        {
                            Console.Write("E-Mail: ");
                            customer.EMail = Console.ReadLine();

                            try
                            {
                                string pattern = @"\b(\w|\.)+@\w+\.\w+$";

                                Regex defaultRegex = new Regex(pattern);
                                // Get matches of pattern in text
                                var matches = defaultRegex.Matches(customer.EMail);

                                if (matches != null)
                                {
                                    customer.EMail = matches[0].Value;
                                }
                                else
                                {
                                    Console.WriteLine("Mail ist falsch!!");
                                    return;
                                }


                                //temp.EMail = new MailAddress(temp.EMail).Address;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Mail ist falsch!!");
                                return;
                            }
                        }
                        else if (wahl == 6)
                        {
                            Console.Write("PLZ: ");
                            customer.PLZ = Console.ReadLine();
                            HttpClient client = new HttpClient();

                            try
                            {
                                if (customer.PLZ != null)
                                {
                                    string plz = customer.PLZ;
                                    Task<string> taskInJson = client.GetStringAsync(@"https://api.zippopotam.us/DE/" + plz);
                                    Task.WaitAll(taskInJson);

                                    Adresse adr = JsonSerializer.Deserialize<Adresse>(taskInJson.Result);

                                    customer.Ort = adr.places[0].placename;
                                    if (customer.Ort == null)
                                    {
                                        throw new Exception();
                                    }

                                }
                            }
                            catch
                            {
                                Console.WriteLine("PLZ ort ist falsch");
                                return;
                            }

                        }

                        Console.Clear();
                        Console.WriteLine(customer);
                    } while (wahl != 7);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Fehler bei Edit");
                }

                
            }
        }
        static void RemoveContact(int id)
        {
            using (KontakteContext context = new KontakteContext())
            {
                
                try
                {
                    Kontakt customer = context.Kontakt.First(x => x.Id == id);
                    Console.WriteLine(customer);
                    Console.WriteLine("Wollen die der Kontakt löschen (y)");
                    string s = Console.ReadLine();

                    if (s == "y")
                    {
                        //Kontakt customer = new Kontakt() { Id = id };
                        //context.Kontakt.Attach(customer);
                        context.Kontakt.Remove(customer);
                        var etwas = context.SaveChanges();
                        if (etwas == 1)
                        {
                            Console.WriteLine("Kontakt gelöscht");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Kontakt nicht gelöscht");
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Kontakt mit id: {id} nicht gefunden");
                }
            }
        }
    }
}
