using System.Collections.Generic;
using EngergyLib;

namespace EnergyRestApi.Managers
{
    public class EnergyManager
    {
        private static int _nextId = 1;

        private static List<EnergyData> dataList = new List<EnergyData>()
        {
            new EnergyData() {Id = _nextId++, EnergyMetric = "joule", Value = 30},
            new EnergyData() {Id = _nextId++, EnergyMetric = "joule", Value = 10.5},
            new EnergyData() {Id = _nextId++, EnergyMetric = "calorie", Value = 30.4},
            new EnergyData() {Id = _nextId++, EnergyMetric = "calorie", Value = 33.2},
            new EnergyData() {Id = _nextId++, EnergyMetric = "joule", Value = 1.111},
            
        };

        public List<EnergyData> GetAllData(string value)
        {
            List < EnergyData > tempList = new List<EnergyData>();
            foreach (var item in dataList)
            {
                tempList.Add(new EnergyData
                {
                    Id = item.Id,
                    EnergyMetric = item.EnergyMetric,
                    Value = item.Value,
                });
            }

            if (value == "joule")
            {
                foreach (var item in tempList)
                {
                    if (item.EnergyMetric == "calorie")
                    {
                        item.EnergyMetric = "joule";
                        item.Value = EnergyConverter.ToJoule(item.Value);
                    }
                    
                }
            }
            if (value == "calorie")
            {
                foreach (var item in tempList)
                {
                    if (item.EnergyMetric == "joule")
                    {
                        item.EnergyMetric = "calorie";
                        item.Value = EnergyConverter.ToCalorie(item.Value);
                    }
                }
            }
            
            return tempList;
        }

        public EnergyData AddCooler(EnergyData data)
        {
            data.Id = _nextId++;
            dataList.Add(data);
            return data;
        }
    }
}
