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
        private List<Car> allCars = new List<Car>();

        private string lastSortedColumn = null;
        private bool isAscending = true;

        private static readonly Dictionary<string, string> OperatorDisplayMap = new Dictionary<string, string>
        {
            { "Contains", "Содержит" },
            { "Equals", "Равно" },
            { "GreaterThan", "Больше" },
            { "LessThan", "Меньше" },
            { "GreaterOrEqual", "Больше или равно" },
            { "LessOrEqual", "Меньше или равно" }
        };

        private class FilterCriterion
        {
            public string Field { get; set; }
            public string Operator { get; set; }
            public string Value { get; set; }
            public override string ToString()
            {
                var op = OperatorDisplayMap.TryGetValue(Operator, out var disp) ? disp : Operator;
                return $"{Field} {op} {Value}";
            }
        }

        private readonly List<FilterCriterion> filters = new List<FilterCriterion>();

        public Form1()
        {
            InitializeComponent();
            SetupDataGridView();
            SetupFilterControls();
            LoadSampleData();
        }

        // Настройка DataGridView
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

        // Настройка элементов фильтра/поиска
        private void SetupFilterControls()
        {
            var properties = new[] { "Brand", "Model", "Year", "InStock", "Count", "Trim", "Price", "Discounts" };
            cbFilterField.Items.Clear();
            cbSearchField.Items.Clear();

            cbSearchField.Items.Add("Любое");

            foreach (var p in properties)
            {
                cbFilterField.Items.Add(p);
                cbSearchField.Items.Add(p);
            }

            if (cbFilterField.Items.Count > 0) cbFilterField.SelectedIndex = 0;
            if (cbSearchField.Items.Count > 0) cbSearchField.SelectedIndex = 0;

            var operatorKeys = new[] { "Contains", "Equals", "GreaterThan", "LessThan", "GreaterOrEqual", "LessOrEqual" };
            var operatorLabelsRus = operatorKeys.Select(k => OperatorDisplayMap[k]).ToArray();

            cbFilterOperator.Items.Clear();
            cbFilterOperator.Items.AddRange(operatorLabelsRus);
            cbFilterOperator.SelectedIndex = 0;
        }

        // Начальные данные
        private void LoadSampleData()
        {
            allCars.Clear();
            allCars.Add(new Car("Toyota", "Camry", 2024, true, 5, "Comfort", 2_500_000, "Trade-in"));
            allCars.Add(new Car("BMW", "X5", 2025, false, 0, "M Sport", 8_500_000, "Ипотечная скидка"));
            allCars.Add(new Car("Hyundai", "Tucson", 2023, true, 3, "Premium", 2_200_000, ""));
            allCars.Add(new Car("Lada", "Granta", 2024, true, 10, "Classic", 750_000, "Госпрограмма"));
            allCars.Add(new Car("Lada", "Vesta", 2025, true, 7, "Comfort", 1_100_000, "Господдержка"));
            allCars.Add(new Car("Lada", "Niva Travel", 2023, true, 4, "Luxury", 1_300_000, "Семейная"));

            ReloadBinding(allCars);
            UpdateHeaders();
        }

        private void ReloadBinding(IEnumerable<Car> source)
        {
            cars.RaiseListChangedEvents = false;
            cars.Clear();
            foreach (var c in source) cars.Add(c);
            cars.RaiseListChangedEvents = true;
            cars.ResetBindings();
        }

        private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            var property = TypeDescriptor.GetProperties(typeof(Car))[columnName];
            if (property == null) return;

            if (lastSortedColumn == columnName)
            {
                isAscending = !isAscending;
            }
            else
            {
                lastSortedColumn = columnName;
                isAscending = true;
            }

            var sorted = cars.ToList();

            int comparison = 0;
            sorted.Sort((x, y) =>
            {
                var valX = property.GetValue(x);
                var valY = property.GetValue(y);

                if (valX == null && valY == null) return 0;
                if (valX == null) return isAscending ? -1 : 1;
                if (valY == null) return isAscending ? 1 : -1;

                comparison = Comparer<object>.Default.Compare(valX, valY);

                return isAscending ? comparison : -comparison;
            });

            cars.Clear();
            foreach (var car in sorted)
            {
                cars.Add(car);
            }

            UpdateHeaders();
        }

        // Обновление заголовков столбцов для отображения порядка сортировки
        private void UpdateHeaders()
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                var headerText = col.Name;
                if (col.Name == lastSortedColumn)
                {
                    headerText += isAscending ? " ↑" : " ↓";
                }
                col.HeaderText = headerText;
            }
        }

        // Добавление и удаление строк
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newCar = new Car("Новый", "Автомобиль", DateTime.Now.Year, false, 0, "Base", 1_000_000, "");
            allCars.Add(newCar);
            cars.Add(newCar);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Car carToRemove = null;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                carToRemove = (Car)selectedRow.DataBoundItem;
            }
            else if (dataGridView1.CurrentCell != null)
            {
                var row = dataGridView1.CurrentCell.OwningRow;
                carToRemove = (Car)row.DataBoundItem;
            }

            if (carToRemove != null)
            {
                allCars.Remove(carToRemove);
                cars.Remove(carToRemove);
            }
        }

        // Добавление фильтров
        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            if (cbFilterField.SelectedItem == null || cbFilterOperator.SelectedItem == null) return;

            var operatorKeys = new[] { "Contains", "Equals", "GreaterThan", "LessThan", "GreaterOrEqual", "LessOrEqual" };
            var opIndex = cbFilterOperator.SelectedIndex;
            if (opIndex < 0 || opIndex >= operatorKeys.Length) return;
            var opKey = operatorKeys[opIndex];

            var criterion = new FilterCriterion
            {
                Field = cbFilterField.SelectedItem.ToString(),
                Operator = opKey,
                Value = txtFilterValue.Text ?? string.Empty
            };
            filters.Add(criterion);
            lstFilters.Items.Add(criterion.ToString());
            txtFilterValue.Clear();
        }

        // Удаление элемента из списка фильтров
        private void lstFilters_DoubleClick(object sender, EventArgs e)
        {
            var idx = lstFilters.SelectedIndex;
            if (idx >= 0 && idx < filters.Count)
            {
                filters.RemoveAt(idx);
                lstFilters.Items.RemoveAt(idx);
            }
        }

        // Применить фильтры
        private void btnApplyFilters_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            IEnumerable<Car> query = allCars;

            foreach (var f in filters)
            {
                query = ApplySingleFilter(query, f);
            }

            ReloadBinding(query);
        }

        private IEnumerable<Car> ApplySingleFilter(IEnumerable<Car> source, FilterCriterion f)
        {
            if (string.IsNullOrEmpty(f.Value)) return source;

            var prop = TypeDescriptor.GetProperties(typeof(Car))[f.Field];
            if (prop == null) return source;

            var type = prop.PropertyType;

            Func<Car, bool> predicate = car =>
            {
                var raw = prop.GetValue(car);
                if (raw == null) return false;

                var rawStr = raw.ToString() ?? string.Empty;
                var valStr = f.Value;

                switch (f.Operator)
                {
                    case "Contains":
                        return rawStr.IndexOf(valStr, StringComparison.OrdinalIgnoreCase) >= 0;
                    case "Equals":
                        if (type == typeof(string))
                        {
                            return string.Equals(rawStr, valStr, StringComparison.OrdinalIgnoreCase);
                        }
                        else
                        {
                            try
                            {
                                var converted = Convert.ChangeType(valStr, type);
                                return object.Equals(raw, converted);
                            }
                            catch { return false; }
                        }
                    case "GreaterThan":
                        try
                        {
                            var converted = Convert.ChangeType(valStr, type);
                            return Comparer<object>.Default.Compare(raw, converted) > 0;
                        }
                        catch { return false; }
                    case "LessThan":
                        try
                        {
                            var converted = Convert.ChangeType(valStr, type);
                            return Comparer<object>.Default.Compare(raw, converted) < 0;
                        }
                        catch { return false; }
                    case "GreaterOrEqual":
                        try
                        {
                            var converted = Convert.ChangeType(valStr, type);
                            return Comparer<object>.Default.Compare(raw, converted) >= 0;
                        }
                        catch { return false; }
                    case "LessOrEqual":
                        try
                        {
                            var converted = Convert.ChangeType(valStr, type);
                            return Comparer<object>.Default.Compare(raw, converted) <= 0;
                        }
                        catch { return false; }
                    default:
                        return false;
                }
            };

            return source.Where(predicate);
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            filters.Clear();
            lstFilters.Items.Clear();
            ReloadBinding(allCars);
        }

        // Поиск
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ApplySearch();
        }

        private void ApplySearch()
        {
            var q = txtSearch.Text?.Trim();
            if (string.IsNullOrEmpty(q))
            {
                ReloadBinding(allCars);
                return;
            }

            var selectedField = cbSearchField.SelectedItem?.ToString() ?? "Любое";

            IEnumerable<Car> result;
            if (selectedField == "Любое")
            {
                result = allCars.Where(car =>
                {
                    foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(typeof(Car)))
                    {
                        var val = pd.GetValue(car);
                        if (val != null && val.ToString().IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0) return true;
                    }
                    return false;
                });
            }
            else
            {
                var prop = TypeDescriptor.GetProperties(typeof(Car))[selectedField];
                if (prop == null) { result = Enumerable.Empty<Car>(); }
                else
                {
                    result = allCars.Where(car =>
                    {
                        var val = prop.GetValue(car);
                        return val != null && val.ToString().IndexOf(q, StringComparison.OrdinalIgnoreCase) >= 0;
                    });
                }
            }

            ReloadBinding(result);
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            if (cbSearchField.Items.Count > 0) cbSearchField.SelectedIndex = 0;
            ReloadBinding(allCars);
        }

        private void cbSearchField_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbFilterOperator_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstFilters_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}