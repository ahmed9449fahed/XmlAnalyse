using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using DevExpress.Utils.MVVM;

namespace XmlAnalyser.Business.devexpresstools
{
    public partial class DevHeaderview : UserControl
    {
        public DevHeaderview()
        {
            InitializeComponent();
            Domain.Instance.PropertyChanged += InstanceOnPropertyChanged;

            comboBoxSort.DataBindings.Add(nameof(comboBoxSort.Enabled), this, nameof(HasSelectedStructureInfo), false,
                DataSourceUpdateMode.OnPropertyChanged);
        }
        public bool HasSelectedStructureInfo => Domain.Instance.SelectedStructureInfo != null;
        public event PropertyChangedEventHandler PropertyChanged;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = dialog.FileName;
                Domain.Instance.StructureInfo = XmlParser.Execute(XDocument.Load(fileName));
            }
            ControlEnable();
            

            
        }
        private void InstanceOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == nameof(Domain.SelectedStructureInfo))
                checkBoxFilterDuplicates.Checked = Domain.Instance.SelectedStructureInfo.FilterDuplicates;

            OnPropertyChanged(nameof(HasSelectedStructureInfo));
        }


        public void ControlEnable()
        {
            checkBoxLeereZeichne.Enabled = true;
            checkBoxFilterDuplicates.Enabled = true;
            checkBoxFilterLeere.Enabled = true;
            radioButtonSortenA.Enabled = true;
            radioButtonSortenD.Enabled = true;
            radioButtonClear.Enabled = true;
            comboBoxSort.Enabled = true;
        }

        public void ControlDisable()
        {
            checkBoxLeereZeichne.Enabled = false;
            checkBoxFilterDuplicates.Enabled = false;
            checkBoxFilterLeere.Enabled = false;
            radioButtonSortenA.Enabled = false;
            radioButtonSortenD.Enabled = false;
            radioButtonClear.Enabled = false;
            comboBoxSort.Enabled = false;
        }

        private void checkBoxLeereZeichne_CheckedChanged(object sender, EventArgs e)
        {
            if (Domain.Instance.SelectedStructureInfo != null)
                Domain.Instance.SelectedStructureInfo.FilterLeerZeichneData = checkBoxLeereZeichne.Checked;
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            if (Domain.Instance.SelectedStructureInfo != null)
                Domain.Instance.SelectedStructureInfo.FilterLeereData = checkBoxFilterLeere.Checked;
        }

        private void checkBoxFilterDuplicates_CheckedChanged(object sender, EventArgs e)
        {
            if (Domain.Instance.SelectedStructureInfo != null)
                Domain.Instance.SelectedStructureInfo.FilterDuplicates = checkBoxFilterDuplicates.Checked;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void DevHeaderview_Load(object sender, EventArgs e)
        {
            ControlDisable();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = SortType.Alpha;
            switch (comboBoxSort.Text)
            {
                case "Alpha":
                    result = SortType.Alpha;
                    break;
                case "Datum":
                    result = SortType.Datetime;
                    break;
                case "Numerisch":
                    result = SortType.Numeric;
                    break;

            }
            if (Domain.Instance.SelectedStructureInfo != null)
                Domain.Instance.SelectedStructureInfo.Sort = result;
        }

        private void radioButtonClear_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonClear.Checked)
            {
                StructureInfo.SortAscending = false;
                StructureInfo.SortDescinding = false;
                Domain.Instance.SelectedStructureInfo.Sortchange = radioButtonSortenA.Checked;
                Domain.Instance.SelectedStructureInfo.Sortchange = radioButtonSortenD.Checked;
                Domain.Instance.SelectedStructureInfo.Sortchange = radioButtonClear.Checked;
            }
        }

        private void radioButtonSortenD_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSortenD.Checked)
                if (Domain.Instance.SelectedStructureInfo != null)
                {
                    StructureInfo.SortDescinding = true;
                    StructureInfo.SortAscending = false;
                    Domain.Instance.SelectedStructureInfo.Sortchange = radioButtonSortenA.Checked;
                    Domain.Instance.SelectedStructureInfo.Sortchange = radioButtonSortenD.Checked;
                    Domain.Instance.SelectedStructureInfo.Sortchange = radioButtonClear.Checked;
                }
        }

        private void radioButtonSortenA_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSortenA.Checked)
                if (Domain.Instance.SelectedStructureInfo != null)
                {
                    StructureInfo.SortAscending = true;
                    StructureInfo.SortDescinding = false;
                    Domain.Instance.SelectedStructureInfo.Sortchange = radioButtonSortenA.Checked;
                    Domain.Instance.SelectedStructureInfo.Sortchange = radioButtonSortenD.Checked;
                    Domain.Instance.SelectedStructureInfo.Sortchange = radioButtonClear.Checked;
                }
        }
    }
}
