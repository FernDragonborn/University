namespace Lab_3;
public partial class Lab3 : Form
{
    public Lab3()
    {
        InitializeComponent();
    }
    private void LabelSum_Click(object sender, EventArgs e)
    {

    }

    int[] vector = Array.Empty<int>();

    static void CreateRandomVector(ref int[] vector, int size)
    {
        Array.Resize(ref vector, size);
        var random = new Random();
        for (int k = 0; k < vector.Length; k++)
        {
            vector[k] = random.Next(-vector.Length, vector.Length + 1);
        }
    }

    static int DeleteRandomVectorElements(ref int[] vector)
    {
        var random = new Random();
        int deleteCount = random.Next(10);
        int middlePoint = vector.Length / 2;
        if (deleteCount > vector.Length - middlePoint) deleteCount = middlePoint + 1;
        int[] buff = new int[vector.Length];
        for (int i = 0; i < middlePoint; i++)
        {
            buff[i] = vector[i];
        }
        for (int i = middlePoint; i < vector.Length - deleteCount; i++)
        {
            buff[i] = vector[i + deleteCount];
        }
        buff.CopyTo(vector, 0);
        Array.Resize(ref vector, vector.Length - deleteCount);
        return deleteCount;
    }

    static void WriteVector(int[] vector, ListBox listBox)
    {
        listBox.Items.Clear();
        for (int i = 0; i < vector.Length; i++)
        {
            int element = vector[i];
            listBox.Items.Add(element);
        }
    }

    public int AddUpOddElements(in int[] vector)
    {
        int sum = 0;
        try
        {
            for (int i = 0; i < vector.Length; i++)
            {
                if (vector[i] % 2 == 0) sum += vector[i];
            }

            if (sum == 0)
            {
                throw new Exception("Всі елементи непарні");
            }
        }
        catch (Exception ex) { MessageBox.Show(ex.Message, "Повідомлення", default, MessageBoxIcon.Warning); }
        return sum;
    }

    private void CreateVectorButton_Click(object sender, EventArgs e)
    {
        try
        {
            ListBoxResult.Items.Clear();
            LabelDeletedCount.Visible = false;

            if (TextBoxVectorSize.Text.Length == 0) TextBoxVectorSize.Text = "5";
            int input = int.Parse(TextBoxVectorSize.Text);
            if (input <= 1 || input > 100)
            {
                if (input > 100) throw new Exception("Розмір може бути лише в діапазоні від 1 до 100.\nВведіть інший розмір");
                if (input < 0) throw new Exception("Розмір не може бути від'ємним числом.\nВведіть інший розмір");
                if (input == 0) throw new Exception("Розмір не може бути нулем.\nВведіть інший розмір");
                return;
            }
            LabelSumRes.Visible = false;
            CreateRandomVector(ref vector, input);
            WriteVector(vector, ListBoxRandomVector);
            ButtonGetResult.Enabled = true;
        }
        catch (OverflowException) { MessageBox.Show("Введене значення завелике!", "Помилка переповнення", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        catch (FormatException) { MessageBox.Show("Необхідно вводити тільки числа", "Помилка формату данних", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        catch (Exception ex) { MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
    }
    private void GetResultButton_Click(object sender, EventArgs e)
    {
        int deleteCount = 0;
        try
        {
            LabelSum.Visible = true;
            LabelDeleted.Visible = true;
            ListBoxResult.Items.Clear();
            LabelSumRes.Text = AddUpOddElements(in vector).ToString();
            LabelSumRes.Visible = true;
            deleteCount = DeleteRandomVectorElements(ref vector);
            WriteVector(vector, ListBoxResult);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        LabelDeletedCount.Text = deleteCount.ToString();
        LabelDeletedCount.Visible = true;
        ButtonGetResult.Enabled = false;
        ButtonCreateVector.Focus();
    }
    private void TextBoxVectorSize_TextChanged(object sender, EventArgs e)
    {
        LabelDeleted.Visible = false;
        LabelSum.Visible = false;
        ButtonGetResult.Enabled = false;
        LabelSumRes.Visible = false;
        LabelDeletedCount.Visible = false;
        LabelSumRes.Text = "";
        ListBoxRandomVector.Items.Clear();
        ListBoxResult.Items.Clear();
        Array.Clear(vector, 0, vector.Length);
    }

}
