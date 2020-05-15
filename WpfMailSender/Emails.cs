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
                        if (string.IsNullOrWhiteSpace(address)) return "������ ������ �����";
                        if (!Regex.IsMatch(address, @"[a-zA-A]\w*@\w+\.\w+"))
                            return "������ ������������ �����";
                        return "";
                    case nameof(Id):

                    default: return "";
                }
            }
        }

        partial void OnIdChanging(int value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "�������� ������ ���� ������ ����");
        }
    }
}