using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Data;
using System.Collections.ObjectModel;

namespace UI.Model
{
    public static class DesignViewModel
    {
        public static MainData MainInstance = new MainData() {
            Title = "样例应用(设计模式)",
            GroupMessages = new ObservableCollection<Message>()
            {
                new Message
                {
                     Qq = 947295340,
                     GroupId = 711841640,
                     GroupName ="Native.SDK",
                     DisplayName ="洁儿哥哥",
                     Content ="日更!天天更!"
                }
            },
            Groups = new ObservableCollection<Group>()
            {
                new Group()
                {
                     GroupId = 711841640,
                     GroupName ="Native.SDK",
                }
            }
        };
    }
}
