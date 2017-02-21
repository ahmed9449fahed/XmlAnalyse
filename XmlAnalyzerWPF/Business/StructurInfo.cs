using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using XmlAnalyzerWPF.Annotations;
using XmlAnalyzerWPF.Business.Comparer;

namespace XmlAnalyzerWPF.Business
{
  public class StructurInfo:INotifyPropertyChanged
    {

        private bool _filterDuplicates;
        private bool _filterLeereData;
        private bool _filterLeerzeicheneData;
        private bool _sortAcsending;
        private bool _sortDescending;
        private SortType _sorttype;


        private List<StructurInfo> _childCollection;

        private List<string> _dataCollection;

        private List<StructurInfo> ChildCollection
         => _childCollection ?? (_childCollection = new List<StructurInfo>());
        public IEnumerable<StructurInfo> Childs => ChildCollection;
      
        private List<string> DataCollection => _dataCollection ?? (_dataCollection = new List<string>());
        public string Name { get; }

        public StructurInfo(string name)
        {
            Name = name;
        }
        public void AddChild(StructurInfo child)
        {
            ChildCollection.Add(child);
        }

        public void AddData(string value)
        {
            DataCollection.Add(value);
        }

        public override string ToString()
        {
            return $"StructureInfo: {Name}";
        }
        public IEnumerable<string> Data => DataCollection;
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public bool FilterDuplicates
        {
            get { return _filterDuplicates; }
            set
            {
                if (_filterDuplicates != value)
                {
                    _filterDuplicates = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool FilterLeereData
        {
            get { return _filterLeereData; }
            set
            {
                if (_filterLeereData != value)
                {
                    _filterLeereData = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool FilterLeerZeichneData
        {
            get { return _filterLeerzeicheneData; }
            set
            {
                if (_filterLeerzeicheneData != value)
                {
                    _filterLeerzeicheneData = value;
                    OnPropertyChanged();
                }
            }
        }

        public SortType Sort
        {
            get { return _sorttype; }
            set
            {
                if (_sorttype != value)
                {
                    _sorttype = value;
                    OnPropertyChanged();
                }
            }
        }

        public static bool SortAscending { get; set; }

        public static bool SortDescinding { get; set; }


        public bool Sortchange
        {
            get { return _sortAcsending; }
            set
            {
                if (_sortAcsending != value)
                {
                    _sortAcsending = value;
                    OnPropertyChanged();
                }
            }
        }
        public IEnumerable<string> FilteredData
        {
            get
            {
                var result = Data;


                if (FilterDuplicates)
                    result = result.Distinct();

                if (FilterLeereData)
                    result = result.Where(s => s != "");
                if (FilterLeerZeichneData)
                    result = result.Select(x => x.Trim());


                if (SortAscending)
                    switch (Sort)
                    {
                        case SortType.Numeric:
                            result = result.OrderBy(s => s, new StringComparerNumeric());
                            break;

                        case SortType.Alpha:
                            result = result.OrderBy(s => s, new StringComparerAlpha());
                            break;

                        case SortType.Datetime:
                            result = result.OrderBy(s => s, new StringComparerDatetime());
                            break;
                        default:
                            break;
                    }
                if (SortDescinding)
                    switch (Sort)
                    {
                        case SortType.Numeric:
                            result = result.OrderByDescending(s => s, new StringComparerNumeric());
                            break;
                        case SortType.Alpha:
                            result = result.OrderByDescending(s => s, new StringComparerAlpha());
                            break;
                        case SortType.Datetime:
                            result = result.OrderByDescending(s => s, new StringComparerDatetime());
                            break;
                        default:
                            break;
                    }
                return result;
            }
        }

    }
}
