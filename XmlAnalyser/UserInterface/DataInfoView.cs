using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data.Helpers;
using XmlAnalyser.Business;

namespace XmlAnalyser.UserInterface
{
    public partial class DataInfoView : UserControl
    {
        private StructureInfo lastStructureInfo;

        public DataInfoView()
        {
            InitializeComponent();

            Domain.Instance.PropertyChanged += InstanceOnPropertyChanged;
        }

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

        public static double SourceCount;
        private void RefreshData()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(Domain.Instance.SelectedStructureInfo.FilteredData.ToArray());
            if (listBox1.Items.Count != 0)
            {
                labelAnzahl.Text = listBox1.Items.Count.ToString();              
                labelAnzahlProzent.Text = String.Format("{0:0.00}", Convert.ToDouble(labelAnzahl.Text) * 100 / SourceCount) +"%";
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

            if (testdata==false) lableDataType.Text = "Alpha";

        }
        private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void lableMaximalZeichen_Click(object sender, EventArgs e)
        {

        }
    }
}