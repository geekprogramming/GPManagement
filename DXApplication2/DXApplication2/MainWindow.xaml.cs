using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Printing;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace DXApplication2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataSource();
        }

    }

    public class TestData
    {
        public string Text { get; set; }
        public int Number { get; set; }
    }

    public class TestDataViewModel : INotifyPropertyChanged
    {
        TestData data;
        public TestDataViewModel()
        {
            data = new TestData() { Text = string.Empty, Number = 0 };
        }
        public string Text
        {
            get { return Data.Text; }
            set
            {
                if (Data.Text == value)
                    return;
                Data.Text = value;
                RaisePropertyChanged("Text");
            }
        }
        public int Number
        {
            get { return Data.Number; }
            set
            {
                if (Data.Number == value)
                    return;
                Data.Number = value;
                RaisePropertyChanged("Number");
            }
        }
        protected TestData Data
        {
            get { return data; }
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
        protected void RaisePropertyChanged(string propertyName)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }

    public class DataSource
    {
        ObservableCollection<TestDataViewModel> source;
        public DataSource()
        {
            source = CreateDataSource();
        }
        protected ObservableCollection<TestDataViewModel> CreateDataSource()
        {
            ObservableCollection<TestDataViewModel> res = new ObservableCollection<TestDataViewModel>();
            res.Add(new TestDataViewModel() { Text = "Row0", Number = 0 });
            res.Add(new TestDataViewModel() { Text = "Row1", Number = 1 });
            res.Add(new TestDataViewModel() { Text = "Row2", Number = 2 });
            res.Add(new TestDataViewModel() { Text = "Row3", Number = 3 });
            res.Add(new TestDataViewModel() { Text = "Row4", Number = 4 });
            res.Add(new TestDataViewModel() { Text = "Row5", Number = 5 });
            res.Add(new TestDataViewModel() { Text = "Row6", Number = 6 });
            res.Add(new TestDataViewModel() { Text = "Row7", Number = 7 });
            res.Add(new TestDataViewModel() { Text = "Row8", Number = 8 });
            res.Add(new TestDataViewModel() { Text = "Row9", Number = 9 });
            return res;
        }
        public ObservableCollection<TestDataViewModel> Data { get { return source; } }
    }
}
