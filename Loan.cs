public class Loan
{
    public int Id { get; set; }
    Client Client { get; set; }
    public double Ammount { get; set; }
    public double Installment { get; set; }
    public string DateStart { get; set; }
    public string DateEnd { get; set; }

    public Loan(int id, Client client, double ammount, double installment, string dateStart, string dateEnd)
    {
        Id = id;
        Client = client;
        Ammount = ammount;
        Installment = installment;
        DateStart = dateStart;
        DateEnd = dateEnd;
    }
}