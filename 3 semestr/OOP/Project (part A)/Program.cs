internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

public class Expense
{
    public decimal Amount { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
}

public class ExpenseTracker
{
    private List<Expense> expenses = new List<Expense>();

    public void AddExpense(Expense expense)
    {
        expenses.Add(expense);
    }

    public decimal GetTotalExpenses()
    {
        return expenses.Sum(expense => expense.Amount);
    }

    public List<Expense> GetExpensesByCategory(string category)
    {
        return expenses.Where(expense => expense.Category == category).ToList();
    }

    public List<Expense> GetExpenses()
    {
        return expenses.ToList();
    }
}

public class ExpenseReportGenerator
{
    public string GenerateReport(List<Expense> expenses)
    {
        // Логіка генерації звіту по витратам
        return "Expense Report";
    }
}

public class ExpenseManager
{
    private ExpenseTracker expenseTracker;
    private ExpenseReportGenerator expenseReportGenerator;

    public ExpenseManager(ExpenseTracker tracker, ExpenseReportGenerator reportGenerator)
    {
        expenseTracker = tracker;
        expenseReportGenerator = reportGenerator;
    }

    public void LogExpense(decimal amount, string category, string description, DateTime date)
    {
        var newExpense = new Expense { Amount = amount, Category = category, Description = description, Date = date };
        expenseTracker.AddExpense(newExpense);
    }

    public string GenerateExpenseReport()
    {
        var expenses = expenseTracker.GetExpenses();
        return expenseReportGenerator.GenerateReport(expenses);
    }
}
