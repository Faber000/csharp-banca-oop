public class Loan
{
    public int Id { get; set; }
    public Client Client { get; set; }
    public double Amount { get; set; }
    public int Installment { get; set; }
    public string DateStart { get; set; }
    public string DateEnd { get; set; }

    public Loan(Client client, double amount, int installment, string dateStart, string dateEnd)
    {
        Id = new Random().Next(100);
        Client = client;
        Amount = amount;
        Installment = installment;
        DateStart = dateStart;
        DateEnd = dateEnd;
    }
}