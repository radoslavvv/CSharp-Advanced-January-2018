using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Patient
{
    public string Name { get; set; }
    public string Doctor { get; set; }
}

class Room
{
    public int Number { get; set; }
    public List<Patient> Patients { get; set; }
}

namespace _04.Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Patient>> doctors = new Dictionary<string, List<Patient>>();
            Dictionary<string, List<Room>> departments = new Dictionary<string, List<Room>>();

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputParams = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (input == "Output")
                {
                    input = Console.ReadLine();
                    continue;
                }
                if (inputParams.Length == 4)
                {
                    string department = inputParams[0].Trim();
                    string doctorName = $"{inputParams[1]} {inputParams[2]}".Trim();
                    string patientName = inputParams[3].Trim();

                    if (!departments.ContainsKey(department))
                    {
                        departments.Add(department, new List<Room>());
                    }
                    if (departments[department].Count <= 20)
                    {
                        if (departments[department].Count > 0)
                        {
                            if (departments[department].Last().Patients.Count <= 2)
                            {
                                departments[department].Last().Patients.Add(new Patient()
                                {
                                    Name = patientName,
                                    Doctor = doctorName
                                });
                                if (!doctors.ContainsKey(doctorName))
                                {
                                    doctors.Add(doctorName, new List<Patient>());
                                }
                                doctors[doctorName].Add(new Patient()
                                {
                                    Name = patientName,
                                    Doctor = doctorName
                                });
                            }
                            else
                            {
                                departments[department].Add(new Room()
                                {
                                    Number = departments[department].Last().Number + 1,
                                    Patients = new List<Patient>()
                                });
                                departments[department].Last().Patients.Add(new Patient()
                                {
                                    Name = patientName,
                                    Doctor = doctorName
                                });

                                if (!doctors.ContainsKey(doctorName))
                                {
                                    doctors.Add(doctorName, new List<Patient>());
                                }
                                doctors[doctorName].Add(new Patient()
                                {
                                    Name = patientName,
                                    Doctor = doctorName
                                });
                            }
                        }
                        else
                        {
                            departments[department].Add(new Room()
                            {
                                Number = 1,
                                Patients = new List<Patient>()
                            });

                            departments[department].First().Patients.Add(new Patient()
                            {
                                Name = patientName,
                                Doctor = doctorName
                            });

                            if (!doctors.ContainsKey(doctorName))
                            {
                                doctors.Add(doctorName, new List<Patient>());
                            }
                            doctors[doctorName].Add(new Patient()
                            {
                                Name = patientName,
                                Doctor = doctorName
                            });
                        }
                    }
                }
                else if (inputParams.Length == 2)
                {
                    if (doctors.ContainsKey(inputParams[0] + " " + inputParams[1]))
                    {
                        foreach (var patient in doctors[inputParams[0] + " " + inputParams[1]].OrderBy(p => p.Name))
                        {
                            Console.WriteLine($"{patient.Name}");
                        }
                    }
                    else if (departments.ContainsKey(inputParams[0]))
                    {
                        string department = inputParams[0];
                        int roomNumber = int.Parse(inputParams[1]);

                        foreach (var patient in departments[department].First(r => r.Number == roomNumber).Patients.OrderBy(p => p.Name))
                        {
                            Console.WriteLine($"{patient.Name}");
                        }
                    }
                }
                else if (inputParams.Length == 1)
                {
                    foreach (var room in departments[inputParams[0]])
                    {
                        foreach (var patient in room.Patients)
                        {
                            Console.WriteLine($"{patient.Name}");
                        }
                    }
                }
                input = Console.ReadLine();
            }
        }
    }
}
