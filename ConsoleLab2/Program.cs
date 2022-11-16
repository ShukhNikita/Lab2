using ConsoleLab2.Interface;
using ConsoleLab2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics.Metrics;

namespace ConsoleLab2
{
    public class Program
    {

        private static IGenericRepository<ActivityTypes> activityTypesRepository;
        private static IGenericRepository<Companies> companiesRepository;
        private static IGenericRepository<MeasurementUnits> measurementUnitsRepository;
        private static IGenericRepository<OwnershipForms> ownershipFormsRepository;
        private static IGenericRepository<ProductionTypes> productionTypesRepository;
        private static IGenericRepository<ProductReleasePlans> productReleasePlansRepository;
        private static IGenericRepository<Products> productsRepository;
        private static IGenericRepository<ProductSalesPlans> productSalesPlansRepository;


        public static void Main(String[] args)
        {
            bool ifInit = true;
            try
            {
                activityTypesRepository = new GenericRepository<ActivityTypes>();
                companiesRepository = new GenericRepository<Companies>();
                measurementUnitsRepository = new GenericRepository<MeasurementUnits>();
                ownershipFormsRepository = new GenericRepository<OwnershipForms>();
                productionTypesRepository = new GenericRepository<ProductionTypes>();
                productReleasePlansRepository = new GenericRepository<ProductReleasePlans>();
                productsRepository = new GenericRepository<Products>();
                productSalesPlansRepository = new GenericRepository<ProductSalesPlans>();
                ifInit = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine(ifInit);

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Меню: ");
                Console.WriteLine("1 - Выборка всех данных из таблицы, стоящей в схеме базы данных нас стороне отношения «один»");
                Console.WriteLine("2 - Выборка данных из таблицы, стоящей в схеме базы данных нас стороне отношения «один», отфильтрованные по определенному условию, налагающему ограничения на одно или несколько полей");
                Console.WriteLine("3 - Выборка данных из двух полей двух таблиц, связанных между собой отношением «один-ко-многим» ");
                Console.WriteLine("4 - Выборка данных из двух полей двух таблиц, связанных между собой отношением <Один-ко-Многим>.");
                Console.WriteLine("5 - Выборка данных из двух таблиц, связанных между собой отношением «один-ко-многим» и отфильтрованным по некоторому условию, налагающему ограничения на значения одного или нескольких полей");
                Console.WriteLine("6 - Вставка данных в таблицы, стоящей на стороне отношения «Один».");
                Console.WriteLine("7 - Вставка данных в таблицы, стоящей на стороне отношения <Многие>.");
                Console.WriteLine("8 - Удаление данных из таблицы, стоящей на стороне отношения <Один>.");
                Console.WriteLine("9 - Удаление данных из таблицы, стоящей на стороне отношения <Многие>.");
                Console.WriteLine("10 - Обновление удовлетворяющих определенному условию записей в любой из таблиц базы данных.");
                Console.WriteLine("11 - Конец.");
                Console.WriteLine("Введите пункт меню: ");

                if (int.TryParse(Console.ReadLine(), out var number) == true)
                {
                    if (ifInit)
                    {
                        switch (number)
                        {
                            case 1:
                                Console.Clear();
                                Console.WriteLine("Вы выбрали пункт 1");
                                Console.WriteLine(Connection.GetConnetion());
                                var property = measurementUnitsRepository.GetAll();
                                foreach (var prodyct in property)
                                {
                                    Console.WriteLine($"{prodyct.Name}");
                                }
                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Вы выбрали пункт 2");
                                var property2 = measurementUnitsRepository.GetAll().Where(property => property.Name == "Unit of measurement1");
                                foreach (var prodyct in property2)
                                {
                                    Console.WriteLine($"{prodyct.Name}");
                                }
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("Вы выбрали пункт 3");
                                var products1 = productsRepository.GetAll();
                                var measurementUnits1 = measurementUnitsRepository.GetAll();

                                var results = from products in products1
                                              join measurementUnits in measurementUnits1 on
                                              products.MeasurementUnitId equals measurementUnits.Id
                                              group measurementUnits by new { measurementUnits.Name } into grp
                                              select new { Name = grp.Key.Name, Count = grp.Count() };
                                foreach (var result in results)
                                {
                                    Console.WriteLine($"{result.Name} : {result.Count}");
                                }

                                break;
                            case 4:
                                Console.Clear();
                                Console.WriteLine("Вы выбрали пункт 4");
                                var products2 = productsRepository.GetAll();
                                var measurementUnits2 = measurementUnitsRepository.GetAll();
                                var results1 = products2.Join(measurementUnits2, p => p.MeasurementUnitId, m => m.Id,
                                    (p, m) => new { p.Id, p.Name, p.Characteristic, p.MeasurementUnitId, p.Photo }).Take(50);
                                foreach (var result in results1)
                                {
                                    Console.WriteLine($"Id: {result.Id} Name: {result.Name} -- Casts: {result.Characteristic} -- Country: {result.MeasurementUnitId} -- Prod: {result.Photo}");
                                }
                                break;
                            case 5:
                                Console.Clear();
                                Console.WriteLine("Вы выбрали пункт 5");
                                products1 = productsRepository.GetAll();
                                measurementUnits1 = measurementUnitsRepository.GetAll();
                                var results2 = products1.Join(measurementUnits1, p => p.MeasurementUnitId, m => m.Id,
                                    (p, m) => new { ProductsName = p.Name, ProductsCharacteristic = p.Characteristic, NamemeasurementUnits = m.Name }).Where(m => m.NamemeasurementUnits == "Unit of measurement1");
                                foreach (var result in results2)
                                {
                                    Console.WriteLine($"ProductsName: {result.ProductsName} -- NamemeasurementUnits: {result.NamemeasurementUnits} -- ProductsCharacteristic: {result.ProductsCharacteristic}");
                                }
                                break;
                            case 6:
                                Console.Clear();
                                Console.WriteLine("Вы выбрали пункт 6");
                                measurementUnitsRepository.Create(new MeasurementUnits("Unit of measurement2"));
                                measurementUnitsRepository.Save();
                                property = measurementUnitsRepository.GetAll();
                                foreach (var prodyct in property)
                                {
                                    Console.WriteLine($"{prodyct.Name}");
                                }
                                break;
                            case 7:
                                Console.Clear();
                                Console.WriteLine("Вы выбрали пункт 7");
                                companiesRepository.Create(new Companies("Companies1          ", "Ryabiy Artem Dmitrie"));
                                companiesRepository.Save();
                                var companies = companiesRepository.GetAll().Reverse().Take(15);
                                foreach (var companiess in companies)
                                {
                                    Console.WriteLine($"{companiess.Name} : {companiess.FIO}");
                                }
                                break;
                            case 8:
                                Console.Clear();
                                Console.WriteLine("Вы выбрали пункт 8");
                                var units = measurementUnitsRepository.GetAll().Where(unit => unit.Name == "Unit of measurement1").FirstOrDefault();
                                var compan = companiesRepository.GetAll().Reverse().Where(compan => compan.OwnershipFormId == compan.Id);


                                companiesRepository.DeleteByTitem(compan);
                                companiesRepository.Save();
                                measurementUnitsRepository.DeleteById(units.Id);
                                measurementUnitsRepository.Save();

                                var measurement = measurementUnitsRepository.GetAll();
                                foreach (var actor in measurement)
                                {
                                    Console.WriteLine($"{actor.Name}");

                                }
                                break;
                            case 9:
                                Console.Clear();
                                Console.WriteLine("Вы выбрали пункт 9");
                                var productionTypes = productionTypesRepository.GetAll().Where(production => production.ProductId == 7);
                                productionTypesRepository.DeleteByTitem(productionTypes);
                                productionTypesRepository.Save();
                                productionTypes = productionTypesRepository.GetAll();
                                foreach (var prodyct in productionTypes)
                                {
                                    Console.WriteLine($"{prodyct.ProductId}");
                                }
                                break;
                            case 10:
                                Console.Clear();
                                Console.WriteLine("Вы выбрали пункт 10");
                                var property1 = ownershipFormsRepository.GetAll().Where(propert => propert.Name == "public property     ").FirstOrDefault();
                                if (property1 != null)
                                {
                                    property1.Name = "private property1";
                                    ownershipFormsRepository.Update(property1);
                                    ownershipFormsRepository.Save();

                                    var property3 = ownershipFormsRepository.GetAll();
                                    foreach (var propert in property3)
                                    {
                                        Console.WriteLine($"{propert.Name}");
                                    }
                                }


                                break;
                            case 11:
                                Console.WriteLine("Вы выбрали пункт 11");
                                Console.WriteLine("Закрытие программы....");
                                flag = false;
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("Нет такого пункта меню");
                                break;
                        }
                    }
                }

            }
        }



    }

}
