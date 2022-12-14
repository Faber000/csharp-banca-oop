using System;

// list of Loan Objects
List<Loan> LoanList = new List<Loan>();

// list of Client Objects
List<Client> ClientList = new List<Client>();

string option;

Console.WriteLine("What's the name of the bank?");
string bankName = Console.ReadLine();

Console.WriteLine("\r\n");
Console.WriteLine("Welcome on "+ bankName +" bank!");
Console.WriteLine("\r\n");

do
{
    // Menu options
    Console.WriteLine("Enter 1 to insert new client informations");
    Console.WriteLine("Enter 2 to modify client informations");
    Console.WriteLine("Enter 3 to search for a client");
    Console.WriteLine("Enter 4 to insert new Loan");
    Console.WriteLine("Enter 5 to view all info");
    Console.WriteLine("Enter 6 to view Loan tables");

    option = Console.ReadLine();

    switch (option)
    {
        case "1":
            AddClient();
            break;

        case "2":
            ModifyClient();
            break;

        case "3":
            SearchClient();
            break;

        case "4":
            AddLoan();
            break;

        case "5":
            ViewAll();
            break;

        case "6":
            ViewTables();
            break;

        default:
            Console.WriteLine("Please enter existing option");
            break;
    }
} while (option != "-1");


void ViewTables()
{
    foreach(Client client in ClientList)
    {
        Console.WriteLine("Name: "+client.Name+" "+client.LastName);
        Console.WriteLine("\r\n");

        Console.WriteLine("Id  |  Amount  |  Installments  |    Start    |    End  ");

        foreach (Loan loan in LoanList)
        {
            if(loan.Client.Id == client.Id)
            {
                Console.WriteLine(loan.Id + "       " + loan.Amount + "            " + loan.Installment + "        " + loan.DateStart + "      " + loan.DateEnd);
                Console.WriteLine("\r\n");
            }
        }
    }
}

void ViewAll()
{
    Console.WriteLine("Here's the actual situation of Loans and Clients");
    Console.WriteLine("\r\n");

    Console.WriteLine("Clients informations");
    Console.WriteLine("\r\n");

    foreach (Client client in ClientList)
    {
        Console.WriteLine("Name: "+client.Name);
        Console.WriteLine("Last Name: "+client.LastName);
        Console.WriteLine("Id: "+client.Id);
        Console.WriteLine("Salary: "+client.Salary);
        Console.WriteLine("\r\n");

    }

    Console.WriteLine("Loans informations");
    Console.WriteLine("\r\n");
    foreach (Loan loan in LoanList)
    {
        Console.WriteLine("Id: " + loan.Id);
        Console.WriteLine("Client name: " + loan.Client.Name+ " "+loan.Client.LastName);
        Console.WriteLine("Amount: " + loan.Amount);
        Console.WriteLine("Installment number: " + loan.Installment);
        Console.WriteLine("Start date: " + loan.DateStart);
        Console.WriteLine("End date: " + loan.DateEnd);
        Console.WriteLine("\r\n");

    }

}

void SearchClient()
{
    bool found = false;

    double amountCont = 0;

    int installmentCont = 0;

    Console.WriteLine("Please enter client Id (Codice Fiscale)");
    string id = Console.ReadLine();

    // searching for a loan having the client Id entered
    foreach (Loan loan in LoanList)
    {
        if(loan.Client.Id == id)
        {
            found = true;

            amountCont = amountCont + loan.Amount;

            installmentCont = installmentCont + loan.Installment;

            Console.WriteLine("Client " + loan.Client.LastName + " has started a loan of " + loan.Amount + "$" + " in " + loan.DateStart);
            Console.WriteLine("\r\n");
        }
    }
    
    if(found == false)
    {
        Console.WriteLine("No Loan found");
        Console.WriteLine("\r\n");
    } 
    
    else
    {
        Console.WriteLine("Client " + id + " has a total amount of " + amountCont + "$" + " to pay, in " + installmentCont + " installments");
        Console.WriteLine("\r\n");
    }
}


void AddLoan()
{
    bool found = false;

    Console.WriteLine("Please insert client Id (Codice Fiscale)");
    string id = Console.ReadLine();
    
    // serching for a client having the Id entered
    foreach (Client client in ClientList)
    {
        if(client.Id == id)
        {
            found = true;

            Console.WriteLine("Please insert amount");
            double amount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please insert installments number");
            int installment = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please insert deadline");
            string deadline = Console.ReadLine();

            DateTime thisDay = DateTime.Today;

            Loan loan = new Loan(client, amount, installment, thisDay.ToString("d"), deadline);

            LoanList.Add(loan);

            Console.WriteLine("\r\n");
            Console.WriteLine("Loan registered successfully");
            Console.WriteLine("\r\n");
        }
    }
    if(found==false)
    {
        Console.WriteLine("\r\n");
        Console.WriteLine("Client don't found, try register new client first");
        Console.WriteLine("\r\n");
    }
}

void AddClient() {

    Console.WriteLine("Please enter new client informations");

    Console.WriteLine("Enter new client name");
    string name = Console.ReadLine();

    Console.WriteLine("Enter new client last name");
    string lastName = Console.ReadLine();

    Console.WriteLine("Enter new client Id (Codice Fiscale)");
    string id = Console.ReadLine();

    Console.WriteLine("Enter new client salary");
    int salary = Convert.ToInt32(Console.ReadLine());

    Client client = new Client(name, lastName, id, salary);

    ClientList.Add(client);
}

void ModifyClient() {

    bool found = false;
    Console.WriteLine("Please enter client Id (Codice Fiscale)");
    string cod = Console.ReadLine();

    foreach (Client client in ClientList)
    {
        if(client.Id == cod)
        {
            found = true;
            Console.WriteLine("What information do you want to modify?");
            string option = Console.ReadLine();

            switch(option)
            {
                case "name":
                    Console.WriteLine("Enter client name");
                    string name = Console.ReadLine();
                    client.Name = name;
                    break;

                case "last name":
                    Console.WriteLine("Enter client last name");
                    string lastName = Console.ReadLine();
                    client.LastName = lastName;
                    break;

                case "id":
                    Console.WriteLine("Enter client id");
                    string id = Console.ReadLine();
                    client.Id = id;
                    break;

                case "salary":
                    Console.WriteLine("Enter client salary");
                    int salary = Convert.ToInt32(Console.ReadLine());
                    client.Salary = salary;
                    break;

                default:
                    Console.WriteLine("Please enter an existing option");
                    break;
            }
        }
    }

    if(found)
    {
        Console.WriteLine("Your changes has been updated");
    }
}






