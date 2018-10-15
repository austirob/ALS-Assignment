using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using GalaSoft.MvvmLight;

namespace XboxGamesUI.Models
{
    public class Game:ObservableObject
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id == value)
                {
                    return;
                }
                _id = value;
                RaisePropertyChanged("Id");
            }
        }


        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (_title == value)
                {
                    return;
                }
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        private string _desc;
        public string Desc
        {
            get { return _desc; }
            set
            {
                if (_desc == value)
                {
                    return;
                }

                _desc = value;
                RaisePropertyChanged("Desc");
            }
        }


        private ObservableCollection<object> _avgRating;
        public ObservableCollection<object> AvgRating
        {
            get { return _avgRating; }
            set
            {
                if (_avgRating == value)
                {
                    return;
                }

                _avgRating = value;
                RaisePropertyChanged("AvgRating");
            }
        }

    }
}