namespace MapReduceCore
{
  class Employee
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public char Sex { get; set; }
    public double Salary { get; set; }

    public Employee(int id, string name, string surname, char sex, double salary)
    {
      Id = id;
      Name = name;
      Surname = surname;
      Sex = sex;
      Salary = salary;
    }
  }

  class CompanyCar
  {
    public string Plate { get; set; }
    public string Model { get; set; }
    public int EmployeeId { get; set; }
    public CompanyCar(string plate, string model, int employee)
    {
      Plate = plate;
      Model = model;
      EmployeeId = employee;
    }
  }
}