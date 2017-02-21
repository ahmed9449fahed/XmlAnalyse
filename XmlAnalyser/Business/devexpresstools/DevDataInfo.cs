using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace XmlAnalyser.Business.devexpresstools
{
    public partial class DevDataInfo : UserControl
    {
        public DevDataInfo()
        {
            InitializeComponent();
            Domain.Instance.PropertyChanged += InstanceOnPropertyChanged;
        }
        private StructureInfo lastStructureInfo;
        public static double SourceCount;
        private void InstanceOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == nameof(Domain.SelectedStructureInfo))
            {
                if (lastStructureInfo != null)
                    lastStructureInfo.PropertyChanged -= SelectedStructureInfoOnPropertyChanged;

                Domain.Instance.SelectedStructureInfo.PropertyChanged += SelectedStructureInfoOnPropertyChanged;
                lastStructureInfo = Domain.Instance.SelectedStructureInfo;

                RefreshData();
            }
        }

     
        private void RefreshData()
        {

            Fillgrid();
           
            if (Domain.Instance.SelectedStructureInfo.FilteredData.ToArray().Length!=0)
            {
                labelAnzahl.Text = Domain.Instance.SelectedStructureInfo.FilteredData.ToArray().Length.ToString();
                labelAnzahlProzent.Text = String.Format("{0:0.00}", Convert.ToDouble(labelAnzahl.Text) * 100 / SourceCount) + "%";
                Testdatatype(Domain.Instance.SelectedStructureInfo.FilteredData.ToArray());
                FindMaximalZeichen(Domain.Instance.SelectedStructureInfo.FilteredData.ToArray());
            }
            else
            {
                labelAnzahl.Text = "0";
                labelAnzahlProzent.Text = "0" + "%";
            }
            labelMaxAnzahl.Text = SourceCount.ToString();
        }
        private void Fillgrid()
        {
            
           
            string colName = "Data";
            gridControl1.DataSource = null;
            DataTable dt = new DataTable();
            dt.Columns.Add(colName);
            IEnumerable<string> filterdata = Domain.Instance.SelectedStructureInfo.FilteredData.ToArray();
          
            foreach (string items in filterdata)
            {
                dt.Rows.Add(items);
            }
            gridControl1.DataSource = dt;
            gridControl1.Refresh();
         
        }
        private void SelectedStructureInfoOnPropertyChanged(object sender,
       PropertyChangedEventArgs propertyChangedEventArgs)
        {
            RefreshData();
        }
        private void FindMaximalZeichen(string[] array)
        {
            int maximalZeichen = 0;
            foreach (string info in array)
            {
                if (info.Length > maximalZeichen)
                    maximalZeichen = info.Length;
            }
            lableMaximalZeichen.Text = maximalZeichen.ToString();

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
                lableDataType.Text = "Numerisch";
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
                    lableDataType.Text = "Datatime";
                    testdata = true;
                }
            }

            if (testdata == false) lableDataType.Text = "Alpha";

        }

        private void gridControl1_Click_1(object sender, EventArgs e)
        {

        }

        private void gridView1_ColumnChanged(object sender, EventArgs e)
        {
            gridView1.Appearance.FocusedCell.BackColor=Color.Chocolate;
        }
    }
}


    

  

 
    
    

   

    

   
  

