using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XmlAnalyzerWPF.Annotations;

namespace XmlAnalyzerWPF.Business
{
   public class Domain: INotifyPropertyChanged
    {
        private static Domain _instance;

        private StructurInfo _selectedStructureInfo;
        private StructurInfo _structureInfo;


        internal StructurInfo StructureInfo
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
        public StructurInfo SelectedStructureInfo
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

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
