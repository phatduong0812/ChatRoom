using Google.Protobuf;
using Google.Protobuf.WellKnownTypes;
using Grpc.Course.Protobuf.Test;

Console.WriteLine("Hello Protobuf");
var employee = new Employee();
employee.FirstName = "Phat";
employee.LastName = "Duong";
employee.IsRetired = false;
var birthdate = new DateTime(1999, 12, 8);
birthdate = DateTime.SpecifyKind(birthdate, DateTimeKind.Utc);
employee.BirthDate = Timestamp.FromDateTime(birthdate);
employee.Year = 1999;
employee.Age = 23;
employee.MaritalStatus = Employee.Types.MaritalStatus.Married;
employee.PreviousEmployers.Add("Microsoft");
employee.PreviousEmployers.Add("FPT Software");
employee.CurrentAddress = new Address();
employee.CurrentAddress.City = "HCM";
employee.CurrentAddress.StreetName = "Nguyen Xien";
employee.CurrentAddress.HouseNumber = 1005;
employee.Relatives.Add("girlfriend", "Hoai Thuong");
employee.Relatives.Add("father", "Van Huu");
employee.Relatives.Add("mother", "Thi Thi");

using(var output = File.Create("emp.dat")){
    employee.WriteTo(output);
}

Employee employeeFromFile;
using (var input = File.OpenRead("emp.dat")){
    employeeFromFile = Employee.Parser.ParseFrom(input);
}

Console.WriteLine("Done");
Console.WriteLine(employeeFromFile.Relatives.GetValueOrDefault("girlfriend"));