using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace WpfMailSender
{
    partial class Email : IDataErrorInfo
    {
        public string Error { get; }

        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Email1):

                        var address = Email1;
                        if (string.IsNullOrWhiteSpace(address)) return "¬веден пустой адрес";
                        if (!Regex.IsMatch(address, @"[a-zA-A]\w*@\w+\.\w+"))
                            return "¬веден некорректный адрес";
                        return "";
                    case nameof(Id):

                    default: return "";
                }
            }
        }

        partial void OnIdChanging(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "«начение должно быть больше нул€");
        }
    }
}