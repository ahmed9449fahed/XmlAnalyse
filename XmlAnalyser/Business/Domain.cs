using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XmlAnalyser.Business
{
    internal class Domain : INotifyPropertyChanged
    {
        private static Domain _instance;

        private StructureInfo _selectedStructureInfo;
        private StructureInfo _structureInfo;

        private Domain()
        {
        }

        internal StructureInfo StructureInfo
        {
            get { return _structureInfo; }
            set
            {
                if (_structureInfo != value)
                {
                    _structureInfo = value;
                    OnPropertyChanged();
                }
            }
        }

        public static Domain Instance => _instance ?? (_instance = new Domain());

        public StructureInfo SelectedStructureInfo
        {
            get { return _selectedStructureInfo; }
            set
            {
                if (_selectedStructureInfo != value)
                {
                    _selectedStructureInfo = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}