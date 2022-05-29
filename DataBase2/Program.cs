using System;
using System.Collections.Generic;
using System.Linq;

namespace DataBase2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new UserContext();

            #region fill data...
            db.Database.EnsureCreated();
            db.Users.RemoveRange(db.Users);
            db.UsersChilds.RemoveRange(db.UsersChilds);

            db.Users.Add(new User() { DbId = 1588, FIO = "Саенко М. А.", Sex = "Ж" });
            db.Users.Add(new User() { DbId = 1616, FIO = "Билич А. П.", Sex = "М" });
            db.Users.Add(new User() { DbId = 1683, FIO = "Виктюк И. Б.", Sex = "М" });
            db.Users.Add(new User() { DbId = 1748, FIO = "Кеосаян А. И.", Sex = "Ж" });
            db.Users.Add(new User() { DbId = 1960, FIO = "Виктюк П. И.", Sex = "М" });
            db.Users.Add(new User() { DbId = 1974, FIO = "Тузенбах П. А.", Sex = "Ж" });
            db.Users.Add(new User() { DbId = 2008, FIO = "Виктюк Б. Ф.", Sex = "М" });
            db.Users.Add(new User() { DbId = 2106, FIO = "Чижик Д. К.", Sex = "Ж" });
            db.Users.Add(new User() { DbId = 2339, FIO = "Седых Л. А.", Sex = "М" });
            db.Users.Add(new User() { DbId = 2349, FIO = "Виктюк А. Б.", Sex = "Ж" });
            db.Users.Add(new User() { DbId = 2521, FIO = "Меладзе К. Г.", Sex = "М" });
            db.Users.Add(new User() { DbId = 2593, FIO = "Билич П. А.", Sex = "М" });
            db.Users.Add(new User() { DbId = 2730, FIO = "Виктюк Т. И.", Sex = "Ж" });
            db.Users.Add(new User() { DbId = 2860, FIO = "Панина Р. Г.", Sex = "Ж" });
            db.Users.Add(new User() { DbId = 2882, FIO = "Шевченко Г. Р.", Sex = "Ж" });
            db.Users.Add(new User() { DbId = 2911, FIO = "Седых В. А.", Sex = "Ж" });

            db.UsersChilds.Add(new UserChild() { Parent = 1616, Child = 1588 });
            db.UsersChilds.Add(new UserChild() { Parent = 2349, Child = 1588 });
            db.UsersChilds.Add(new UserChild() { Parent = 2008, Child = 1683 });
            db.UsersChilds.Add(new UserChild() { Parent = 2106, Child = 1683 });
            db.UsersChilds.Add(new UserChild() { Parent = 1683, Child = 1960 });
            db.UsersChilds.Add(new UserChild() { Parent = 2882, Child = 1960 });
            db.UsersChilds.Add(new UserChild() { Parent = 2860, Child = 1974 });
            db.UsersChilds.Add(new UserChild() { Parent = 2860, Child = 2339 });
            db.UsersChilds.Add(new UserChild() { Parent = 2008, Child = 2349 });
            db.UsersChilds.Add(new UserChild() { Parent = 2106, Child = 2349 });
            db.UsersChilds.Add(new UserChild() { Parent = 1616, Child = 2593 });
            db.UsersChilds.Add(new UserChild() { Parent = 2349, Child = 2593 });
            db.UsersChilds.Add(new UserChild() { Parent = 1683, Child = 2730 });
            db.UsersChilds.Add(new UserChild() { Parent = 2882, Child = 2730 });
            db.UsersChilds.Add(new UserChild() { Parent = 1616, Child = 2911 });
            db.UsersChilds.Add(new UserChild() { Parent = 2349, Child = 2911 });

            db.SaveChanges();
            #endregion

            Console.WriteLine($"Database path: {db.DbPath}");

            var neightbors = from upp in db.UsersChilds
                             join ux in (from uc in db.UsersChilds
                                         where uc.Child == 2911 //id Седых В.А
                                         select uc)
                             on upp.Parent equals ux.Parent select upp.Child; //айдишники братьев и сестер

            var brother = from u in db.Users
                          join ids in neightbors on u.DbId equals ids
                          orderby ids
                          select new { u.FIO, u.DbId, u.Sex};

            //foreach (var item in brother)
            //{
            //    Console.WriteLine(item);
            //}


            var task1 = brother.Where(x => x.Sex == "М").FirstOrDefault();
            var task2 = brother.Where(x => x.Sex == "М").GroupBy(x => x.DbId).Count();
            var task3_ids = from uc in db.UsersChilds
                        group uc by uc.Child into g
                        where g.Count() == 1 //группируем там где только один родитель...
                        select new
                        {
                            Id = g.Key
                        };

            var task3 = from u in db.Users
                        join uc in task3_ids on u.DbId equals uc.Id
                        select u;

            Console.WriteLine("\nID родного брата Седых В.А. - {0}, ФИО: {1}", task1.DbId, task1.FIO);
            Console.WriteLine("\nКоличество братьев у Саенко М.А. {0}", task2);

            Console.WriteLine("\nСписок детей из неполных семей:");
            foreach (var item in task3)
            {
                Console.WriteLine("{0} - {1}", item.DbId, item.FIO);
            }
        }
    }
}
