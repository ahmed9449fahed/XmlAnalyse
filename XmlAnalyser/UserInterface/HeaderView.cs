using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Xml.Linq;
using XmlAnalyser.Annotations;
using XmlAnalyser.Business;

namespace XmlAnalyser.UserInterface
{
    public partial class HeaderView : UserControl, INotifyPropertyChanged
    {
        public HeaderView()
        {
            InitializeComponent();

            Domain.Instance.PropertyChanged += InstanceOnPropertyChanged;

            comboBoxSort.DataBindings.Add(nameof(comboBoxSort.Enabled), this, nameof(HasSelectedStructureInfo), false,
                DataSourceUpdateMode.OnPropertyChanged);
        }

        public bool HasSelectedStructureInfo => Domain.Instance.SelectedStructureInfo != null;

        public event PropertyChangedEventHandler PropertyChanged;

        private void InstanceOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName == nameof(Domain.SelectedStructureInfo))
                checkBoxFilterDuplicates.Checked = Domain.Instance.SelectedStructureInfo.FilterDuplicates;

            OnPropertyChanged(nameof(HasSelectedStructureInfo));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = dialog.FileName;
                Domain.Instance.StructureInfo = XmlParser.Execute(XDocument.Load(fileName));
            }
            ControlEnable();
            comboBoxSort.SelectedIndex = 1;
        }

        private void checkBoxFilterDuplicates_CheckedChanged(object sender, EventArgs e)
        {
            if (Domain.Instance.SelectedStructureInfo != null)
                Domain.Instance.SelectedStructureInfo.FilterDuplicates = checkBoxFilterDuplicates.Checked;
        }

        private void checkBoxFilterLeere_CheckedChanged(object sender, EventArgs e)
        {
            if (Domain.Instance.SelectedStructureInfo != null)
                Domain.Instance.SelectedStructureInfo.FilterLeereData = checkBoxFilterLeere.Checked;
        }

        private void checkBoxLeereZeichne_CheckedChanged(object sender, EventArgs e)
        {
            if (Domain.Instance.SelectedStructureInfo != null)
                Domain.Instance.SelectedStructureInfo.FilterLeerZeichneData = checkBoxLeereZeichne.Checked;
        }

        private void HeaderView_Load(object sender, EventArgs e)
        {
            ControlDisable();
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


        private void radioButtonSortenA_Click(object sender, EventArgs e)
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

        private void radioButtonSortenD_Click(object sender, EventArgs e)
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

        private void radioButtonClear_Click(object sender, EventArgs e)
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

        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
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

                default:
                    throw new NotImplementedException();
            }
            if (Domain.Instance.SelectedStructureInfo != null)
                Domain.Instance.SelectedStructureInfo.Sort = result;
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Withoutsort()
        {
            radioButtonClear.Checked = true;
        }

        private void radioButtonSortenA_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonSortenD_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonClear_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}