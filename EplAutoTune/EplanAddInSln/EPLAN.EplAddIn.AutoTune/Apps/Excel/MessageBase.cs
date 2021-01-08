using Eplan.EplApi.MasterData;
using System.Collections.Generic;
using System.ComponentModel;

namespace EPLAN.EplAddIn.AutoTune.Apps
{
    public class MessageBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string mesg { get; set; }
        public string Message
        {
            get
            {
                return mesg;
            }
            set
            {
                mesg = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public void OnPropertyChanged(string mesg)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(mesg));
        }


        private int counter;

        public int ProcessBarCounter
        {
            get { return counter; }
            set { counter = value; OnPropertyChanged(nameof(ProcessBarCounter)); }
        }

        public List<MDPartsDatabaseItem.Enums.ProductTopGroup> ProductTopGroups { get; set; }
        public List<MDPartsDatabaseItem.Enums.ProductGroup> ProductGroups { get; set; }
        public List<MDPartsDatabaseItem.Enums.ProductSubGroup> ProductSubGroups { get; set; }

    }
}
