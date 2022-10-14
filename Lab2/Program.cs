using Logistic.DAL.Entities;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("1. Выборка из таблицы Organizations");
            var organizations = await DataHelper.GetEntities<Organization>();
            Console.WriteLine(Serialize(organizations));

            var organizationFilterValue = "Гомсельмаш";
            Console.WriteLine($"2. Выборка из таблицы Organizations с названием \"{organizationFilterValue}\"");
            var filteredOrganizations = await DataHelper.GetEntities<Organization>(organizationFilterValue, nameof(Organization.Name));
            Console.WriteLine(Serialize(filteredOrganizations));

            Console.WriteLine($"3. Количество из таблицы Cars с по марке");
            var groupedCars = DataHelper.GetQuery<Car>()
                .GroupBy(c => c.Mark)
                .Select(c => new
                {
                    Count = c.Count(),
                    Mark = c.Key
                })
                .ToList();
            Console.WriteLine(Serialize(groupedCars));

            var driverFirstFilter = "Иван";
            var driverSecondFilter = "Иванов";
            Console.WriteLine($"4. Выборка из таблицы Drivers с именем \"{driverFirstFilter}\" и фамилией \"{driverSecondFilter}\"");
            var filteredDrivers = await DataHelper.GetEntities<Driver>(driverFirstFilter, nameof(Driver.FirstName), driverSecondFilter, nameof(Driver.LastName));
            Console.WriteLine(Serialize(filteredDrivers));

            organizationFilterValue = "Гомсельмаш";
            Console.WriteLine($"5. Выборка из таблицы Cars с названием организации \"{organizationFilterValue}\"");
            var filteredCars = await DataHelper.FilterCarsByOrganization(organizationFilterValue);
            Console.WriteLine(Serialize(filteredCars));

            var organizationToInsert = new Organization
            {
                Name = "МТЗ"
            };
            Console.WriteLine($"6. Вставка организации {Serialize(organizationToInsert)}");
            await DataHelper.Add(organizationToInsert);

            var carToInsert = new Car
            {
                Mark = "Mercedes",
                OrganizationId = organizationToInsert.Id,
                CarryingVolume = 12,
                CarryingWeight = 20
            };
            Console.WriteLine($"7. Вставка машины {Serialize(carToInsert)}");
            await DataHelper.Add(carToInsert);

            Console.WriteLine($"9. Удаление машины {Serialize(carToInsert)}");
            await DataHelper.DeleteEntity<Car>(carToInsert.Id);

            organizationFilterValue = "Пивзавод";
            Console.WriteLine($"10. Обновление всех организаций с названием {organizationFilterValue}");
            var entitiesToUpdate = await DataHelper.GetEntities<Organization>(organizationFilterValue, nameof(Organization.Name));
            entitiesToUpdate
                .ForEach(t => t.Name = "Pivzavod");
            await DataHelper.UpdateRange(entitiesToUpdate);

        }

        static string Serialize(object obj)
        {
            var serialized = JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.All
            });

            return serialized;
        }
    }
}
