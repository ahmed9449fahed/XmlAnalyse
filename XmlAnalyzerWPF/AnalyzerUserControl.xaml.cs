using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;
using XmlAnalyzerWPF.Business;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace XmlAnalyzerWPF
{
    /// <summary>
    /// Interaction logic for AnalyzerUserControl.xaml
    /// </summary>
    public partial class AnalyzerUserControl : INotifyPropertyChanged
    {
        public AnalyzerUserControl()
        {
            InitializeComponent();
            DataContext = this;
            Domain.Instance.PropertyChanged += DomainInstance_PropertyChanged;
          
        }
        private List<string> _dataBinding=new List<string>();
        public List<string> DataBinding
        {
            set
            {
                if(DataBinding==value)
                    return;
                _dataBinding = value;
                OnPropertyChanged(nameof(DataBinding));
            }
            get { return _dataBinding; }
        }
        public bool HasSelectedStructureInfo => Domain.Instance.SelectedStructureInfo != null;
        private void DomainInstance_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Domain.SelectedStructureInfo))
                CheckBoxDoppelte.IsChecked = Domain.Instance.SelectedStructureInfo.FilterDuplicates;
                OnPropertyChanged(nameof(HasSelectedStructureInfo));
        }
        private void RefreshData()
        {
            if (Domain.Instance.SelectedStructureInfo.FilteredData != null)
            {
                DataBinding = Domain.Instance.SelectedStructureInfo.FilteredData.ToList();
            }
            if (DataBinding.Count != 0)
            {
                LblAnzahle.Content = DataBinding.Count.ToString();
                LblAnzahlProzent.Content = String.Format("{0:0.00}", Convert.ToDouble(LblAnzahle.Content) * 100 / SourceCount) + "%";
                Testdatatype(DataBinding.ToArray());
                FindMaximalZeichen(DataBinding.ToArray());
            }
            else
            {
                LblAnzahle.Content = "0";
                LblAnzahlProzent.Content = "0" + "%";
            }
            LblGesamtAnzahl.Content = SourceCount.ToString();
        }
        private void FindMaximalZeichen(string[] array)
        {
            int maximalZeichen = 0;
            foreach (string info in array)
            {
                if (info.Length > maximalZeichen)
                    maximalZeichen = info.Length;
            }
            LblmaximumZeichen.Content = maximalZeichen.ToString();

        }
        private void Testdatatype(string[] array)
        {
            bool testdata = false;
            int x;
            int counter = 0;
            int count = array.Length;
            foreach (string info in array)
            {
                if (int.TryParse(info, out x))
                {
                    counter += 1;
                }
            }
            if (counter == count)
            {
                LblDataType.Content = "Numerisch";
                testdata = true;

            }
            else counter = 0;
            if (testdata == false)
            {
                foreach (string info in array)
                {
                    DateTime atime;
                    string[] formats =
                    {
                        "dd/MM/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy",
                        "dd/MM/yy", "dd/M/yy", "d/M/yy", "d/MM/yy", "dd.MM.yyyy"
                    };

                    if (DateTime.TryParseExact(info, formats, CultureInfo.CurrentCulture, DateTimeStyles.None, out atime))
                    {
                        counter += 1;
                    }
                }
                if (counter == count)
                {
                    LblDataType.Content = "Datatime";
                    testdata = true;
                }
            }
            if (testdata == false) LblDataType.Content = "Alpha";
        }
        //private void Fillgrid()
        //{
            
            //string colName = "Data";
            //GridControl1.ItemsSource = null;
            //DataTable dt = new DataTable();
            //dt.Columns.Add(colName);
            //IEnumerable<string> filterdata = Domain.Instance.SelectedStructureInfo.FilteredData.ToArray();

            //foreach (string items in filterdata)
            //{
            //    dt.Rows.Add(items);
            //}
            //GridControl1.ItemsSource = dt;
            //GridControl1.RefreshData();
        //}
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxSortirungType.Items.Add(SortType.Numeric);
            ComboBoxSortirungType.Items.Add(SortType.Alpha);
            ComboBoxSortirungType.Items.Add(SortType.Datetime);         
        }
        private void Btnopen_OnClick(object sender, RoutedEventArgs e)
        {
            TreeView1.Items.Clear();
            Controlnotcheck();
            OpenFileDialog open = new OpenFileDialog();
            open.ShowDialog();
            string filename = open.FileName;
            try
            {
                Domain.Instance.StructureInfo = XmlParser.Execute(XDocument.Load(filename));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
           
            FillTreeView();
        }
        public void FillTreeView()
        { 
            var rootInfo = Domain.Instance.StructureInfo;
            var rootNode = new TreeViewItem();
            rootNode.Header = rootInfo.Name;
            TreeView1.Items.Add(rootNode);
            AddChildNodesRecursive(rootInfo, rootNode);          
        }
        private void AddChildNodesRecursive(StructurInfo info, TreeViewItem node)
        {
            foreach (var childInfo in info.Childs)
            {
                var childNode = new TreeViewItem();
                childNode.Header = childInfo.Name;
                childNode.Tag = childInfo;
                node.Items.Add(childNode);
                AddChildNodesRecursive(childInfo, childNode);
            }
        }
        public static int SourceCount;
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            //if (propertyName == "DataBinding")
            //{
            //    GridControl1.ItemsSource = _dataBinding;
            //    GridControl1.RefreshData();
            //}
        }
        public void ControlEnable()
        {
            CheckBoxLeere.IsEnabled = true;
            CheckBoxDoppelte.IsEnabled = true;
            CheckBoxLeerzeichen.IsEnabled = true;
            RadioButtonAbfwärts.IsEnabled = true;
            RadioButtonAufwärts.IsEnabled = true;
            RadioButtonOhneSortierung.IsEnabled = true;
            ComboBoxSortirungType.IsEnabled = true;
        }
        public void ControlDisable()
        {
            CheckBoxLeere.IsEnabled = false;
            CheckBoxDoppelte.IsEnabled = false;
            CheckBoxLeerzeichen.IsEnabled = false;
            RadioButtonAbfwärts.IsEnabled = false;
            RadioButtonAufwärts.IsEnabled = false;
            RadioButtonOhneSortierung.IsEnabled = false;
            ComboBoxSortirungType.IsEnabled = false;
        }
        private void TreeView1_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            Controlnotcheck();
            var selected = TreeView1.SelectedItem as TreeViewItem;
            if (selected != null)
            {
                var structureInfo = selected.Tag as StructurInfo;
                Domain.Instance.SelectedStructureInfo = structureInfo;
            }
            RefreshData();
        }
        private void CheckBoxDoppelte_OnClick(object sender, RoutedEventArgs e)
        {
            if (Domain.Instance.SelectedStructureInfo != null)
                if (CheckBoxDoppelte.IsChecked != null)
                    Domain.Instance.SelectedStructureInfo.FilterDuplicates = CheckBoxDoppelte.IsChecked.Value;
            RefreshData();
        }
        private void CheckBoxLeere_OnClick(object sender, RoutedEventArgs e)
        {
            if (Domain.Instance.SelectedStructureInfo != null)
                if (CheckBoxLeere.IsChecked != null)
                    Domain.Instance.SelectedStructureInfo.FilterLeereData = CheckBoxLeere.IsChecked.Value;
            RefreshData();
        }
        private void CheckBoxLeerzeichen_OnClick(object sender, RoutedEventArgs e)
        {
            if (Domain.Instance.SelectedStructureInfo != null)
                if (CheckBoxLeerzeichen.IsChecked != null)
                    Domain.Instance.SelectedStructureInfo.FilterLeerZeichneData = CheckBoxLeerzeichen.IsChecked.Value;
            RefreshData();
        }
        private void RadioButtonAufwärts_OnClick(object sender, RoutedEventArgs e)
        {
            if (RadioButtonAufwärts.IsChecked != null && RadioButtonAufwärts.IsChecked.Value)
                if (Domain.Instance.SelectedStructureInfo != null)
                {
                    StructurInfo.SortAscending = true;
                    StructurInfo.SortDescinding = false;
                    Domain.Instance.SelectedStructureInfo.Sortchange = RadioButtonAufwärts.IsChecked.Value;
                    if (RadioButtonAbfwärts.IsChecked != null)
                    {
                        Domain.Instance.SelectedStructureInfo.Sortchange = RadioButtonAbfwärts.IsChecked.Value;
                        if (RadioButtonOhneSortierung.IsChecked != null)
                            Domain.Instance.SelectedStructureInfo.Sortchange = RadioButtonOhneSortierung.IsChecked.Value;
                    }
                }
            RefreshData();
        }
        private void RadioButtonAbfwärts_OnClick(object sender, RoutedEventArgs e)
        {
            if (RadioButtonAbfwärts.IsChecked != null && RadioButtonAbfwärts.IsChecked.Value)
                if (Domain.Instance.SelectedStructureInfo != null)
                {
                    StructurInfo.SortAscending = false;
                    StructurInfo.SortDescinding = true;
                    if (RadioButtonAufwärts.IsChecked != null)
                    {
                        Domain.Instance.SelectedStructureInfo.Sortchange = RadioButtonAufwärts.IsChecked.Value;
                        Domain.Instance.SelectedStructureInfo.Sortchange = RadioButtonAbfwärts.IsChecked.Value;
                        if (RadioButtonOhneSortierung.IsChecked != null)
                            Domain.Instance.SelectedStructureInfo.Sortchange = RadioButtonOhneSortierung.IsChecked.Value;
                    }
                }
            RefreshData();
        }
        private void RadioButtonOhneSortierung_OnClick(object sender, RoutedEventArgs e)
        {
            if (RadioButtonOhneSortierung.IsChecked != null && RadioButtonOhneSortierung.IsChecked.Value)
                if (Domain.Instance.SelectedStructureInfo != null)
                {
                    StructurInfo.SortAscending = false;
                    StructurInfo.SortDescinding = false;
                    if (RadioButtonAufwärts.IsChecked != null)
                    {
                        Domain.Instance.SelectedStructureInfo.Sortchange = RadioButtonAufwärts.IsChecked.Value;
                        if (RadioButtonAbfwärts.IsChecked != null)
                        {
                            Domain.Instance.SelectedStructureInfo.Sortchange = RadioButtonAbfwärts.IsChecked.Value;
                            Domain.Instance.SelectedStructureInfo.Sortchange = RadioButtonOhneSortierung.IsChecked.Value;
                        }
                    }
                }
            RefreshData();
        }
        private void ComboBoxSortirungType_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SortType result;
            switch (ComboBoxSortirungType.SelectedItem.ToString())
            {
                case "Alpha":
                    result = SortType.Alpha;
                    break;
                case "Datetime":
                    result = SortType.Datetime;
                    break;
                case "Numeric":
                    result = SortType.Numeric;
                    break;
  
                default:
                    throw new NotImplementedException();
            }
            if (Domain.Instance.SelectedStructureInfo != null)
                Domain.Instance.SelectedStructureInfo.Sort = result;
            RefreshData();
        }
        private void Btnclose_OnClick(object sender, RoutedEventArgs e)
        {
            Application curApp = Application.Current;
            curApp.Shutdown();
        }
        public void Controlnotcheck()
        {
            CheckBoxDoppelte.IsChecked = false;
            CheckBoxLeere.IsChecked = false;
            CheckBoxLeerzeichen.IsChecked = false;
            RadioButtonAbfwärts.IsChecked = false;
            RadioButtonAufwärts.IsChecked = false;
            ComboBoxSortirungType.SelectedItem = SortType.None;
        }
    }
}
