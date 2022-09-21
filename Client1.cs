public class Client
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Id { get; set; }  
    public int Salary { get; set; }

    public Client(string name, string lastName, string id, int salary)
    {
        this.Name = name;
        this.LastName = lastName;
        Id = id;
        this.Salary = salary;
    }
}
