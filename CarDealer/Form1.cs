using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace CarDealer
{
    public partial class Form1 : Form
    {
        private BindingList<Car> cars = new BindingList<Car>();

        public Form1()
        {
            InitializeComponent();
            SetupDataGridView();
            LoadSampleData();
        }

        private void SetupDataGridView()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnF2;

            var brandColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Brand",
                HeaderText = "Бренд",
                Name = "Brand"
            };
            dataGridView1.Columns.Add(brandColumn);

            var modelColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Model",
                HeaderText = "Модель",
                Name = "Model"
            };
            dataGridView1.Columns.Add(modelColumn);

            var yearColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Year",
                HeaderText = "Год",
                Name = "Year"
            };
            dataGridView1.Columns.Add(yearColumn);

            var inStockColumn = new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "InStock",
                HeaderText = "В наличии",
                Name = "InStock"
            };
            dataGridView1.Columns.Add(inStockColumn);

            var countColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Count",
                HeaderText = "Количество",
                Name = "Count"
            };
            dataGridView1.Columns.Add(countColumn);

            var trimColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Trim",
                HeaderText = "Комплектация",
                Name = "Trim"
            };
            dataGridView1.Columns.Add(trimColumn);

            var priceColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Price",
                HeaderText = "Цена",
                Name = "Price"
            };
            dataGridView1.Columns.Add(priceColumn);

            var discountColumn = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Discounts",
                HeaderText = "Скидки",
                Name = "Discounts"
            };
            dataGridView1.Columns.Add(discountColumn);

            dataGridView1.DataSource = cars;

            dataGridView1.ColumnHeaderMouseClick += DataGridView1_ColumnHeaderMouseClick;
        }

        private void LoadSampleData()
        {
            cars.Add(new Car("Toyota", "Camry", 2024, true, 5, "Comfort", 2_500_000, "Trade-in"));
            cars.Add(new Car("BMW", "X5", 2025, false, 0, "M Sport", 8_500_000, "Military"));
            cars.Add(new Car("Hyundai", "Tucson", 2023, true, 3, "Premium", 2_200_000, ""));
            cars.Add(new Car("Lada", "Granta", 2024, true, 10, "Classic", 750_000, "Госпрограмма"));
            cars.Add(new Car("Lada", "Vesta", 2025, true, 7, "Comfort", 1_100_000, "Господдержка"));
            cars.Add(new Car("Lada", "Niva Travel", 2023, true, 4, "Luxury", 1_300_000, "Семейная"));
        }

        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            var property = TypeDescriptor.GetProperties(typeof(Car))[columnName];
            if (property == null) return;

            var sorted = cars.ToList(); // Преобразование BindingList в List
            sorted.Sort((x, y) => Comparer<object>.Default.Compare(property.GetValue(x), property.GetValue(y)));

            cars.Clear();
            foreach (var car in sorted)
            {
                cars.Add(car);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newCar = new Car("Новый", "Автомобиль", DateTime.Now.Year, false, 0, "Base", 1_000_000, "");
            cars.Add(newCar);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                var car = (Car)selectedRow.DataBoundItem;
                cars.Remove(car);
            }
            else if (dataGridView1.CurrentCell != null)
            {
                var row = dataGridView1.CurrentCell.OwningRow;
                var car = (Car)row.DataBoundItem;
                cars.Remove(car);
            }
        }
    }
}